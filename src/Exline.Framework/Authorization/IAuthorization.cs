namespace Exline.Framework.Authorization
{
    public interface IAuthorization
    {
        AuthUser GetUserInfo(string accessToken);
    }
}