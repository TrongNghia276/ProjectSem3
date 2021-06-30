"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message,image) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var userm = user;
    var imagem = image;
    var msgm = msg;
   
    var div = document.createElement("div");
    div.classList.add('direct-chat-name');
    div.textContent = userm;
    var img = document.createElement("img");

    img.setAttribute("src", imagem);
    img.classList.add('direct-chat-img');
 
    var div2 = document.createElement("div");
    div2.classList.add('direct-chat-text');
    div2.textContent = msgm;

    
   

    document.getElementById("messagesList").appendChild(div);
    document.getElementById("messagesList").appendChild(img);
    document.getElementById("messagesList").appendChild(div2);
    document.getElementById("messageInput").value = '';
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var image = document.getElementById("userInputImage").value;
    var message = document.getElementById("messageInput").value;
    if (message == '') {

    } else {
        connection.invoke("SendMessage", user, message, image).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    }
   
});

document.addEventListener("DOMContentLoaded", function () {
    function bindConnectionMessage(connection) {
        var messageCallback = function (message) {
            console.log("message" + message);
            if (!message) return;
            var userCountSpan = document.getElementById("online1");
            userCountSpan.textContent = message;
        };
        connection.on("updateCount", messageCallback);
        connection.onclose(onConnectionError);
    }
    function onConnected(connection) {
        console.log("connection started");
    }
    function onConnectionError(error) {
        if (error && error.message) {
            console.error(error.message);
        }
    }
    var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();
    bindConnectionMessage(connection);
    connection
        .start()
        .then(function () {
            onConnected(connection);
        })
        .catch(function (error) {
            console.error(error.message);
        });
});