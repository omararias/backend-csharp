using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectAPI.Models
{
    public class Beer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandId { get; set; }

        [ForeignKey("BrandId")]

        public virtual Brand Brand { get; set; }

        [Column (TypeName = "decimal(18,2)")]
        public decimal Alcohol { get; set; }

    }
}
