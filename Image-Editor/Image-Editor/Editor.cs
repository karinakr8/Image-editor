using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;

namespace Image_Editor
{
    internal class Editor
    {
		private readonly String[] filters = new String[] { "jpg", "jpeg", "png" };
		public String[] files;

		// take folder, path and resize all the images in it
		public Editor(string folder)
		{
			
		}

		public void Resize_Image(int minCoord)
		{
			Console.WriteLine("Resizing...");
		
			Console.WriteLine("Resized.");
		}
	}
}
