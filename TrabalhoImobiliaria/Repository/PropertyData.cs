using Modelo;

namespace Repository
{
    public class PropertyData
    {
        public static List<Property> Imoveis { get; set; } = [];
        public static List<Category> Categorias { get; set; } = [];
        public static List<Address> Enderecos { get; set; } = [];
    }
}
