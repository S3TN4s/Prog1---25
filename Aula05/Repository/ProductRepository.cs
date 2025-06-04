using Modelo;

namespace Repository
{
    public class ProductRepository
    {
        public Product Retrieve(int Id)
        {
            foreach (Product p in ProductData.Products)
            {
                if (p.Id == Id)
                    return p;
            }
            return null;
        }

        public List<Product> RetieveByName(string ProductName)
        {
            List<Product> ret = new List<Product>();

            foreach (Product c in ProductData.Products)
            {
                if (c.ProductName!.ToLower().Contains(ProductName.ToLower()))
                    ret.Add(c);
            }

            return ret;
        }

        public List<Product> RetrieveAll()
        {
            return ProductData.Products;
        }

        public void Save(Product products)
        {
            products.Id = GetCount() + 1;
            ProductData.Products.Add(products);
        }

        public bool Delete(Product products)
        {
            return ProductData.Products.Remove(products);
        }

        public bool DeleteById(int id)
        {
            Product products = Retrieve(id);

            if (products != null)
                return Delete(products);
            return false;
        }

        public void Update(Product newProducts)
        {
            Product oldProduct = Retrieve(newProducts.Id);
            oldProduct.ProductName = newProducts.ProductName;
            oldProduct.Description = newProducts.Description;
            oldProduct.CurrentPrice = newProducts.CurrentPrice;
        }

        public int GetCount()
        {
            return ProductData.Products.Count;
        }
    }
}
