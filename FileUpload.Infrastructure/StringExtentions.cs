using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileUpload.Infrastructure
{
    public static class StringExtentions
    {
        public static string GetExtension(this string fileName)
        {
            var regex = new Regex(@"\.\w*$");
            var match = regex.Match(fileName);
            return match.Success ? match.Value : string.Empty;
        }

        public static string GetFileNameWithoutExtension(this string fileName)
        {
            return fileName.Replace(GetExtension(fileName), string.Empty);
        }
    }
}
