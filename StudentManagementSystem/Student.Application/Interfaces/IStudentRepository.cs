using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Domain.Entities;

namespace Student.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentModel>> GetAllAsync();
        Task<StudentModel?> GetByIdAsync(int id);
        Task AddAsync(StudentModel student);
        Task UpdateAsync(StudentModel student);
        Task DeleteAsync(int id);


    }
}
