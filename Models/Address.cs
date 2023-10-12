using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HeathProject.Models
{
    [Table("Address")]
    public partial class Address
    {
        public Address()
        {
            QuarantinePlaces = new HashSet<QuarantinePlace>();
            Users = new HashSet<User>();
        }

        [Key]
        [Column("addressId")]
        public int AddressId { get; set; }
       
        [Column("state")]
        [StringLength(20)]
        public string State { get; set; }
       
        [Column("street")]
        [StringLength(100)]
        public string Street { get; set; }
       
        [Column("city")]
        [StringLength(20)]
        public string City { get; set; }
        [Column("pincode")]
        public int Pincode { get; set; }

        [InverseProperty(nameof(QuarantinePlace.Address))]
        public virtual ICollection<QuarantinePlace> QuarantinePlaces { get; set; }
        [InverseProperty(nameof(User.Address))]
        public virtual ICollection<User> Users { get; set; }
    }
}
