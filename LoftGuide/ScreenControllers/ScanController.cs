using System;
using System.Collections.Generic;

using ZXing;
using ZXing.Mobile;


namespace LoftGuide.Screens.ScanScreen
{
	public class ScanController : ScreenControllerBase
	{
		public event Action ScanCanceled;
		public event Action ScanCompletedWithResult;

		public Result ScanResult { get; private set; }
		public MobileBarcodeScanningOptions ScanningOptions { get; private set; }

		public ScanController()
		{
			ScanningOptions = new MobileBarcodeScanningOptions();
			ScanningOptions.AutoRotate = false;
			ScanningOptions.PossibleFormats = new List<BarcodeFormat>()
			{
				BarcodeFormat.QR_CODE
			};
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

