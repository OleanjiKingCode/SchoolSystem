using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSystem.ViewModel.Lecturers;

namespace SchoolSystem.Interfaces
{
     public interface ILecturerRepository
    {
        Task<bool> CreateLecturerAsync(CreateLecturerVM lecturerVM);
        Task<bool> UpdateLecturerAsync(UpdateVM update);
        Task<bool> DeleteLecturerAsync(int doctorId);
        Task<List<LecturerVM>> GetAllLecturersAsync();
        Task<LecturerVM> GetLecturerByIdAsync(int doctorId);
    }
}
