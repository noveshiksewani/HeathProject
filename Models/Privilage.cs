using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HeathProject.Models
{
    [Index(nameof(UserId), Name = "IX_Privilages_userId")]
    public partial class Privilage
    {
        [Key]
        [Column("minitreeId")]
        public int MinitreeId { get; set; }
      
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Column("userId")]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Privilages")]
        public virtual User User { get; set; }
    }
}
