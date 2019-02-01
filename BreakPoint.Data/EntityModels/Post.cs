namespace BreakPoint.Data.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<PostComment>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public long Likes { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string SourcePath { get; set; }

        public byte[] ImageSource { get; set; }

        public string Location { get; set; }

        public virtual AuthenticationUser Author { get; set; }

        [ForeignKey("Comments")]
        public int CommentId { get; set; }

        public virtual ICollection<PostComment> Comments { get; set; }
    }
}