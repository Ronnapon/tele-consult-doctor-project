using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tele_consult.Data.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigator Properties
        public List<Doctor_Specialization> Doctor_Specialization { get; set; }
    }
}
