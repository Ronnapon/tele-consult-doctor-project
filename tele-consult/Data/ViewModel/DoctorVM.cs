using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tele_consult.Data.ViewModel
{
    public class DoctorVM
    {
            public string FullName { get; set; }
            public string Detail { get; set; }
            public string ImageUrl { get; set; }
            public string Hospital { get; set; }
            public double Hospital_Latitude { get; set; }
            public double Hospital_Longitude { get; set; }
            public List<string> Specialization { get; set; }
    }
}
