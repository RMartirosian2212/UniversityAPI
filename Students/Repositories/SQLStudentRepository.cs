using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Models.Repositories
{
    public class SQLStudentRepository : IRepository<Student>
    {
        private readonly StudentContext context;
        public SQLStudentRepository(StudentContext context) => this.context = context;

        public async Task<IEnumerable<Student>> Get()
        {
            return await context.Students.ToListAsync();
        }

        public async Task<Student> Get(int id)
        {
            return await context.Students.FindAsync(id);
        }

        public async Task<Student> Post(Student student)
        {
            await context.AddAsync(student);
            return student;
        }

        public async Task<Student> Put(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return student;
                
        }
        public async Task Delete(int id)
        {
            var student = await context.Students.FirstOrDefaultAsync(b => b.Id == id);
            if (student != null)
            {
                context.Remove(student);
            }

        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

    }
}
