using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIForAutomation.Api.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}
