using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tele_consult.Data.Models;

namespace tele_consult.Data.ViewModel
{
    public class DoctorVM
    {
        public string Fullname { get; set; }
        public string Detail { get; set; }
        public DateTime Praticing_from { get; set; }
        public string ImmageUrl { get; set; }

        // Navigator Properties
        public int HospitalId { get; set; }
        public List<int> SpecializationId { get; set; }
    }

    public class DoctorWithWithSpecialVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Detail { get; set; }
        public string ImageUrl { get; set; }
        public string Hospital { get; set; }
        public double Hospital_Latitude { get; set; }
        public double Hospital_Longitude { get; set; }
        public List<string> Specialization { get; set; }
    }
}
