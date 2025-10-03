using Microsoft.AspNetCore.WebUtilities;

namespace ActivityPlanner.Frontend.Utils
{
    public static class QueryStringBuilder
    {
        public static string Add(string path, IDictionary<string, string?> kv)
            => QueryHelpers.AddQueryString(path, kv
                .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                .ToDictionary(kv => kv.Key, kv => kv.Value));
    }
}
