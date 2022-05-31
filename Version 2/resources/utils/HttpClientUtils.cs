using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PFM5.resources.utils
{
    public static class HttpClientUtils
    {
        private static readonly HttpClient DefaultHttpClient = new HttpClient();

        public static async Task DownloadFileAsync(Uri uri, string fileName)
        /* Downloads a  file from the specified URL and saves it to the given file name.
         * :return Task: The Task context
         */
        {
            using (var stream = await DefaultHttpClient.GetStreamAsync(uri))
            {
                using (var fileStream = new FileStream(fileName, FileMode.CreateNew))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
        }

    }
}