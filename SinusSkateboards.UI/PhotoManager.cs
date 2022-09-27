using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SinusSkateboards.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.UI
{
    public class PhotoManager
    {

        public string AddPicture(IFormFile photo, IWebHostEnvironment webHostEnvironment)
        {
            //Väg för mapp
            string folder = Path.Combine(webHostEnvironment.WebRootPath, "images/products");


            //Om mappen inte finns så skapas en ny
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //Skapar filnamn
            string uniqueFileName = string.Concat(Guid.NewGuid().ToString(), "-", photo.FileName);

            string loadUpFolder = Path.Combine(folder, uniqueFileName);


            //Skapar filen
            using (var fileStream = new FileStream(loadUpFolder, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }

            return uniqueFileName;
        }

        public string ChangePicture(IFormFile photo, IWebHostEnvironment webHostEnvironment, ProductModel product)
        {
            //Väg för mapp
            string folder = Path.Combine(webHostEnvironment.WebRootPath, "images/products");


            //Om mappen inte finns så skapas en ny
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }


            //Kollar om bilden finns i mappen och tar bort den isåfall
            var file = Path.Combine(folder, product.PhotoPath);

            if (File.Exists(file))
            {
                File.Delete(file);
            }

            //Skapar filnamn
            string uniqueFileName = string.Concat(Guid.NewGuid().ToString(), "-", photo.FileName);

            string loadUpFolder = Path.Combine(folder, uniqueFileName);


            //Skapar filen
            using (var fileStream = new FileStream(loadUpFolder, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
    }
    }
