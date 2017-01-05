using System.IO;

namespace HO.Apps.Messaging
{
    public class MediaFileResponse
    {
        public string AlbumPath { get; set; }
        public string Path { get; set; }
        public Stream Stream { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
