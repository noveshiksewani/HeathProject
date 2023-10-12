using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HeathProject.Models
{
    [Table("Donation")]
    [Index(nameof(UserId), Name = "IX_Donation_userId")]
    public partial class Donation
    {
        [Key]
        [Column("dontationId")]
        public int DontationId { get; set; }
       
        [Column("donationType")]
        [StringLength(50)]
        public string DonationType { get; set; }
        [Column("donationTypeId")]
        public int DonationTypeId { get; set; }
        [Column("userId")]
        public int UserId { get; set; }
        
        [Column("userType")]
        [StringLength(10)]
        public string UserType { get; set; }
        [Column("timeStamp", TypeName = "timestamp(6)")]
        public DateTime? TimeStamp { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Donations")]
        public virtual User User { get; set; }
    }
}
