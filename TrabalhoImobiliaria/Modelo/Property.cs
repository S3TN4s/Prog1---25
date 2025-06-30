using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Property
    {
        public int Id { get; set; }
        public int NroQuartos { get; set; }
        public int NroVagas { get; set; }
        public int NroBanheiros { get; set; }
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int CategoriaId { get; set; }
        public Category? Categoria { get; set; }
    }
}
