using System;

using LoftGuide.Screens;

namespace LoftGuide.Screens.ExibitInfoScreen
{
	public class ExibitInfoController : ScreenControllerBase
	{
		public event Action ShowScanScreen;

		public ExibitInfoController()
		{

		}

		public void ScanAnotherCode()
		{
			TryRaiseEvent(ShowScanScreen);
		}
	}
}

