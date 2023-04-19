using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using Shop.Application.Contracts.Infrastructure;
using Shop.Application.Models;

namespace Shop.Infrastructure.Services.ImageService
{
    public class ImageManageService : IImageManageService
    {
        public CloudinarySetting _cloudinarySetting { get; }

        public ImageManageService(IOptions<CloudinarySetting> options)
        {
            _cloudinarySetting = options.Value;
        }

        public async Task<ImageResponse> UploadImage(ImageData imageData)
        {
            var account = new Account(_cloudinarySetting.CloudName, _cloudinarySetting.ApiKey, _cloudinarySetting.ApiSecret);
            var cloudinary = new Cloudinary(account);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imageData.Name, imageData.ImageStram)
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            
            if (uploadResult.Error != null)
            {
                throw new Exception("Error while uploading image");
            }

            return new ImageResponse()
            {
                PublicId = uploadResult.PublicId,
                ImageUrl = uploadResult.SecureUrl.AbsoluteUri
            };
        }
    }
}
