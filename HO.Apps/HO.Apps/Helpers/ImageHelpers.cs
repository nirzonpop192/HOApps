using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace HO.Apps.Helpers
{
    public static class ImageHelpers
    {
        public static string CrossPlatformImageSource(this string image)
        {
            string source = Device.OnPlatform(
                  iOS: $"Images/{image}",
                  Android: image,
                  WinPhone: $"Images/{image}");

            return source.ToString();
        }

        public static ImageSource FromStream(Stream stream)
        {
            return ImageSource.FromStream(() =>
            {
                return stream;
            });
        }

        public static ImageSource FromBytes(this byte[] bytes)
        {
            return ImageSource.FromStream(() => new MemoryStream(bytes));
        }

        public static ImageSource FromBase64String(this string base64String)
        {
            return ImageSource.FromStream(() =>
                new MemoryStream(ConvertFromBase64String(base64String)));
        }

        public static byte[] ConvertStreamToBytes(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                stream.Dispose();
                return memoryStream.ToArray();
            }
        }

        public static Stream ConvertByteToStream(byte[] bytes)
        {
            return new MemoryStream(bytes);
        }

        public static string ConvertToImageUrl(this string imageUrl)
        {
            //D:\farmersImg\e3be5524-b6eb-4ead-ba11-d381e74474ac.jpg
            if (imageUrl.Length > 30)
            {
                string[] urlParts = Regex.Split(imageUrl, @"\\");
                return $"{SettingConstant.AgentImageUrl}{urlParts.LastOrDefault()}".ConvertToBase64String();
            }

            return imageUrl;
        }

        public static string ConvertToBase64String(this string imageUrl)
        {
            return DownloadBytes(imageUrl).ConvertToBase64String();
        }

        private static byte[] DownloadBytes(string imageUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetByteArrayAsync(new Uri(imageUrl));
                return result.Result;
            }
        }

        private static Stream DownloadStream(string imageUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetStreamAsync(new Uri(imageUrl));
                return result.Result;
            }
        }

        public static string ConvertToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public static byte[] ConvertFromBase64String(this string base64String)
        {
            return Convert.FromBase64String(base64String);
        }
    }
}
