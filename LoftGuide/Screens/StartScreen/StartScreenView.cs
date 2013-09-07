using System;
using System.Drawing;

using MonoTouch.UIKit;

using LoftGuide.Touch.Common;

namespace LoftGuide.Screens.StartScreen
{
	public class StartScreenView : UIView
	{
		private UIButton _startScan;
		private static readonly float StartScanLocationY = 30f;
		private static readonly SizeF StartScanSize = new SizeF(150f, 35f);

		public StartScreenView(RectangleF frame)
		{
			Frame = frame;
			BackgroundColor = UIColor.Yellow;
			InitStartScanButton();

			AddSubview(_startScan);
		}

		private void InitStartScanButton()
		{
			_startScan = new UIButton(UIButtonType.RoundedRect);
			_startScan.SetSize(StartScanSize);
			_startScan.CenterHorizontally(this);
			_startScan.SetFrameY(StartScanLocationY);

			_startScan.SetTitle("Cканировать", UIControlState.Normal);
			_startScan.TouchUpInside += OnStarPressed;
		}

		void OnStarPressed (object sender, EventArgs e)
		{

		}
	}
}

