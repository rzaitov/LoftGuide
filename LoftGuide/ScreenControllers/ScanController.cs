using System;

using ZXing;

namespace LoftGuide.Screens.ScanScreen
{
	public class ScanController : ScreenControllerBase
	{
		public event Action ScanCanceled;
		public event Action ScanCompletedWithResult;

		public Result ScanResult { get; private set; }

		public ScanController()
		{
		}

		public void SaveScanResult(Result scanResult)
		{
			ScanResult = scanResult;

			if(ScanResult == null)
			{
				TryRaiseEvent(ScanCanceled);
			}
			else
			{
				TryRaiseEvent(ScanCompletedWithResult);
			}
		}
	}
}

