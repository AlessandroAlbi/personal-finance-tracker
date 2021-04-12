using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceTracker.Accounts.Domain.Entities
{
    [Table("Accounts")]
    public class Account
    {
        [Column("Id")]
        [Key]
        public long Id { get; set; }

        [Column("UserGuid")]
        [Required(ErrorMessage = "UserGuid is a required field.")]
        public Guid UserGuid { get; set; }

        [Column("Name")]
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for Name is 100 characters.")]
        public string Name { get; set; }

        [Column("Description")]
        [MaxLength(500, ErrorMessage = "Maximum length for Description is 500 characters.")]
        public string Description { get; set; }

        [Column("AccountTypeId")]
        [Required(ErrorMessage = "AccountType is a required field.")]
        [ForeignKey(nameof(AccountType))]
        public long AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
    }
}
