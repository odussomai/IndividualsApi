using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IndividualsApi.Services
{
    public interface IImageWriter
    {
        Task<string> UploadImage(IFormFile file);
        bool DeleteImage(string location);

        string GetImage(string location);
    }
}
