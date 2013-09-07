using System;
using System.IO;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace LoftGuide.Screens.ExibitInfoScreen
{
	public class ExibitInfoView : UIView
	{
		private UINavigationBar _navBar;
		private static readonly RectangleF NavbarFrame = new RectangleF(0f, 0f, 320f, 45f);
		private UINavigationItem _backNavItem;

		private UIWebView _contentDisplayer;
		private static readonly RectangleF ContentDisplayerFrame = new RectangleF(0f, NavbarFrame.Height, 320f, 460f - NavbarFrame.Height);
		private WebViewDelegate _webDelegate;

		private ExibitInfoController _controller;

		public ExibitInfoView(ExibitInfoController controller)
		{
			_controller = controller;

			BackgroundColor = UIColor.White;

			InitNavBar();
			InitContentDisplayer();

			AddSubview(_navBar);
			AddSubview(_contentDisplayer);
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
			// Приведет к отображению экрана сканирования баркода
			_controller.ScanAnotherCode();
		}

		private void InitContentDisplayer()
		{
			_contentDisplayer = new UIWebView();
			_contentDisplayer.Frame = ContentDisplayerFrame;
			_contentDisplayer.ClipsToBounds = true;
			_contentDisplayer.BackgroundColor = UIColor.Clear;

			_webDelegate = new WebViewDelegate();
			_contentDisplayer.Delegate = _webDelegate;

			LoadExibitInfoFromFile("ExibitInfos/LaJoconde.html");
		}

		private void LoadExibitInfoFromFile(string path)
		{
			string htmlContent = File.ReadAllText(path);
			string dir = Path.GetDirectoryName(path);

			NSUrl dirUrl = new NSUrl(dir, true);
			_contentDisplayer.LoadHtmlString(htmlContent, dirUrl);
		}
	}
}

