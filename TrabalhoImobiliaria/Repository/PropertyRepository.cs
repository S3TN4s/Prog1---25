using Modelo;

namespace Repository
{
    public class PropertyRepository
    {
        public Property Retrieve(int id)
        {
            foreach (Property imovel in PropertyData.Imoveis)
            {
                if (imovel.Id == id)
                {
                    return imovel;
                }
            }
            return null!;
        }

        public List<Property> RetrieveAll()
        {
            return PropertyData.Imoveis;
        }

        public void Save(Property imovel)
        {
            imovel.Id = PropertyData.Imoveis.Count + 1;
            PropertyData.Imoveis.Add(imovel);
        }

        public bool Delete(Property imovel) 
        {
            return PropertyData.Imoveis.Remove(imovel);
        }

        public bool DeleteById(int id)
        {
            foreach(Property imovel in PropertyData.Imoveis)
            {
                if(imovel.Id == id)
                {
                    return PropertyData.Imoveis.Remove(imovel);
                }
            }
            return false;
        }

        public void Update(Property newImovel)
        {
            Property oldImovel = Retrieve(newImovel.Id);
            oldImovel.NroQuartos = newImovel.NroQuartos;
            oldImovel.NroVagas = newImovel.NroVagas;
            oldImovel.NroBanheiros = newImovel.NroBanheiros;
            oldImovel.Address = newImovel.Address;
            oldImovel.Nome = newImovel.Nome;
            oldImovel.Descricao = newImovel.Descricao;
            oldImovel.Categoria = newImovel.Categoria;
        }
    }
}
