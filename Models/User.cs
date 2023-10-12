using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HeathProject.Models
{
    [Table("User")]
    [Index(nameof(AddressId), Name = "IX_User_addressId")]
    [Index(nameof(Email), Name = "User_email_uindex", IsUnique = true)]
    [Index(nameof(Phone), Name = "User_phone_uindex", IsUnique = true)]
    [Index(nameof(UserName), Name = "User_userName_uindex", IsUnique = true)]
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Donations = new HashSet<Donation>();
            Foods = new HashSet<Food>();
            Money = new HashSet<Money>();
            Oxygens = new HashSet<Oxygen>();
            Plasmas = new HashSet<Plasma>();
            Posts = new HashSet<Post>();
            Privilages = new HashSet<Privilage>();
            QuarantinePlaces = new HashSet<QuarantinePlace>();
        }

        [Key]
        [Column("userId")]
        public int UserId { get; set; }
        [Column("userName")]
        [StringLength(20)]
        public string UserName { get; set; }
        [Column("email")]
        [StringLength(20)]
        public string Email { get; set; }
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Column("role")]
        [StringLength(10)]
        public string Role { get; set; }
        [Column("addressId")]
        public int AddressId { get; set; }
        [Column("phone")]
        public long Phone { get; set; }
        [Column("gender")]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column("name")]
        [StringLength(60)]
        public string Name { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Users")]
        public virtual Address Address { get; set; }
        [InverseProperty(nameof(Comment.User))]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty(nameof(Donation.User))]
        public virtual ICollection<Donation> Donations { get; set; }
        [InverseProperty(nameof(Food.User))]
        public virtual ICollection<Food> Foods { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Money> Money { get; set; }
        [InverseProperty(nameof(Oxygen.User))]
        public virtual ICollection<Oxygen> Oxygens { get; set; }
        [InverseProperty(nameof(Plasma.User))]
        public virtual ICollection<Plasma> Plasmas { get; set; }
        [InverseProperty(nameof(Post.User))]
        public virtual ICollection<Post> Posts { get; set; }
        [InverseProperty(nameof(Privilage.User))]
        public virtual ICollection<Privilage> Privilages { get; set; }
        [InverseProperty(nameof(QuarantinePlace.User))]
        public virtual ICollection<QuarantinePlace> QuarantinePlaces { get; set; }
    }
}
