using HO.Apps.Messaging;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;

namespace HO.Apps.Contracts
{
    public interface ICrossMediaService
    {
        Task<MediaFileResponse> TakePhotoAsync();
        Task<MediaFileResponse> TakeVideoAsync();
    }
}
