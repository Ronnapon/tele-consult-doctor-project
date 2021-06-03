using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tele_consult.Data.Models
{
    public class Doctor_Specialization
    {
        public int Id { get; set; }

        // Navigation Properties
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }


        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
    }
}
