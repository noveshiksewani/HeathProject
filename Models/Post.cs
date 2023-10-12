using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HeathProject.Models
{
    [Table("Post")]
    [Index(nameof(UserId), Name = "IX_Post_userId")]
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        [Column("postId")]
        public int PostId { get; set; }
        [Column("imageUrl")]
        public string ImageUrl { get; set; }
     
        [Column("description")]
        public string Description { get; set; }
        [Column("userId")]
        public int UserId { get; set; }
        [Column("timestamp", TypeName = "timestamp(6)")]
        public DateTime Timestamp { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Posts")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Comment.Post))]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
