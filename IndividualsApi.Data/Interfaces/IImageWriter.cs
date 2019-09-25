using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IndividualsApi.Data.Interfaces
{
    public interface IImageWriter
    {
        Task<string> UploadImage(IFormFile file);
        bool DeleteImage(string location);

        string GetImage(string location);
    }
}
