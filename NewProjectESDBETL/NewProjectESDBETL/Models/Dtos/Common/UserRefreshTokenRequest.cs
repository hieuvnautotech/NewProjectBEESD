using System.ComponentModel.DataAnnotations;

namespace NewProjectESDBETL.Models.Dtos.Common
{
    public class UserRefreshTokenRequest
    {
        [Required]
        public string? expiredToken { get; set; }
        [Required]
        public string? refreshToken { get; set; }
        public string? ipAddress { get; set; }
    }
}
