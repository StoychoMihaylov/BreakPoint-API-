namespace BreakPoint.Data.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PostCommentReply
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public long Likes { get; set; }

        [ForeignKey("Comment")]
        public int CommentId { get; set; }

        public virtual PostComment Comment { get; set; }

        public virtual AuthenticationUser Author { get; set; }
    }
}
