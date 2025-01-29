using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPI.Models
{
    public class Brand
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BrandId { get; set; }

        public string Name { get; set; }



    }
}
