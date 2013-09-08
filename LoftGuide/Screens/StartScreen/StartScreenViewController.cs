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

		public StartScreenViewController(StartScreenController controller)
		{
			_controller = controller;
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

