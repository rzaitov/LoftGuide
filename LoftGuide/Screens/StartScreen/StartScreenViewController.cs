using System;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

using ZXing.Mobile;

using LoftGuide.Touch.Common;
using LoftGuide.Screens.ScanScreen;

namespace LoftGuide.Screens.StartScreen
{
	public class StartScreenViewController : UIViewController
	{
		private StartScreenView _view;
		private StartScreenController _controller;

		private ZXingScannerViewController _scanerViewController;
		private ScanController _scanController;
		private MobileBarcodeScanningOptions _options;

		public StartScreenViewController(StartScreenController controller)
		{
			_controller = controller;
			_controller.OnStartScanPressed += OnStartScanPressed;

			_options = new MobileBarcodeScanningOptions();
			_options.AutoRotate = false;

			_scanController = new ScanController();
			_scanController.ScanCanceled += HandleOnScannedResult;
			_scanController.ScanCompletedWithResult += HandleOnScannedResult;

			_scanerViewController = new ZXingScannerViewController(_scanController, _options);
		}

		private void HandleOnScannedResult()
		{
			_scanerViewController.DismissViewController(true, null);
		}

		private void OnStartScanPressed ()
		{
			PresentViewController(_scanerViewController, true, null);
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

