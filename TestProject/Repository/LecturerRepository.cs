using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Interfaces;
using SchoolSystem.Models;
using SchoolSystem.ViewModel.Lecturers;

namespace SchoolSystem.Repository
{
    public class LecturerRepository: ILecturerRepository
    {
        private readonly ApplicationDbContext _context;
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;

        public LecturerRepository(ApplicationDbContext context)
        {
            _context = context;
            //_userManager = userManager;
            //_signInManager = signInManager;
        }

        public async Task<bool> CreateLecturerAsync(CreateLecturerVM lecturerVM)
        {
            try
            {
                var lecturer = new Lecturer
                {
                    LecturerName = lecturerVM.LecturerName,
                   
                    PhoneNumber = lecturerVM.PhoneNumber,
                   
                    Email = lecturerVM.Email,
                    

                };
                await _context.Lecturers.AddAsync(lecturer);
                var response = await _context.SaveChangesAsync();

                //var newuser = new ApplicationUser
                //{
                //    FullName = doctor.DoctorName,
                //    Email = doctor.Email,
                //    UserName = doctor.Email,
                //    EmailConfirmed = true
                //};
                //var password = "Password";
                //var result = await _userManager.CreateAsync(newuser, password);
                //if (result.Succeeded)
                //{
                //    await _userManager.AddToRoleAsync(newuser, "Doctor");

                //}
                return response > 0 ? true : false;
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public Task<bool> DeleteLecturerAsync(int doctorId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LecturerVM>> GetAllLecturersAsync()
        {
            var lecturer = await _context.Lecturers
                .Select(c => new LecturerVM
                 {
                    LecturerName= c.LecturerName,
                  
                    Id = c.Id,  
                     PhoneNumber = c.PhoneNumber,
                     Email= c.Email,


                 }).ToListAsync();
            return lecturer;
        }

        public async Task<LecturerVM> GetLecturerByIdAsync(int lecturerId)
        {
            var lecturer = await _context.Lecturers.FirstOrDefaultAsync(c => c.Id == lecturerId);
            if (lecturer == null)
            {
                return null;
            }
            return new LecturerVM
            {
                LecturerName = lecturer.LecturerName,
              
                Id = lecturer.Id,
                PhoneNumber = lecturer.PhoneNumber,
                Email = lecturer.Email,
              
            };
        }

        public Task<bool> UpdateLecturerAsync(UpdateVM update)
        {
            throw new NotImplementedException();
        }
    }
}

