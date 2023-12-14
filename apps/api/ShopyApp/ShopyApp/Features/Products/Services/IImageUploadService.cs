namespace ShopyApp;

public interface IImageUploadService
{
    Task<List<string>> Upload(IFormFileCollection files);
    Task<string> UploadSingleFile(IFormFile files);
}
