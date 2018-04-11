﻿using Microsoft.Extensions.Configuration;
using Promitor.Scraper.Configuration;

namespace Promitor.Scraper.Scraping
{
    public static class ScrapeEndpoint
    {
        private const string DefaultScrapeEndpoint = "prometheus/scrape";

        /// <summary>
        ///     Determines the base path under which the scrape endpoint is configured to be exposed
        /// </summary>
        public static string GetBasePath(IConfiguration configuration)
        {
            var scrapeEndpointPath = configuration.GetValue<string>(EnvironmentVariables.Scraping.Path);
            if (string.IsNullOrWhiteSpace(scrapeEndpointPath))
            {
                return DefaultScrapeEndpoint;
            }

            return scrapeEndpointPath.StartsWith("/") ? scrapeEndpointPath.Substring(1) : scrapeEndpointPath;
        }
    }
}