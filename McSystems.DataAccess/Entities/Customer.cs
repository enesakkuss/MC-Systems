﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystems.DataAccess.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAdress { get; set; }
        public int CountryId { get; set; }
        
        //Navigation Property
        public Country Country { get; set; }
        public ICollection<Reservation> Reservations { get; set; }


    }
}
