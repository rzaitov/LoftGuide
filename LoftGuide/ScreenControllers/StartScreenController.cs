using System;

using LoftGuide.Screens;

namespace LoftGuide.Screens.StartScreen
{
	public class StartScreenController : ScreenControllerBase
	{
		public event Action OnStartScanPressed;

		public StartScreenController()
		{
		}

		public void StartScanPressed()
		{
			TryRaiseEvent(OnStartScanPressed);
		}
	}
}

