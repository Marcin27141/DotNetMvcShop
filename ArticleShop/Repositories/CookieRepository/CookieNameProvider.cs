using System.Security.Claims;

namespace ArticleShop.Repositories.CookieRepository
{
    public class CookieNameProvider : ICookieNameProvider
    {
        private const string NO_USER_PREFIX = "all";
        
        public string GetCookieNameForUser(string key, ClaimsPrincipal? user)
        {
            var userId = GetUserIdentifier(user);
            return userId != null ? $"{userId}_{key}" : $"{NO_USER_PREFIX}_{key}";
        }

        public string GetKeyFromCookie(string cookie, ClaimsPrincipal? user)
        {
            return cookie.Split("_")[^1];
        }

        public bool IsCookieBelongingToUser(string cookie, ClaimsPrincipal? user)
        {
            var userPart = cookie.Split("_")[0];
            var userId = GetUserIdentifier(user);
            return userPart == userId || (userId == null && userPart.Equals(NO_USER_PREFIX));
        }

        private static string? GetUserIdentifier(ClaimsPrincipal? user)
            => user?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
