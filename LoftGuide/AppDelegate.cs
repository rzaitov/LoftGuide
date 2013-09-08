using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using LoftGuide.Touch.Common;
using LoftGuide.Screens;

namespace LoftGuide
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		private UIWindow window;
		private MainViewController _controller;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			DefaultFrames.Initialize(Device.DeviceType);

			window = new UIWindow(UIScreen.MainScreen.Bounds);
			_controller = new MainViewController();

			window.RootViewController = _controller;
			window.MakeKeyAndVisible();

			return true;
		}
	}
}

