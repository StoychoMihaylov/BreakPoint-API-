namespace BreakPoint.Data.EntityModels
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class AuthenticationUser : IdentityUser
    {
        public AuthenticationUser()
        {
            this.Posts = new HashSet<Post>();
            this.PostComments = new HashSet<PostComment>();
            this.PostCommentReplies = new HashSet<PostCommentReply>();
            this.Followers = new HashSet<AuthenticationUser>();
        }

        public byte[] Avatar { get; set; }

        [MaxLength(50)]
        public string Nickname { get; set; }

        public string Location { get; set; }

        public string DancerType { get; set; }

        public string Gender { get; set; }

        public string Biography { get; set; }

        public long Skilled { get; set; }

        [ForeignKey("Followers")]
        public string FollowerId { get; set; }

        public virtual ICollection<AuthenticationUser> Followers { get; set; }

        [ForeignKey("Posts")]
        public int PostId { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        [ForeignKey("PostComments")]
        public int PostCommentId { get; set; }

        public virtual ICollection<PostComment> PostComments { get; set; }

        [ForeignKey("PostCommentReplies")]
        public int PostCommentReplyId { get; set; }

        public virtual ICollection<PostCommentReply> PostCommentReplies { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AuthenticationUser> manager,
            string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}
