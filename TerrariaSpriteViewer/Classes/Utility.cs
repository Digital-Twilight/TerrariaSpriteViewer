using System.Drawing;

namespace TerrariaSpriteViewer.Classes
{
    public class Utility
    {
        public static Bitmap LoadBitmapNoLock(string path)
        {
            using (var img = Image.FromFile(path))
            {
                return new Bitmap(img);
            }
        }
    }
}
