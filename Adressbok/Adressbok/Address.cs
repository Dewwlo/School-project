using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok
{
    public class Address
    {

        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid Id { get; set; }

        public Address(string name,string street, string zip, string city, string email, string phonenumber, Guid id)
        {
            Name = name;
            StreetAddress = street;
            Zip = zip;
            City = city;
            Email = email;
            PhoneNumber = phonenumber;
            Id = id;

        }
    }
}
