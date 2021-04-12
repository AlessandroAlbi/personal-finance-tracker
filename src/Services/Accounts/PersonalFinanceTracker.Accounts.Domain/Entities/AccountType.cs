using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceTracker.Accounts.Domain.Entities
{
    [Table("AccountTypes")]
    public class AccountType
    {
        [Column("Id")]
        [Key]
        public long Id { get; set; }

        [Column("Name")]
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for Name is 100 characters.")]
        public string Name { get; set; }

        [Column("Description")]
        [MaxLength(500, ErrorMessage = "Maximum length for Description is 500 characters.")]
        public string Description { get; set; }
    }
}
