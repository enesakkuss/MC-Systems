using McSystems.DataAccess;
using McSystems.DataAccess.Entities;
using McSystems.Employees;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace McSystems.Business
{
    public class EmployeeService
    {
        public EmployeeDto? GetById(int id)
        {
            var context = new McSystemsContext();

            try
            {
                return context.Employees
                    .Select(e => new EmployeeDto
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Gender = e.Gender,
                        DateOfBirth = e.DateOfBirth,
                        HireDate = e.HireDate,
                    })
                    .FirstOrDefault(e => e.Id == id);
            }
            catch (Exception)
            {
                return null;
            }



            //try
            //{
            //    var employee = context.Employees.Find(id);
            //    if (employee != null) 
            //    {
            //        return new EmployeeDto()
            //        {
            //            Id = employee.Id,
            //            FirstName = employee.FirstName,
            //            LastName = employee.LastName,
            //            Gender = employee.Gender,
            //            DateOfBirth = employee.DateOfBirth,
            //            HireDate = employee.HireDate,
            //        };
            //    }
            //    else
            //    {
            //        return default;
            //    }
            //}
            //catch (Exception)
            //{
            //    return default;
            //}
        }

        public List<EmployeeDto> GetAll() 
        {
            var context = new McSystemsContext();
            try
            {
                return context.Employees
                    .Select(MapToDto)
                    .ToList();
            }
            catch (Exception)
            {
                return new List<EmployeeDto>();
            }
        }


        public CommandResult Add(EmployeeDto employee)
        {
            var context = new McSystemsContext();
            try
            {
                context.Employees.Add(new Employee
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Gender = employee.Gender,
                    DateOfBirth = employee.DateOfBirth,
                    HireDate = employee.HireDate
                });
                context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex);
            }
        }

        public CommandResult Update(EmployeeDto employeeDto)
        {
            var context = new McSystemsContext();
            var entity= MapToEntity(employeeDto);
            try
            {
                context.Employees.Update(entity);
                context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex);
            }
        }
        public CommandResult Delete(EmployeeDto employeeDto) 
        {
            var context = new McSystemsContext();
            var entity= MapToEntity(employeeDto);
            try
            {
                context.Employees.Remove(entity);
                context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex);
            }
        } 

        private static EmployeeDto MapToDto(Employee employee)
        {
            return new EmployeeDto()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                DateOfBirth = employee.DateOfBirth,
                HireDate = employee.HireDate,
            };
        }
        private static Employee MapToEntity(EmployeeDto employeeDto)
        {
            return new Employee()
            {
                Id = employeeDto.Id,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Gender = employeeDto.Gender,
                DateOfBirth = employeeDto.DateOfBirth,
                HireDate = employeeDto.HireDate,
            };
        }
    }
}
