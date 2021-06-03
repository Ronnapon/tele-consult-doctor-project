using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tele_consult.Data.ViewModel;

namespace tele_consult.Data.Models.Services
{
    public class DoctorsService
    {
        private AppDbContext _context;
        public DoctorsService(AppDbContext context)
        {
            _context = context;
        }

        public List<DoctorVM> GetAllDoctors(string searchName, string filterSpecialization)
        {
            var doctors = _context.Doctors.Select(doctor => new DoctorVM()
            {
                FullName = doctor.Fullname,
                Detail = doctor.Detail,
                ImageUrl = doctor.ImmageUrl,
                Hospital = doctor.hospital.Name,
                Specialization = doctor.Doctor_Specialization.Select(n => n.Specialization.Name).ToList()
            }).ToList();

            // Search
            if (!string.IsNullOrEmpty(searchName))
            {
              doctors = doctors.Where(n => n.FullName.Contains(searchName, 
                  StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            // Filter
            
            if (!string.IsNullOrEmpty(filterSpecialization))
            {
                List<DoctorVM> tmpDoctors = new List<DoctorVM>();
                foreach (var doctor in doctors)
                {
                    foreach(var specialname in doctor.Specialization)
                    {
                        if (specialname == filterSpecialization)
                        {
                            tmpDoctors.Add(doctor);
                            break;
                        }
                    }
                }
                doctors = tmpDoctors;
            }
            return doctors;
        }
    }
}
