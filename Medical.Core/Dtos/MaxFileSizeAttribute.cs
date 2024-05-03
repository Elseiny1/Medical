
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Medical.Core.Dtos
{
    internal class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }
        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null)
                return false;

            return file.Length <= _maxFileSize;
        }
    }
    internal class ExtensionsFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            string[] _validExtensions = { "JPG", "JPEG", "png","jpg", "jpeg", "PNG" };

            var file = (IFormFile)value;
            var ext = Path.GetExtension(file.FileName).ToUpper().Replace(".", "");
            return _validExtensions.Contains(ext) && file.ContentType.Contains("image");
        }
    }
}