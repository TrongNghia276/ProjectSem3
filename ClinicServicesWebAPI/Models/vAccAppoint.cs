using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
namespace ClinicServicesWebAPI.Models
{
    public class vAccAppoint
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KeyID { get; set; }
       public Accounts accounts { get; set; }
        public Appointment appointment { get; set; }
    }
}
