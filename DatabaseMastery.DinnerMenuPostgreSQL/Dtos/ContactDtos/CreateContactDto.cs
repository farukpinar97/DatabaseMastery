using System.ComponentModel.DataAnnotations;

namespace DatabaseMastery.DinnerMenuPostgreSQL.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta giriniz.")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Konu zorunludur.")]
        [MaxLength(200)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj zorunludur.")]
        [MaxLength(1000)]
        public string Message { get; set; }
    }
}