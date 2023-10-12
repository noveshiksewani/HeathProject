﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HeathProject.Models
{
    [Table("__EFMigrationsHistory")]
    public partial class EfmigrationsHistory
    {
        [Key]
        [StringLength(150)]
        public string MigrationId { get; set; }
     
        [StringLength(32)]
        public string ProductVersion { get; set; }
    }
}
