using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDOpdracht.Models.DTO
{
    public class CreateArticleRequestDto
    {
        public string Sku { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
