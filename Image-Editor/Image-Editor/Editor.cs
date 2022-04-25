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
			for (int i = 0; i < files.Length; i++)
			{
				// load image
				Bitmap? cloneImg = null;
				using (Bitmap bitMapImage = new(files[i]))
				{
					cloneImg = new Bitmap(bitMapImage);
				}
				// resize image
				Image resized = Resize(cloneImg, minCoord);

				// save image
				File.Delete(files[i]);
				resized.Save(files[i], ImageFormat.Jpeg);
			}
			Console.WriteLine("Resized.");
		}

		public static Bitmap Resize(Image img, int coord)
		{
			Size size = new Size();

			// calculate size with respect
			decimal height = img.Height;
			decimal width = img.Width;

			if (height > 0 && width > 0)
			{
				height = coord / height;
				width = coord / width;
			}

			// create an image of the desired size
			if (img.Width > img.Height)
			{
				size = new Size((int)(img.Width * height), coord);
			}
			else
			{
				size = new Size(coord, (int)(img.Height * width));
			}
			return new Bitmap(img, size);
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
