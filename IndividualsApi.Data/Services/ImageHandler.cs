﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividualsApi.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndividualsApi.Data.Services
{
    public interface IImageHandler
    {
        Task<IActionResult> UploadImage(IFormFile file);
    }

    public class ImageHandler : IImageHandler
    {
        private readonly IImageWriter _imageWriter;
        public ImageHandler(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var result = await _imageWriter.UploadImage(file);
            return new ObjectResult(result);
        }
    }
}
