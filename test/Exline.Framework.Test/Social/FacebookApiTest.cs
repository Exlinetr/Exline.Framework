using System.Collections.Generic;
using System.Threading.Tasks;
using Exline.Framework.Localization.Dictionaries;
using Exline.Framework.Localization.Dictionaries.JSON;
using Exline.Framework.Social;
using Exline.Framework.Social.Facebook;
using Xunit;

namespace Exline.Framework.Test.Localization.JSON
{
    public class FacebookApiTest
    {
        private readonly IFacebookApi _facebookApi;
        public FacebookApiTest()
        {
            _facebookApi=new FacebookApi(new FacebookApiConfig()
            {
                AppId = "150393275806457",
                SecretKey = "833430935a81b39a7bead95c387bece0"
            });
        }

        [Theory]
        [InlineData("EAACIyCnH8vkBANldHMZBzO2IJGMr0OvnfOA1YtBaimC4qOCo8q3dxIyj1Nn6v8jaxJwDYJj97e6fKkgO3EUFyHBSVaCiTZCJGkxbxN9KhZC8gR0SZBmzH0T1JMq1aYmGs3JisJK4ZCTqehWUwt4xR5ZApX2Cmj4jZCBAgB7Atimp7FZBkq1HBecHjSSH1GC66NnZA6r93E93q6wZDZD")]
        public void Initialize(string token)
        {
            var _scope=new List<string>()
            {
                "id",
                "name",
                "email",
                "last_name",
                "first_name"
            };
            Task.Run(async()=>{
                
                SocailAccount account= await _facebookApi.GetAccountAsync(token,_scope);

                Assert.NotNull(account);
                Assert.Equal(account.Id,"1708009809289288");
                Assert.Equal(account.Name,"Muhammet Furkan Doğan");
                Assert.Equal(account.Email,"dogan.furkan@msn.com");
                Assert.Equal(account.Name,"Muhammet Furkan");
                Assert.Equal(account.Surname,"Doğan");

            }).GetAwaiter().GetResult();
        }

    }
}