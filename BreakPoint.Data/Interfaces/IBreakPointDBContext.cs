using BreakPoint.Data.EntityModels;
using System.Data.Entity;

namespace BreakPoint.Data.Interfaces
{
    public interface IBreakPointDBContext
    {
        IDbSet<Post> Posts { get; set; }

        IDbSet<PostComment> PostComments { get; set; }

        IDbSet<PostCommentReply> PostCommentReplies { get; set; }

        int SaveChanges();
    }
}
