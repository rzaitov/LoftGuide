using System;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace LoftGuide.Screens.ExibitInfoScreen
{
	public class ExibitInfoViewController : UIViewController
	{
		private static readonly RectangleF MainFrame = new RectangleF(0f, 0f, 320f, 460f);

		private UIView _view;
		private ExibitInfoController _controller;

		public ExibitInfoViewController()
		{
			_controller = new ExibitInfoController();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.Frame = MainFrame;

			_view = new ExibitInfoView(_controller);
			_view.Frame = MainFrame;

			View.AddSubview(_view);
		}
	}
}

