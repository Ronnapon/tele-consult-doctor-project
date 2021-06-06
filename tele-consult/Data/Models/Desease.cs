using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tele_consult.Data.Models
{
    public class Desease
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Nevigator Properties
        public int SpecializationId { get; set; }
        public Specialization specialization { get; set; }
    }
}
