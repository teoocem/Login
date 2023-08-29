using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login.Models
{
    [Table("Product", Schema = "dbo")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }

        public string? Description { get; set;}

        public float? Price { get;}
    }
}
