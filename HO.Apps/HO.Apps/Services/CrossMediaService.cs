using HO.Apps.Contracts;
using HO.Apps.Helpers;
using HO.Apps.Messaging;
using HO.Apps.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(CrossMediaService))]
namespace HO.Apps.Services
{
    public class CrossMediaService : ICrossMediaService
    {
        public async Task<MediaFileResponse> TakePhotoAsync()
        {
            // https://github.com/jamesmontemagno/MediaPlugin
            MediaFileResponse response = new MediaFileResponse();
            MediaFile file = new MediaFile("", null);

            // Initialize Camera
            await CrossMedia.Current.Initialize();


            // Check to see if camera is available
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                // If camera is  not available 
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    response.IsSuccess = false;
                    response.Message = "Pick Photo not supported";
                }
                // Pick from library or album if pick photo is supported
                else
                {
                    PickMediaOptions mediaOptions = new PickMediaOptions()
                    {
                        CompressionQuality = 90,
                        CustomPhotoSize = 90,
                        PhotoSize = PhotoSize.Medium
                    };

                    file = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
            }
            else
            {
                // Take photo from camera
                StoreCameraMediaOptions mediaOptions = new StoreCameraMediaOptions
                {
                    Directory = ApplicationSettingsConstant.PictureDirectory,
                    Name = $"{Guid.NewGuid()}.jpg",
                    PhotoSize = PhotoSize.Medium,
                    CustomPhotoSize = 90,
                    CompressionQuality = 92,
                    SaveToAlbum = true,
                    AllowCropping = true,
                    DefaultCamera = CameraDevice.Rear,
                };

                file = await CrossMedia.Current.TakePhotoAsync(mediaOptions);
                response.IsSuccess = true;
                response.Message = string.Empty;
            }

            if (file != null)
            {
                //Get the public album path
                response.AlbumPath = file.AlbumPath;

                //Get private path
                response.Path = file.Path;
                response.Stream = file.GetStream();

                // Disponse file
                file.Dispose();
            }

            return response;
        }

        public async Task<MediaFileResponse> TakeVideoAsync()
        {
            // https://github.com/jamesmontemagno/MediaPlugin
            MediaFileResponse response = new MediaFileResponse();
            MediaFile file = new MediaFile("", null);

            // Initialize Camera
            await CrossMedia.Current.Initialize();

            // Check to see if camera is available
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
            {
                // If camera is  not available 
                if (!CrossMedia.Current.IsPickVideoSupported)
                {
                    response.IsSuccess = false;
                    response.Message = "Pick Video not supported";
                }

                // Pick from library or album if pick video is supported
                else
                {
                    file = await CrossMedia.Current.PickVideoAsync();
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
            }
            else
            {
                // Take video from camera
                StoreVideoOptions videoOptions = new StoreVideoOptions
                {
                    Directory = ApplicationSettingsConstant.VideoDirectory,
                    Name = $"{Guid.NewGuid()}.mp4",
                    SaveToAlbum = true,
                    AllowCropping = true,
                    DefaultCamera = CameraDevice.Rear,
                    DesiredLength = TimeSpan.FromMinutes(5),
                    Quality = VideoQuality.Medium
                };

                file = await CrossMedia.Current.TakeVideoAsync(videoOptions);
                response.IsSuccess = true;
                response.Message = string.Empty;
            }

            if (file != null)
            {
                //Get the public album path
                response.AlbumPath = file.AlbumPath;

                //Get private path
                response.Path = file.Path;
                response.Stream = file.GetStream();

                // Disponse file
                file.Dispose();
            }

            return response;
        }
    }
}
