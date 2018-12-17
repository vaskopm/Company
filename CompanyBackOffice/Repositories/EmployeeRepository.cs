using CompanyBackOffice.Models;
using CompanyBackOffice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBackOffice.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, Guid>
    {
        public EmployeeRepository(CompanyDbContext context) : base(context)
        {
        }

        public override void Add(Employee entity)
        {
            context.Employees.Add(entity);
        }

        public override Employee Get(Guid id)
        {
            return context.Employees.Find(id);
        }

        public override IEnumerable<Employee> GetAll()
        {
            return context.Employees;
        }

        public override void Remove(Employee entity)
        {
            context.Employees.Remove(entity);
        }

        internal IEnumerable<EmployeeVM> GetEmployees()
        {
            return GetAll().Select(e => (EmployeeVM)e);
        }

        public override void Save()
        {
            context.SaveChanges();
        }

        public override Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        internal void CreateEmployee(CreateEmployeeVM vm)
        {
            Employee employee = (Employee)vm;

            Add(employee);

            Save();
        }

        internal EmployeeVM GetEmployee(Guid id)
        {
            return Get(id);
        }

        internal void RemoveEmployee(Guid id)
        {
            Employee employee = Get(id);

            if(employee == null)
            {
                throw new NullReferenceException();
            }

            Remove(employee);

            Save();
        }
    }
}
