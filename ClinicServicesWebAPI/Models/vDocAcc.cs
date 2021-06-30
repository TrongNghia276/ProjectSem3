using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicServicesWebAPI.Models
{
    public class vDocAcc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KeyID { get; set; }
        
        public DoctorDetail doctorDetail { get; set; }
        public Accounts accounts { get; set; }
    }
}
