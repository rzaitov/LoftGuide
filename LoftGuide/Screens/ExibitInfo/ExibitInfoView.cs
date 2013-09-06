using System;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace LoftGuide.ExibitInfoScreen
{
	public class ExibitInfoView : UIView
	{
		private UINavigationBar _navBar;
		private static readonly RectangleF NavbarFrame = new RectangleF(0f, 0f, 320f, 45f);
		private UINavigationItem _backNavItem;

		public ExibitInfoView()
		{
			BackgroundColor = UIColor.White;

			InitNavBar();

			AddSubview(_navBar);
		}

		private void InitNavBar()
		{
			_navBar = new UINavigationBar();
			_navBar.Frame = NavbarFrame;
			_navBar.ClipsToBounds = true;

			UIBarButtonItem _backBtnItem = new UIBarButtonItem("Сканировать еще", UIBarButtonItemStyle.Plain, OnBackPressed);

			_backNavItem = new UINavigationItem();
			_backNavItem.LeftBarButtonItem = _backBtnItem;

			_navBar.SetItems(new UINavigationItem[] { _backNavItem }, false);
		}

		private void OnBackPressed(object sender, EventArgs e)
		{

		}
	}
}

