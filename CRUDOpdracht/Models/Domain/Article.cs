using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDOpdracht.Models.Domain
{
    public class Article
    {
        public Guid Id { get; set; }

        public string Sku { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }


    }
}
