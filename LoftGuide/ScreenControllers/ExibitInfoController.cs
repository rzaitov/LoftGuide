using System;

namespace LoftGuide
{
	public class ExibitInfoController
	{
		public event Action ShowScanScreen;

		public ExibitInfoController()
		{

		}

		public void ScanAnotherCode()
		{
			TryRaiseEvent(ShowScanScreen);
		}

		private void TryRaiseEvent(Action eventHandler)
		{
			if(eventHandler != null)
			{
				eventHandler();
			}
		}
	}
}

