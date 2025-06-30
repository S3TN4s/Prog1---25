using Modelo;

namespace Repository
{
    public class CategoryRepository
    {
        public Category Retrieve(int id)
        {
            foreach (Category categoria in CategoryData.Categorias)
            {
                if (categoria.Id == id)
                {
                    return categoria;
                }
            }
            return null!;
        }

        public List<Category> RetrieveAll()
        {
            return CategoryData.Categorias;
        }

        public void Save(Category categoria)
        {
            categoria.Id = CategoryData.Categorias.Count + 1;
            CategoryData.Categorias.Add(categoria);
        }

        public bool Delete(Category categoria)
        {
            return CategoryData.Categorias.Remove(categoria);
        }

        public bool DeleteById(int id)
        {
            foreach (Category categoria in CategoryData.Categorias)
            {
                if (categoria.Id == id)
                {
                    return CategoryData.Categorias.Remove(categoria);
                }
            }
            return false;
        }

        public void Update(Category newCategoria)
        {
            Category oldCategoria = Retrieve(newCategoria.Id);
            oldCategoria.Name = newCategoria.Name;
        }
    }
}
