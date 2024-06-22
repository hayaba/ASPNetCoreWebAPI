using System.ComponentModel.DataAnnotations;

namespace kontaktpersoner.Data
{
    internal sealed class kontaktPerson
    {
        [Key]
        public int KontaktId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Navn { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address can't be longer than 200 characters")]
        public string Adresse { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Telefon { get; set; } = string.Empty;

    }
}
