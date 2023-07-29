using McSystems.Customers;
using McSystems.DataAccess;
using McSystems.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystems.Business
{
    public class CustomerService
    {
        public List<CustomerDto>? GetAll()
        {
            var context = new McSystemsContext();
            try
            {
                return context.Customers.Select(MapToDto).ToList();
            }
            catch (Exception)
            {
                return new List<CustomerDto>();
            }
        }
        public CustomerDto? GetById(int id)
        {
            var context=new McSystemsContext();
            try
            {
                return context.Customers
                    .Select(e => new CustomerDto
                {
                    Id = e.Id,
                    EmailAdress = e.EmailAdress,
                    FirstName = e.FirstName,
                    Gender = e.Gender,
                    IdNumber = e.IdNumber,
                    LastName = e.LastName,
                    PhoneNumber = e.PhoneNumber,
                    CountryId= e.CountryId
                    
                })
                    .FirstOrDefault(e=>e.Id==id);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public CommandResult Add(CustomerDto customerDto)
        {
            var context = new McSystemsContext();
            try
            {
                context.Customers.Add(MapToEntity(customerDto));
                context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex);
            }
        }

        public CommandResult Delete(CustomerDto customerDto)
        {
            var context = new McSystemsContext();
            try
            {
                context.Customers.Remove(MapToEntity(customerDto));
                context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex);
            }
        }

        public CommandResult Update(CustomerDto customerDto) 
        {
            var context = new McSystemsContext();
            try
            {
                context.Customers.Update(MapToEntity(customerDto));
                context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex);
            }
        }

        public List<CustomerDto> SearcCustomer
            (string identityNumber,string firstName,string lastName)
        {
            var context=new McSystemsContext();

            var query = context.Customers.AsQueryable();

            if(!string.IsNullOrWhiteSpace(identityNumber))
            {
                query = from c in query
                        where (c.IdNumber.Contains(identityNumber))
                        select c;
            }
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                query = from c in query
                        where (c.FirstName.Contains(firstName))
                        select c;
            }
            if(!string.IsNullOrWhiteSpace(lastName))
            {
                query = from c in query
                        where (c.LastName.Contains(lastName))
                        select c;
            }
            return query
                .Select(c=>new CustomerDto()
                {
                    Id=c.Id,
                    FirstName=c.FirstName,
                    LastName=c.LastName,
                    IdNumber=c.IdNumber
                })
                .ToList();

            var query2 = context.Customers;
        }
        internal static CustomerDto MapToDto (Customer customer)
        {
            return new CustomerDto 
            {
                CountryId = customer.CountryId,
                EmailAdress = customer.EmailAdress,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Gender = customer.Gender,
                Id = customer.Id,
                IdNumber = customer.IdNumber,
                PhoneNumber = customer.PhoneNumber
            };

        }
        internal static Customer MapToEntity(CustomerDto customerDto)
        {
            return new Customer()
            {
                CountryId=customerDto.CountryId,
                EmailAdress=customerDto.EmailAdress,
                FirstName=customerDto.FirstName,
                LastName=customerDto.LastName,
                Gender=customerDto.Gender,
                Id=customerDto.Id,
                IdNumber=customerDto.IdNumber,
                PhoneNumber=customerDto.PhoneNumber
            };
        }
    }
}
