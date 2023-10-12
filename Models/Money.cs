using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HeathProject.Models
{
    [Index(nameof(UserId), Name = "IX_Money_userId")]
    public partial class Money
    {
        [Key]
        [Column("moneyId")]
        public int MoneyId { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("userId")]
        public int? UserId { get; set; }
        [Column("order_id")]
        [StringLength(50)]
        public string OrderId { get; set; }
        [Column("status")]
        public int Status { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Money")]
        public virtual User User { get; set; }
    }
}
