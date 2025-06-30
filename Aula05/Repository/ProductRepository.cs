using Modelo;

namespace Repository
{
    public class ProductRepository
    {
        public Product Retrieve(int id)
        {
            foreach (Product p in CustomerData.Products)
                if (p.Id == id)
                    return p;
            return null!;
        }
        public List<Product> RetrieveByName(string name)
        {
            List<Product> ret = new List<Product>();

            foreach (Product p in CustomerData.Products)
                if (p.Name!.ToLower().Contains(name.ToLower()))
                    ret.Add(p);

            return ret;
        }

        public List<Product> RetrieveAll()
        {
            return CustomerData.Products;
        }

        public void Update(Product newProduct)
        {
            Product oldProduct = Retrieve(newProduct.Id);
            oldProduct.Name = newProduct.Name;
            oldProduct.Description = newProduct.Description;
            oldProduct.CurrentPrice = newProduct.CurrentPrice;
        }

        public void Save(Product product)
        {
            product.Id = GetCount() + 1;
            CustomerData.Products.Add(product);
        }

        public bool Delete(Product product)
        {
            return CustomerData.Products.Remove(product);
        }

        public bool DeleteById(int id)
        {
            Product product = Retrieve(id);

            if (product != null)
                return Delete(product);

            return false;
        }

        public int GetCount()
        {
            return CustomerData.Products.Count;
        }
    }
}