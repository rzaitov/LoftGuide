using System;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace LoftGuide.Screens.ExibitInfoScreen
{
	public class ExibitInfoViewController : UIViewController
	{
		private static readonly RectangleF MainFrame = new RectangleF(0f, 0f, 320f, 460f);

		private ExibitInfoView _view;
		private ExibitInfoController _controller;

		public ExibitInfoViewController(ExibitInfoController controller)
		{
			_controller = controller;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.Frame = MainFrame;

			_view = new ExibitInfoView(_controller);
			_view.Frame = MainFrame;

			View.AddSubview(_view);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			_view.BindToView();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			_view.BindToView();
		}
	}
}

