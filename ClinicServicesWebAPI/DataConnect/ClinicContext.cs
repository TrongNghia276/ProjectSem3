using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicServicesWebAPI.Models;

namespace ClinicServicesWebAPI.DataConnect
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions options) : base(options) { }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<CategoryChild> CategoryChild { get; set; }
        public DbSet<DoctorDetail> DoctorDetail { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<HealthInformations> HealthInformations { get; set; }
        public DbSet<MedicalEquipments> MedicalEquipments { get; set; }
        public DbSet<Medicines> Medicines { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Seminar> Seminar { get; set; }
        public DbSet<vAccAppoint> vAccAppoint { get; set; }
        public DbSet<vDocAcc> vDocAcc { get; set; }
        public DbSet<vAccFeedB> vAccFeedB { get; set; }
        //public DbSet<vAccOrder> vAccOrder { get; set; }
        //public DbSet<vAppointDr> vAppointDr { get; set; }
        //public DbSet<vCateCateChild> vCateCateChild { get; set; }
        //public DbSet<vCateChildMedicines> vCateChildMedicines { get; set; }
        //public DbSet<vCateChildEquipments> vCateChildEquipments { get; set; }
        //public DbSet<vFeedMedicines> vFeedMedicines { get; set; }
        //public DbSet<vFeedEquipments> vFeedEquipments { get; set; }
        //public DbSet<vOrderMedicines> vOrderMedicines { get; set; }
        //public DbSet<vOrderEquipments> vOrderEquipments { get; set; }
    }
}
