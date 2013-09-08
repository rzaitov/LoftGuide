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
			View.BackgroundColor = UIColor.Yellow;

			_view = new StartScreenView(_controller, DefaultFrames.MainFrame);
			_view.ClipsToBounds = true;

			View.AddSubview(_view);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			View.BackgroundColor = UIColor.White;
		}
	}
}

