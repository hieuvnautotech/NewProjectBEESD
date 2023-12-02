using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NewProjectESDBETL.Models.Dtos.Common
{
    public class UserDto: BaseModel
    {
        public long userId { get; set; }
        [StringLength(100)] // validate trong model
        [Unicode(false)]
        public string? userName { get; set; }

        [StringLength(100)]
        public string? userPassword { get; set; }

        [StringLength(100)]
        public string? newPassword { get; set; }

        [Precision(3)]
        public DateTime? lastLoginOnApp { get; set; }

        // Role list
        public IEnumerable<RoleDto>? Roles { get; set; }
        public IEnumerable<string>? RoleNames { get; set; }
        public string? RoleNameList { get; set; }

        /// <summary>
        /// UserPermission
        /// </summary>
        public IEnumerable<string>? PermissionNames { get; set; }

        //Menu list
        public IEnumerable<MenuDto>? Menus { get; set; }
        //Menu Tree
        public IEnumerable<MenuTreeDto>? MenuTree { get; set; }

        //token
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
