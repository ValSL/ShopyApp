using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace ShopyApp;

public class CloudinaryImageUploadService : IImageUploadService
{
    const string Cloud = "dyregmisw";
    const string ApiKey = "893793574941111";
    const string ApiSecret = "8KlURKJfdtlsRnyieJuiEVEvtKI";

    private readonly Cloudinary _cloudinary;

    public CloudinaryImageUploadService()
    {
        var account = new Account(Cloud, ApiKey, ApiSecret);
        _cloudinary = new Cloudinary(account);
        _cloudinary.Api.Secure = true;
    }

    public async Task<List<string>> Upload(IFormFileCollection files)
    {
        var imageUrls = new List<string>();

        foreach (var file in files)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var uploadparams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, memoryStream),
            };

            var result = _cloudinary.Upload(uploadparams);

            if (result.Error != null)
            {
                throw new Exception($"Cloudinary error occured: {result.Error.Message}");
            }

            imageUrls.Add(result.SecureUrl.ToString());
        }

        return imageUrls;
    }

    public async Task<string>? UploadSingleFile(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        memoryStream.Position = 0;

        var uploadparams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, memoryStream),
        };

        var result = _cloudinary.Upload(uploadparams);

        if (result.Error != null)
        {
            throw new Exception($"Cloudinary error occured: {result.Error.Message}");
        }

        return result.SecureUrl.ToString();

    }
}