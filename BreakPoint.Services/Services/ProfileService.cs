namespace BreakPoint.Services.Services
{
    using BreakPoint.Models.ViewModels.Profile;
    using BreakPoint.Services.Interfaces;
    using BreakPoint.Data;
    using System.Linq;
    using AutoMapper;
    using BreakPoint.Data.EntityModels;
    using System.Data.Entity.Migrations;
    using BreakPoint.Models.BindingModels.Post;
    using System;
    using System.Data.Entity;
    using System.IO;

    public class ProfileService : Service, IProfileService
    {
        public ProfileService(BreakPointDBContext context)
            : base(context)
        {
        }

        public void ChangeProfileAvatar(byte[] avatarBase64, string currentUserId)
        {
            var currentUser = this.Context.Users.Where(user => user.Id == currentUserId).First();
            currentUser.Avatar = avatarBase64;

            this.Context.Users.AddOrUpdate(currentUser);
            this.Context.SaveChanges();
        }

        public void CreateNewPost(string currentUserId, string filePath, CreateNewPostBindingModel bm)
        {
            var currentUser = this.Context.Users.Where(user => user.Id == currentUserId).First();

            Post newPost = new Post();
            newPost.Date = DateTime.Now;
            newPost.Location = bm.Location;
            newPost.Description = bm.Description;
            newPost.SourcePath = filePath;

            currentUser.Posts.Add(newPost);
            this.Context.SaveChanges();
        }

        public UserProfileViewModel GetProfileByCurrentUserId(string currentUserId)
        {
            var currentUser = this.Context
                .Users
                .Include(user => user.Posts)
                .Where(user => user.Id == currentUserId)
                .First();

            foreach (var post in currentUser.Posts)
            {
                post.Author = null;
                post.SourcePath = Convert.ToBase64String(File.ReadAllBytes(post.SourcePath));
            }

            var viewModel = Mapper.Map<AuthenticationUser, UserProfileViewModel>(currentUser);
            viewModel.FollowersCount = currentUser.Followers.Count();
            viewModel.PostsCount = currentUser.Posts.Count();

            return viewModel;
        }
    }
}
