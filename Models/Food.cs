using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HeathProject.Models
{
    [Table("Food")]
    [Index(nameof(UserId), Name = "Food_User_userId_fk")]
    public partial class Food
    {
        [Key]
        [Column("foodId")]
        public int FoodId { get; set; }
      
        [Column("description")]
        public string Description { get; set; }
        [Column("userId")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Foods")]
        public virtual User User { get; set; }
    }
}
