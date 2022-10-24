using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobGetter.Helpers
{
    public static class SaveCVHelper
    {
        public static string SaveCV(IFormFile file)
        {
            string FilePath = Directory.GetCurrentDirectory()+"/Files/" ;
            string FileName = Guid.NewGuid().ToString() + file.FileName;

            string FinalPath = Path.Combine(FilePath, FileName);


            using (var stream = new FileStream(FinalPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return FileName;
        }
    }
}
