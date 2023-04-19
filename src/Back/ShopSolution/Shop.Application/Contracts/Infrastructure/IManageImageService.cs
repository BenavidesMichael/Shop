using Shop.Application.Models.Images;

namespace Shop.Application.Contracts.Infrastructure
{
    public interface IImageManageService
    {
        Task<ImageResponse> UploadImage(ImageData imageData);
    }
}
