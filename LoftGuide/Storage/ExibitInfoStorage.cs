using System;
using System.IO;

namespace LoftGuide.Storage
{
	public class ExibitInfoStorage
	{
		public string GetExibitInfoByPath(string path)
		{
			string content = File.ReadAllText(path);

			return content;
		}
	}
}

