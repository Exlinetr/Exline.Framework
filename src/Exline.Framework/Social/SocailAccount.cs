using System;
using System.Linq;

namespace Exline.Framework.Social
{
    public class SocailAccount
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string ProfilePhoto { get; set; }

        public SocailAccount()
        {

        }
        internal SocailAccount(Facebook.Models.Api.MeResponseModel fbMe)
            : this()
        {
            this.Id = fbMe.Id;
            this.Username = string.Empty;
            this.Email = fbMe.Email;
            this.Name = fbMe.FirstName;
            this.Surname = fbMe.LastName;
            if (!string.IsNullOrEmpty(fbMe.Birthday))
                this.Birthday = DateTime.Parse(fbMe.Birthday);
            if (fbMe.AgeRange != null)
                this.Age = fbMe.AgeRange.Min;
            if(fbMe.Picture!=null && fbMe.Picture.Image!=null)
                this.ProfilePhoto=fbMe.Picture.Image.Url;
        }

        internal SocailAccount(Google.Models.Api.MeResponseModel googleMe)
        {
            this.Id = googleMe.Id;
            this.Username = string.Empty;
            this.Email = googleMe.Emails.FirstOrDefault(x=>x.Type=="account").Mail;
            this.Name = googleMe.Name.Name;
            this.Surname = googleMe.Name.Surname;
            if (!string.IsNullOrEmpty(googleMe.Birthday))
                this.Birthday = DateTime.Parse(googleMe.Birthday);
            if(googleMe.Image!=null && googleMe.Image.Url!=null)
                this.ProfilePhoto=googleMe.Image.Url;
        }
    }
}