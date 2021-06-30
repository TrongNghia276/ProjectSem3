using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicServicesWebAPI.Models
{
    public class vCateChildEquipments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KeyID { get; set; }
        public CategoryChild CategoryChild { get; set; }
        public MedicalEquipments MedicalEquipments { get; set; }
    }
}
