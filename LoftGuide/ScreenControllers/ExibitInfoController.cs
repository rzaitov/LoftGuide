using System;

using LoftGuide.Domain;
using LoftGuide.Logic;

using LoftGuide.Screens;

namespace LoftGuide.Screens.ExibitInfoScreen
{
	public class ExibitInfoController : ScreenControllerBase
	{
		public event Action ShowScanScreen;

		public string ExibitInfoKey { get; private set; }

		private ExibitInfoService _service;

		public ExibitInfoController(ExibitInfoService service)
		{
			_service = service;
		}

		public void SetExibitInfoKey(string key)
		{
			ExibitInfoKey = key;
		}

		public ExibitInfo GetExibitInfo()
		{
			ExibitInfo info = _service.GetExibitInfoByKey(ExibitInfoKey);
			return info;
		}

		public void ScanAnotherCode()
		{
			TryRaiseEvent(ShowScanScreen);
		}
	}
}

