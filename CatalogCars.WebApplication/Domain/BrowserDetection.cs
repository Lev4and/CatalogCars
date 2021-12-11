namespace CatalogCars.WebApplication.Domain
{
    public static class BrowserDetection
    {
        public static bool DisallowsSameSiteNone(string userAgent)
        {
            if (string.IsNullOrEmpty(userAgent))
            {
                return true;
            }

            if (userAgent.Contains("CPU iPhone OS 12") || userAgent.Contains("iPad; CPU OS 12"))
            {
                return true;
            }

            if (userAgent.Contains("Macintosh; Intel Mac OS X 10_14") &&
                userAgent.Contains("Version/") && userAgent.Contains("Safari"))
            {
                return true;
            }

            if (userAgent.Contains("Chrome/5") || userAgent.Contains("Chrome/6"))
            {
                return true;
            }

            if (userAgent.Contains("UnrealEngine") && !userAgent.Contains("Chrome"))
            {
                return true;
            }

            return false;
        }

        public static bool AllowsSameSiteNone(string userAgent)
        {
            return !DisallowsSameSiteNone(userAgent);
        }
    }
}
