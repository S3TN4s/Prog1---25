using Modelo;

namespace Repository
{
    public class AddressRepository
    {
        public Address Retrieve(int id)
        {
            foreach (Address endereco in AddressData.Addresses)
            {
                if (endereco.Id == id)
                {
                    return endereco;
                }
            }
            return null!;
        }
        public List<Address> RetrieveAll()
        {
            return AddressData.Addresses;
        }

        public void Save(Address address)
        {
            address.Id = AddressData.Addresses.Count + 1;
            AddressData.Addresses.Add(address);
        }
        public bool Delete(Address address)
        {
            return AddressData.Addresses.Remove(address);
        }

        public bool DeleteById(int id)
        {
            foreach (Address address in AddressData.Addresses)
            {
                if (address.Id == id)
                {
                    return AddressData.Addresses.Remove(address);
                }
            }
            return false;
        }
        public void Update(Address newAddress)
        {
            Address oldAddress = Retrieve(newAddress.Id);
            oldAddress.Street = newAddress.Street;
            oldAddress.Number = newAddress.Number;
            oldAddress.City = newAddress.City;
            oldAddress.State = newAddress.State;
            oldAddress.PostalCode = newAddress.PostalCode;
            oldAddress.Country = newAddress.Country;
            oldAddress.AddressType = newAddress.AddressType;
        }
    }
}
