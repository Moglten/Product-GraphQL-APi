using Microsoft.EntityFrameworkCore;
using Product_GraphQL_APi.Data.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_GraphQL_APi.Repository
{
    public class EmployeeRepository
    {
        private readonly NORTHWNDContext _dbContext;

        public EmployeeRepository(NORTHWNDContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> GetheEmp(int EmpId)
        {
            return await _dbContext.Employees.Where(or => or.EmployeeId == EmpId).SingleOrDefaultAsync();
        }

        public async Task<ILookup<int, Employee>> GetforEmp(IEnumerable<int> EmpId)
        {
            var details = await _dbContext.Employees.Where(o => EmpId.Contains(o.EmployeeId)).ToListAsync();

            return details.ToLookup(d => d.EmployeeId);
        }

        public async Task<Employee> AddEmp(Employee newEmp)
        {
            newEmp.BirthDate = DateTime.Now;
            newEmp.HireDate = DateTime.Now;
            _dbContext.Employees.Add(newEmp);
            await _dbContext.SaveChangesAsync();
            return newEmp;
        }

        public async Task<Employee> UpdateEmp(Employee newEmp)
        {
            newEmp.BirthDate = DateTime.Now;
            newEmp.HireDate = DateTime.Now;
            _dbContext.Employees.Update(newEmp);
            await _dbContext.SaveChangesAsync();
            return newEmp;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetOne(int id)
        {
            return await _dbContext.Employees.Where(emp => emp.EmployeeId == id).SingleOrDefaultAsync();
        }

        public void DeleteEmp(int EmpId)
        {
            _dbContext.Employees.Remove(_dbContext.Employees.Find(EmpId));
            _dbContext.SaveChangesAsync();
        }
    }
}
