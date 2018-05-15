using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
    public class ImageToByteArray
    {
        public static byte[] ImageByteArray(string name,int idItem)
        {
  
            string fullPath = HttpContext.Current.Server.MapPath($"/Images/Item{idItem}/{name}");

            string defaultPath= HttpContext.Current.Server.MapPath($"/Images/No_Image_Available.jpg");

            byte[] _image;

            if (File.Exists(fullPath))
            {
                _image = File.ReadAllBytes(fullPath);
                return _image;
            }
            else
            {
                _image=File.ReadAllBytes(defaultPath);
                return _image;
             }
        }

        public static byte[] ImageByteArray(string name)
        {

            string fullPath = HttpContext.Current.Server.MapPath($"/Images/User/{name}");

            string defaultPath = HttpContext.Current.Server.MapPath($"/Images/No_Image_Available.jpg");

            byte[] _image;

            if (File.Exists(fullPath))
            {
                _image = File.ReadAllBytes(fullPath);
                return _image;
            }
            else
            {
                _image = File.ReadAllBytes(defaultPath);
                return _image;
            }
        }
    }
}
