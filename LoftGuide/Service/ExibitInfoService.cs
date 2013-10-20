using System;
using System.IO;
using System.Collections.Generic;

using LoftGuide.Domain;
using LoftGuide.Storage;

namespace LoftGuide.Logic
{
	public class ExibitInfoService
	{
		private static readonly string NotFoundKey = "__NotFoundKey__";

		private Dictionary<string, string> _keyFilePathMap;
		private ExibitInfoStorage _storage;

		public ExibitInfoService(ExibitInfoStorage storage)
		{
			_storage = storage;

			_keyFilePathMap = new Dictionary<string, string>()
			{
				{ NotFoundKey, "ExibitInfos/404.html" },

				{ "kanagawa_greatwave", "ExibitInfos/kanagawa_greatwave.html" },
				{ "kramskoy_woman", "ExibitInfos/kramskoy_woman.html" },
				{ "munch_scream", "ExibitInfos/munch_scream.html" },
				{ "perov_dostoevskiy", "ExibitInfos/perov_dostoevskiy.html" },
				{ "vangogh_starrynight", "ExibitInfos/vangogh_starrynight.html" }
			};
		}

		public ExibitInfo GetExibitInfoByKey(string key)
		{
			bool isKeyValid = !string.IsNullOrWhiteSpace(key) && _keyFilePathMap.ContainsKey(key);
			key = isKeyValid ? key : NotFoundKey;

			string pathToFile = _keyFilePathMap[key];
			string htmlContent = _storage.GetExibitInfoByPath(pathToFile);

			ExibitInfo info = new ExibitInfo
			{
				HtmlExibitInfo = htmlContent,
				DirPath = Path.GetDirectoryName(pathToFile)
			};

			return info;
		}

	}
}

