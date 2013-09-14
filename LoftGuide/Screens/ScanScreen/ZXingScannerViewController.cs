using System;
using System.Drawing;
using System.Text;
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.AVFoundation;

using ZXing;

namespace LoftGuide.Screens.ScanScreen
{	
	public class ZXingScannerViewController : UIViewController
	{
		private ZXingScannerView _scannerView;
		private ScanController _controller;

		public ZXingScannerViewController(ScanController controller)
		{
			_controller = controller;
		}

		public void Cancel()
		{
			InvokeOnMainThread(() => _scannerView.StopScanning());
		}

		UIStatusBarStyle originalStatusBarStyle = UIStatusBarStyle.Default;

		public override void ViewDidLoad ()
		{
			this.View.Frame = UIScreen.MainScreen.Bounds;
			this.View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

			_scannerView = new ZXingScannerView(View.Bounds);
			_scannerView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			_scannerView.UseCustomOverlayView = false;
//			scannerView.TopText = this.Scanner.TopText;
//			scannerView.BottomText = this.Scanner.BottomText;
//			scannerView.CancelButtonText = this.Scanner.CancelButtonText;
//			scannerView.FlashButtonText = this.Scanner.FlashButtonText;

			View.AddSubview(_scannerView);
			View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
		}

		public void Torch(bool on)
		{
			if (_scannerView != null)
				_scannerView.SetTorch (on);
		}

		public void ToggleTorch()
		{
			if (_scannerView != null)
				_scannerView.ToggleTorch ();
		}

		public bool IsTorchOn
		{
			get { return _scannerView.IsTorchOn; }
		}

		public override void ViewDidAppear (bool animated)
		{
			originalStatusBarStyle = UIApplication.SharedApplication.StatusBarStyle;
			
			UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.BlackTranslucent, false);

			Console.WriteLine("Starting to scan...");
			_scannerView.StartScanning(_controller.ScanningOptions, OnScanCompletion);
		}

		private void OnScanCompletion(Result result)
		{
			Console.WriteLine("Stopping scan...");
			_scannerView.StopScanning();

			_controller.SaveScanResult(result);
		}


		public override void ViewDidDisappear (bool animated)
		{
			if (_scannerView != null)
				_scannerView.StopScanning();
		}

		public override void ViewWillDisappear(bool animated)
		{
			UIApplication.SharedApplication.SetStatusBarStyle(originalStatusBarStyle, false);
			
			//if (scannerView != null)
			//	scannerView.StopScanning();

			//scannerView.RemoveFromSuperview();
			//scannerView.Dispose();			
			//scannerView = null;
		}

		public override void DidRotate (UIInterfaceOrientation fromInterfaceOrientation)
		{
			if (_scannerView != null)
				_scannerView.DidRotate (this.InterfaceOrientation);

			//overlayView.LayoutSubviews();
		}	
		public override bool ShouldAutorotate ()
		{
			return true;
		}

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations ()
		{
			return UIInterfaceOrientationMask.All;
		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}

	}
}

