using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HeathProject.Models
{
    [Index(nameof(PostId), Name = "IX_Comments_postId")]
    [Index(nameof(UserId), Name = "IX_Comments_userId")]
    public partial class Comment
    {
        [Key]
        [Column("commentId")]
        public int CommentId { get; set; }
       
        [Column("commentText")]
        public string CommentText { get; set; }
        [Column("userId")]
        public int? UserId { get; set; }
        [Column("postId")]
        public int PostId { get; set; }
        [Column("timestamp", TypeName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        [ForeignKey(nameof(PostId))]
        [InverseProperty("Comments")]
        public virtual Post Post { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Comments")]
        public virtual User User { get; set; }
    }
}
