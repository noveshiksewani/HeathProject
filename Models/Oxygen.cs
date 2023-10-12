using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HeathProject.Models
{
    [Table("Oxygen")]
    [Index(nameof(UserId), Name = "Oxygen_User_userId_fk")]
    public partial class Oxygen
    {
        [Key]
        [Column("oxygenId")]
        public int OxygenId { get; set; }
      
        [Column("provider")]
        [StringLength(20)]
        public string Provider { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("userId")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Oxygens")]
        public virtual User User { get; set; }
    }
}
