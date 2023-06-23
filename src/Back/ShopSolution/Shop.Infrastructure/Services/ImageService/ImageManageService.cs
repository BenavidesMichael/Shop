using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using Shop.Application.Contracts.Infrastructure;
using Shop.Application.Models.AppSettings;
using Shop.Application.Models.Images;

namespace Shop.Infrastructure.Services.ImageService
{
    public class ImageManageService : IImageManageService
    {
        public CloudinarySetting CloudinarySetting { get; }

        public ImageManageService(IOptions<CloudinarySetting> options)
        {
            CloudinarySetting = options.Value;
        }

        public async Task<ImageResponse> UploadImage(ImageData imageData)
        {
            var account = new Account(CloudinarySetting.CloudName, CloudinarySetting.ApiKey, CloudinarySetting.ApiSecret);
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
