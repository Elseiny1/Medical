using Medical.Core.Interfaces;
using Medical.EF.Data;
using Microsoft.AspNetCore.Http;

namespace Medical.Core.Repositories
{
    public class ImageRepo: IimageRepo
    {
        

        //public async Task<string> AddImageAsync(IFormFile file,string phone)
        //{
        //    string fileName;
        //    string endFile;
        //    if (file == null)
        //    {
        //        fileName = "avatar.png";
        //        return fileName;
        //    }

        //    fileName=file.Name;
        //    endFile = Path.Combine("UsersImages", fileName);
        //    File.Copy(fileName, endFile);

        //    return fileName;
        //}
        public async Task<string> AddImageAsync(IFormFile imagefile, string phone)
        {

            if (imagefile == null)
            { return "avatar.png"; }
            string imageUrl = phone+imagefile.FileName;
            string useresImages = Path.Combine(Environment.CurrentDirectory, "UsersImages");
            string path = Path.Combine(useresImages, imageUrl);

            if (System.IO.File.Exists(imageUrl))
            {
                string temporary = Path.Combine(Environment.CurrentDirectory, "ImagePackups");
                File.Copy(path, temporary);
                string newFilePath = Path.Combine(path, imageUrl);
                File.Move(temporary, newFilePath);
            }
            else
            { imagefile.CopyTo(new FileStream(path, FileMode.Create)); }


            return imageUrl;
        }
        public async Task<string> UpdateImages(IFormFile imagefile, string imagename)
        {
            string imageUrl = imagefile.FileName;
            string path = Path.Combine(Environment.CurrentDirectory, "Uploads");
            if (System.IO.File.Exists(imagename))
            {
                System.IO.File.Delete(imagename);
                imagefile.CopyTo(new FileStream(path, FileMode.Create));
            }


            return imageUrl;//add username at the controller
        }

    }
}
