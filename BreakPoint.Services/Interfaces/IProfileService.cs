namespace BreakPoint.Services.Interfaces
{
    using BreakPoint.Models.BindingModels.Post;
    using BreakPoint.Models.ViewModels.Profile;

    public interface IProfileService
    {
        UserProfileViewModel GetProfileByCurrentUserId(string currentUserId);

        void ChangeProfileAvatar(byte[] avatarBase64, string currentUserId);

        void CreateNewPost(string currentUserId, string filePath, CreateNewPostBindingModel bm);
    }
}