using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Repository
{
    internal class AddressRepository
    {
        public Address Retrieve()
        {
            return new Address();
        }
        public void Save(Address address)
        {
            Console.WriteLine("Persistir");
        }
    }
}
