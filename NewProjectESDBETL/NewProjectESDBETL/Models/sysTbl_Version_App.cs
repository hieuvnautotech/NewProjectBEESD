﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESD.Models
{
    public partial class sysTbl_Version_App
    {
        [Key]
        public int id_app { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string name_file { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string app_version { get; set; }
        [StringLength(500)]
        public string url { get; set; }
        public DateTime? change_date { get; set; }
        public long? createdBy { get; set; }
        public byte[] row_version { get; set; }
    }
}