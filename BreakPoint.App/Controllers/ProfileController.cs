namespace BreakPoint.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Http;
    using BreakPoint.Models.BindingModels.Post;
    using BreakPoint.Models.BindingModels.Profile;
    using BreakPoint.Services.Interfaces;
    using Microsoft.AspNet.Identity;

    [RoutePrefix("api/profile")]
    public class ProfileController : ApiController
    {
        private IProfileService service;

        public ProfileController() { }

        public ProfileController(IProfileService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Change Profile Avatar
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ChangeProfileAvatar")]
        public IHttpActionResult ChangeProfileAvatar([FromBody] AvatarBindingModel stringAvatar)
        {

            if (stringAvatar.stringBase64 != null && stringAvatar.stringBase64.Length > 10)
            {
                var currentUserId = User.Identity.GetUserId();
                if (currentUserId == null)
                {
                    return BadRequest();
                }
                var avatarBase64 = Convert.FromBase64String(stringAvatar.stringBase64);
                this.service.ChangeProfileAvatar(avatarBase64, currentUserId);
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        /// <summary>
        /// Get the detailed profile information
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserInfo")]
        public IHttpActionResult GetUserInfo()
        {
            var token = this.Request.Headers.Authorization;

            if (token == null)
            {
                return BadRequest();
            }

            var currentUserId = User.Identity.GetUserId();

            if (currentUserId == null)
            {
                return NotFound();
            }

            var currentUserProfile = this.service.GetProfileByCurrentUserId(currentUserId);

            return this.Ok(currentUserProfile);
        }


        [HttpPost]
        [Route("UploadImagePost")]
        public IHttpActionResult UploadImageToNewPost()
        {
            var httpRequest = HttpContext.Current.Request;
            CreateNewPostBindingModel bidingModel = new CreateNewPostBindingModel
            {
                Location = httpRequest.Headers["location"],
                Description = httpRequest.Headers["description"]
            };

            if (httpRequest.Files.Count != 0)
            {
                var currentUserId = User.Identity.GetUserId();


                Guid guid = Guid.NewGuid();
                string guidId = guid.ToString();
                int postId = -1;

                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath($"~/PostImages/{guidId}_{postedFile.FileName}");
                    postedFile.SaveAs(filePath);
                    this.service.CreateNewPost(currentUserId, filePath, bidingModel);
                }


                return Ok(postId);
            }

            return BadRequest();
        }
    }
}
