using System.ComponentModel.DataAnnotations;

namespace DotnetNewWebapi.Config
{
    public class CApplicationOptions
    {
        public static string SectName = "Application";
        public string Name { get; set; }
        public string Version { get; set; }
    }

    public class CExternalApiOptions
    {
        public static string SectName = "ExternalApi";

        [Required]
        public string BaseUrl { get; set; }
        [Range(1,300)]
        public int TimeoutSeconds { get; set; }
        [Range(0,10)]
        public int RetryCount { get; set; }
    }
}
