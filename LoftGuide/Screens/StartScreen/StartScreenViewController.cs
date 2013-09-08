using System;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

using ZXing.Mobile;

using LoftGuide.Touch.Common;

namespace LoftGuide.Screens.StartScreen
{
	public class StartScreenViewController : UIViewController
	{
		private StartScreenView _view;
		private StartScreenController _controller;

		private ZXingScannerViewController _scanerController;
		private MobileBarcodeScanner _barCodeScaner;
		private MobileBarcodeScanningOptions _options;

		public StartScreenViewController(StartScreenController controller)
		{
			_controller = controller;
			_controller.OnStartScanPressed += OnStartScanPressed;

			_barCodeScaner = new MobileBarcodeScanner(this);
			_options = new MobileBarcodeScanningOptions();
			_options.AutoRotate = false;
			_scanerController = new ZXingScannerViewController(_options, _barCodeScaner);
		}

		private void OnStartScanPressed ()
		{
			//PresentViewController(_scanerController, true, null);
			_barCodeScaner.UseCustomOverlay = false;
			_barCodeScaner.TopText = "наведите камеру на штрихкод";
			_barCodeScaner.BottomText = "и подождите";

			System.Threading.Tasks.Task<ZXing.Result> result = _barCodeScaner.Scan();
			//HandleScanResult(result);

		}

		private void HandleScanResult(ZXing.Result result)
		{
			string msg = "";

			if (result != null && !string.IsNullOrEmpty(result.Text))
				msg = "Found Barcode: " + result.Text;
			else
				msg = "Scanning Canceled!";

			this.InvokeOnMainThread(() => {
				var av = new UIAlertView("Barcode Result", msg, null, "OK", null);
				av.Show();
			});
		}




		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.Frame = DefaultFrames.MainFrame;
			View.BackgroundColor = UIColor.White;

			_view = new StartScreenView(_controller, DefaultFrames.MainFrame);
			_view.ClipsToBounds = true;

			View.AddSubview(_view);
		}
	}
}

