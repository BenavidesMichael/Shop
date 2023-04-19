using Shop.Application.Models;

namespace Shop.Application.Contracts.Infrastructure
{
    public interface IImageManageService
    {
        Task<ImageResponse> UploadImage(ImageData imageData);
    }
}
