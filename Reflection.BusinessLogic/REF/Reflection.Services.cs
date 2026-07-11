using Reflection.EF.Communication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Reflection.BusinessLogic.REF
{
    public class ReflectionServices
    {
        public byte[] ConvertImageToByteArray(COM_T003 imageSource)
        {
            byte[] FileObject=null;
            string appPath = HostingEnvironment.ApplicationPhysicalPath;
            string FilePath = appPath + "ERP_Documents\\" + imageSource.client + "\\" + imageSource.comp_code + "\\" + imageSource.url;

            if (File.Exists(FilePath))
            {

                FileObject = File.ReadAllBytes(FilePath);
            }
            //else
            //{
            //    Console.WriteLine("Image file does not exist: " + imagePath);
            //    return null;
            //}

            return FileObject;
        }

    }
}
