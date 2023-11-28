using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NewProjectESDBETL.Models.Dtos.Common
{
    public class LoginModelDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Unicode(false)]
        public string? Username { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Unicode(false)]
        public string? userPassword { get; set; }
        public bool? isOnApp { get; set; } = false;
        public LoginModelDto() { 
            isOnApp = false;
        }
    }
}
