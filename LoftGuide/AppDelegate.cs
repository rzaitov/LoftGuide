using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using LoftGuide.Touch.Common;
using LoftGuide.ExibitInfoScreen;
using LoftGuide.Touch.Screens.StartScreen;

namespace LoftGuide
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		private UIWindow window;
		private ExibitInfoViewController _controller;
		private StartScreenViewController _startScreenViewController;


		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			DefaultFrames.Initialize(Device.DeviceType);

			window = new UIWindow(UIScreen.MainScreen.Bounds);
			_controller = new ExibitInfoViewController();
			_startScreenViewController = new StartScreenViewController();

			//window.RootViewController = _controller;
			window.RootViewController = _startScreenViewController;
			window.MakeKeyAndVisible();

			return true;
		}
	}
}

