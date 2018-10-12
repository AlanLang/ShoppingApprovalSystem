using System.ComponentModel.DataAnnotations;

namespace ShoppingApprovalSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}