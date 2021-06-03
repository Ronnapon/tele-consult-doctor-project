using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tele_consult.Data.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Detail { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime Praticing_from {get;set;}
        public string ImmageUrl { get; set; }
        public DateTime DateAdded { get; set; }

        // Navigator Properties
        public int HospitalId { get; set; }
        public Hospital hospital { get; set; }
        public List<Doctor_Specialization> Doctor_Specialization { get; set; }

    }
}
