﻿using System.ComponentModel.DataAnnotations;

namespace NewProjectESDBETL.Models.Dtos.Common
{
    public class PermissionDto: BaseModel
    {
        public long permissionId { get; set; }
        [StringLength(50)]
        public string? permissionCode { get; set; } = default;
        public string? permissionName { get; set; } = default;

        public long? menuId { get; set; }= default;
        public string? menuName { get; set; }=default;
        public bool? isBase { get; set; } = default;
        public bool forRoot { get; set; } = true;
    }
}
