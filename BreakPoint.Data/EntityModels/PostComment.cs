namespace BreakPoint.Data.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PostComment
    {
        public PostComment()
        {
            this.Replies = new HashSet<PostCommentReply>();
        }

        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public long Likes { get; set; }

        [ForeignKey("Replies")]
        public int ReplyId { get; set; }

        public virtual ICollection<PostCommentReply> Replies { get; set; }

        public virtual AuthenticationUser Author { get; set; }
    }
}
