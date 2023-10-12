using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HeathProject.Models
{
    [Table("QuarantinePlace")]
    [Index(nameof(AddressId), Name = "IX_QuarantinePlace_addressId")]
    [Index(nameof(UserId), Name = "QuarantinePlace_User_userId_fk")]
    public partial class QuarantinePlace
    {
        [Key]
        [Column("placeId")]
        public int PlaceId { get; set; }
        [Column("addressId")]
        public int AddressId { get; set; }
        [Column("roomNo")]
        public int RoomNo { get; set; }
      
        [Column("description")]
        public string Description { get; set; }
        [Column("userId")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("QuarantinePlaces")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("QuarantinePlaces")]
        public virtual User User { get; set; }
    }
}
