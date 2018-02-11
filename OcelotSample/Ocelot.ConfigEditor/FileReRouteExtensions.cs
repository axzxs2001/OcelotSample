using Ocelot.Configuration.File;

namespace Ocelot.ConfigEditor
{
    public static class FileReRouteExtensions
    {
        public static string GetId(this FileReRoute fileReRoute)
        {
            return fileReRoute == null
                       ? string.Empty
                       : $"{fileReRoute.DownstreamScheme}{fileReRoute.DownstreamHostAndPorts[0].Host}:{fileReRoute.DownstreamHostAndPorts[0].Port}{fileReRoute.DownstreamPathTemplate}"
                           .Replace('/', '_');
        }
    }
}