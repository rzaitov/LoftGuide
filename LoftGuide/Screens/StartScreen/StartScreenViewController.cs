using System;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

using LoftGuide.Touch.Common;

namespace LoftGuide.Touch.Screens.StartScreen
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

			_view = new StartScreenView();
			_view.ClipsToBounds = true;
			_view.Frame = DefaultFrames.MainFrame;
		}
	}
}

