using BreakPoint.Data.EntityModels;
using BreakPoint.Data.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BreakPoint.Data.Mocks
{
    public class FakeBreakPointDbContext : IdentityDbContext<AuthenticationUser>, IBreakPointDBContext
    {
        public FakeBreakPointDbContext()
        {
            this.Posts = new FakeDbSet<Post>();
            this.PostComments = new FakeDbSet<PostComment>();
            this.PostCommentReplies = new FakeDbSet<PostCommentReply>();
        }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<PostComment> PostComments { get; set; }

        public IDbSet<PostCommentReply> PostCommentReplies { get; set; }
    }
}
