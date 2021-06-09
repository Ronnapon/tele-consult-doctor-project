using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tele_consult.Data.Paging;
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

        public List<DoctorWithWithSpecialVM> GetAllDoctors(string searchName, string filterSpecialization, int? pageNumber)
        {
            var doctors = _context.Doctors.Select(doctor => new DoctorWithWithSpecialVM()
            {
                Id = doctor.Id,
                FullName = doctor.Fullname,
                Detail = doctor.Detail,
                ImageUrl = doctor.ImmageUrl,
                Hospital = doctor.hospital.Name,
                Hospital_Latitude = doctor.hospital.Latitude,
                Hospital_Longitude = doctor.hospital.Longitude,
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
                List<DoctorWithWithSpecialVM> tmpDoctors = new List<DoctorWithWithSpecialVM>();
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

            // Paging
            if (pageNumber != 0)
            {
                int pageSize = 1;
                doctors = PaginatedList<DoctorWithWithSpecialVM>.Create(doctors.AsQueryable(), pageNumber ?? 1, pageSize);
            }
            return doctors;
        }

        public DoctorWithWithSpecialVM GetDoctor(int doctorId)
        {
            var doctor = _context.Doctors.Where(n => n.Id == doctorId)
                .Select(doctor => new DoctorWithWithSpecialVM()
                {
                    Id = doctor.Id,
                    FullName = doctor.Fullname,
                    Detail = doctor.Detail,
                    ImageUrl = doctor.ImmageUrl,
                    Hospital = doctor.hospital.Name,
                    Hospital_Latitude = doctor.hospital.Latitude,
                    Hospital_Longitude = doctor.hospital.Longitude,
                    Specialization = doctor.Doctor_Specialization.Select(n => n.Specialization.Name).ToList()
                }).FirstOrDefault();
            return doctor;
        }

        public void AddDoctor(DoctorVM doctor)
        {
            var _doctor = new Doctor()
            {
                Fullname = doctor.Fullname,
                Detail = doctor.Detail,
                ImmageUrl = doctor.ImmageUrl,
                HospitalId = doctor.HospitalId,
                DateAdded = DateTime.Now
            };
            _context.Doctors.Add(_doctor);
            _context.SaveChanges();

            foreach (int specialId in doctor.SpecializationId)
            {
                var _doctor_specialization = new Doctor_Specialization()
                {
                    DoctorId = _doctor.Id,
                    SpecializationId = specialId
                };
                _context.Doctor_Specialization.Add(_doctor_specialization);
                _context.SaveChanges();
            }
        }

        public void UpdateDoctor(DoctorVM doctor, int doctorId)
        {
            var _doctor = _context.Doctors.FirstOrDefault(n => n.Id == doctorId);
            if (_doctor != null)
            {
                _doctor.Fullname = doctor.Fullname;
                _doctor.Detail = doctor.Detail;
                _doctor.ImmageUrl = doctor.ImmageUrl;
                _doctor.HospitalId = doctor.HospitalId;
                var doctor_specialization = _context.Doctor_Specialization.Where(n => n.DoctorId == _doctor.Id);
                foreach (var data in doctor_specialization)
                {
                    _context.Doctor_Specialization.Remove(data);
                }
                foreach (int data in doctor.SpecializationId)
                {
                    var _doctor_specialization = new Doctor_Specialization()
                    {
                        DoctorId = _doctor.Id,
                        SpecializationId = data
                    };
                    _context.Doctor_Specialization.Add(_doctor_specialization); 
                }
                _context.SaveChanges();
            };
        }

        public void DeleteDoctor(int doctorId)
        {
            var doctor = _context.Doctors.FirstOrDefault(n => n.Id == doctorId);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
        }
    }
}
