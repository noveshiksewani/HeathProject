using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HeathProject.Models
{
    [Table("Plasma")]
    [Index(nameof(UserId), Name = "Plasma_User_userId_fk")]
    public partial class Plasma
    {
        [Key]
        [Column("plasmaId")]
        public int PlasmaId { get; set; }
     
        [Column("bloodType")]
        [StringLength(20)]
        public string BloodType { get; set; }
        [Column("userId")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Plasmas")]
        public virtual User User { get; set; }
    }
}
