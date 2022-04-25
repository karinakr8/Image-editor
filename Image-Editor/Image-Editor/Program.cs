namespace Image_Editor
{
	class Program
	{
		static void Main(string[] args)
		{
			// create file if not created
			const string textFile = "path.txt";
			const int maxCoord = 800;
			string mainFolder = Directory.GetCurrentDirectory();
			Editor editor;

			if (!File.Exists(textFile))
			{
				File.CreateText(textFile);
				Console.WriteLine("Write the path to the image folder into the \"path.txt\" file.");
				return;
			}

			// read path from file
			string mainFolderFromText = File.ReadAllText(textFile);

			if (mainFolderFromText == "")
			{
				editor = new Editor(mainFolder);
			}
			else
			{
				editor = new Editor(mainFolderFromText);
			}

			editor.Resize_Image(maxCoord);
		}
	}
}