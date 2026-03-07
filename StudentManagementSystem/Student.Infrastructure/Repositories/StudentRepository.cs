using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student.Application.Interfaces;
using Student.Domain.Entities;
using Student.Infrastructure.Data;

namespace Student.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;    
        }

        public async Task<IEnumerable<StudentModel>> GetAllAsync() => await _context.students.ToListAsync();

        public async Task<StudentModel> GetByIdAsync(int id) => await _context.students.SingleOrDefaultAsync();

        public async Task AddAsync(StudentModel student)
        {
            _context.students.Add(student);
            await _context.SaveChangesAsync();  
        }

        public async Task UpdateAsync(StudentModel student)
        {
            _context.students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.students.FindAsync(id);
            if (student != null)
            {
                _context.students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }


    }
}
