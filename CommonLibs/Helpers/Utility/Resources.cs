using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace PNB.Helpers
{
    public class PNBResources
    {
        public static Image[] GetImages(string path)
        {
            List<Image> images = new List<Image>();
            string[] files = null;
            try
            {
                Image image = null;
                files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    try
                    {
                        image = Image.FromFile(file);
                        images.Add(image);
                    }
                    catch (Exception eee)
                    {
                        Logger.Log(eee);
                    }
                }
            }
            catch (Exception ee) { Logger.Log(ee); }

            return images.ToArray();
        }
    }
}
