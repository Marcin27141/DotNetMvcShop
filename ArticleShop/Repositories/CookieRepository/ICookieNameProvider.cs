using System.Security.Claims;

namespace ArticleShop.Repositories.CookieRepository
{
    public interface ICookieNameProvider
    {
        string GetCookieNameForUser(string key, ClaimsPrincipal? user);
        string GetKeyFromCookie(string cookie, ClaimsPrincipal? user);
        bool IsCookieBelongingToUser(string cookie, ClaimsPrincipal? user);
    }
}
