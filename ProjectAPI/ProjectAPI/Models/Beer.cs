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

        public string BrandId { get; set; }

        [ForeignKey("BrandId")]

        public virtual Brand Brand { get; set; }
    }
}
