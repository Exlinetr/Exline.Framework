namespace Exline.Framework.Authorization.Facebook.Models.Api
{
    internal class MeResponseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public AgeRange AgeRange { get; set; }

    }
}