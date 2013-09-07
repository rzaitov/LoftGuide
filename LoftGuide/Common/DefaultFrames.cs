using System;
using System.Drawing;

namespace LoftGuide.Touch.Common
{
	public class DefaultFrames
	{
		public static RectangleF MainFrame { get; private set; }
		public static readonly RectangleF MainFrameIPhone	= new RectangleF(0f, 0f, 320f, 460f);
		public static readonly RectangleF MainFrameIPhone5	= new RectangleF(0f, 0f, 320f, 548f);
		
		public static RectangleF TheLeftSideOfMainFrame;
		public static RectangleF TheRightSideOfMainFrame;

		public static RectangleF TheTopOfMainFrame;
		public static RectangleF TheBottomOfMainFrame;

		public static void Initialize(DeviceTypes deviceType)
		{
			MainFrame = deviceType == DeviceTypes.IPhone5 ? MainFrameIPhone5 : MainFrameIPhone;

			TheLeftSideOfMainFrame	= new RectangleF(new PointF(-MainFrame.Width, 0),	MainFrame.Size);
			TheRightSideOfMainFrame	= new RectangleF(new PointF(MainFrame.Width, 0),	MainFrame.Size);

			TheTopOfMainFrame = new RectangleF(new PointF(0f, -MainFrame.Height), MainFrame.Size);
			TheBottomOfMainFrame = new RectangleF(new PointF(0f, MainFrame.Height), MainFrame.Size);
		}
	}
}

