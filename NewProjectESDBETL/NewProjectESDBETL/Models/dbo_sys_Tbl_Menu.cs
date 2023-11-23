﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NewProjectESDBETL.Models
{
    [Keyless]
    [Table("dbo.sys Tbl_Menu")]
    public partial class dbo_sys_Tbl_Menu
    {
        public long menuId { get; set; }
        public long? parentId { get; set; }
        [StringLength(100)]
        public string menuName { get; set; }
        public byte? menuLevel { get; set; }
        public byte? sortOrder { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string menuIcon { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string languageKey { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string menuComponent { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string navigateUrl { get; set; }
        public bool forRoot { get; set; }
        public bool? forApp { get; set; }
        public bool? isTab { get; set; }
        public bool isActived { get; set; }
        [Precision(3)]
        public DateTime createdDate { get; set; }
        public long createdBy { get; set; }
        [Precision(3)]
        public DateTime? modifiedDate { get; set; }
        public long? modifiedBy { get; set; }
        public byte[] row_version { get; set; }
    }
}