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
			this.files = GetFilesFrom(folder, filters, false);
		}

		public void Resize_Image(int minCoord)
		{
			Console.WriteLine("Resizing...");

			Console.WriteLine("Resized.");
		}

		public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
		{
			List<String> filesFound = new List<String>();
			var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
			foreach (var filter in filters)
			{
				filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
			}
			return filesFound.ToArray();
		}
	}
}
