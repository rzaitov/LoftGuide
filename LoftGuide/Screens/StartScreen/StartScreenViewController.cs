using System;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

using LoftGuide.Touch.Common;

namespace LoftGuide.Screens.StartScreen
{
	public class StartScreenViewController : UIViewController
	{
		private StartScreenView _view;

		public StartScreenViewController()
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.Frame = DefaultFrames.MainFrame;
			View.BackgroundColor = UIColor.White;

			_view = new StartScreenView(DefaultFrames.MainFrame);
			_view.ClipsToBounds = true;

			View.AddSubview(_view);
		}
	}
}

