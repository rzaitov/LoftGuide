using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace LoftGuide
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		private UIWindow window;
		private ExibitInfoViewController _controller;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			window = new UIWindow(UIScreen.MainScreen.Bounds);
			_controller = new ExibitInfoViewController();

			window.RootViewController = _controller;
			window.MakeKeyAndVisible();

			return true;
		}
	}
}

