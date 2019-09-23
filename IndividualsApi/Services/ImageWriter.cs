using System;
using System.IO;
using System.Threading.Tasks;
using IndividualsApi.Helpers.ImageWriter.Helper;
using Microsoft.AspNetCore.Http;

namespace IndividualsApi.Services
{
    public class ImageWriter : IImageWriter
    {
        public async Task<string> UploadImage(IFormFile file)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file);
            }

            return "Invalid image file";
        }

        public bool DeleteImage(string location)
        {
            return DeleteFile(location);
        }

        /// <summary>
        /// Method to check if file is image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return WriterHelper.GetImageFormat(fileBytes) != WriterHelper.ImageFormat.unknown;
        }

        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<string> WriteFile(IFormFile file)
        {
            string path;
            
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                var fileName = Guid.NewGuid().ToString() + extension; //Create a new Name 
                                                                  //for the file due to security reasons.

                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return path;
        }

        public bool DeleteFile(string location)
        {
            if (File.Exists(location))
            {
                File.Delete(location);
                return true;
            }

            return false;
        }

    }
}