using System;
using System.Drawing;

using MonoTouch.UIKit;

namespace LoftGuide.Touch.Screens.StartScreen
{
	public class StartScreenView : UIView
	{
		private UIButton _startScan;
		private static readonly RectangleF StartScanFrame = new RectangleF(0f, 0f, 150f, 35f);

		public StartScreenView()
		{
			BackgroundColor = UIColor.Yellow;
			InitStartScanButton();

			AddSubview(_startScan);
		}

		private void InitStartScanButton()
		{
			_startScan = new UIButton(UIButtonType.RoundedRect);
			_startScan.Frame = StartScanFrame;
			_startScan.SetTitle("Cканировать", UIControlState.Normal);
			_startScan.TouchUpInside += OnStarPressed;
		}

		void OnStarPressed (object sender, EventArgs e)
		{

		}
	}
}

