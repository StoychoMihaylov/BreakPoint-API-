namespace BreakPoint.Data
{
    using BreakPoint.Data.EntityModels;
    using BreakPoint.Data.Interfaces;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class BreakPointDBContext : IdentityDbContext<AuthenticationUser>, IBreakPointDBContext
    {
        public BreakPointDBContext()
            : base("name=BreakPointDB")
        {
        }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<PostComment> PostComments { get; set; }

        public IDbSet<PostCommentReply> PostCommentReplies { get; set; }

        public static BreakPointDBContext Create()
        {
            return new BreakPointDBContext();
        }
    }
}