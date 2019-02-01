namespace BreakPoint.Models.ViewModels.Profile
{
    using System.Collections.Generic;
    using BreakPoint.Data.EntityModels;

    public class UserProfileViewModel
    {
        public byte[] Avatar { get; set; }

        public string Email { get; set; }

        public string Nickname { get; set; }

        public string Location { get; set; }

        public string DancerType { get; set; }

        public string Style { get; set; }

        public string Gender { get; set; }

        public string Biography { get; set; }

        public long Skilled { get; set; }

        public long FollowersCount { get; set; }

        public int PostsCount { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
