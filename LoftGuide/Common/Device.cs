using System;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace LoftGuide.Touch.Common
{
	public class Device
	{
		public static float IPhoneFullScreenHeight = 480f;
		public static float IPhoneHeight = 460f;

		public static float IPhone5FullScreenHeight = 568f;
		public static float IPhone5Height = 548f;

		public static bool IsPhoneTall = false;
		public static bool IsPhone = false;
		public static bool IsPad = true;
		public static bool IsRetina = false;

		/// <summary>
		/// Offset for current device
		/// </summary>
		public static float PhoneHeightOffset = 0;
		public static float IPhone5HeightOffset = 88;

		public static DeviceTypes DeviceType { get; private set; }

		public static UIInterfaceOrientation Orientation
		{
			get
			{
				return UIApplication.SharedApplication.StatusBarOrientation;
			}
		}

		static Device()
		{
			IsPhone = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone;
			IsPhoneTall = IsPhone && UIScreen.MainScreen.Bounds.Height * UIScreen.MainScreen.Scale >= 1136;
			IsPad = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad;
			IsRetina = UIScreen.MainScreen.Scale == 2.0f;

			if(IsPhoneTall)
			{
				PhoneHeightOffset = IPhone5HeightOffset;
			}

			switch (UIDevice.CurrentDevice.UserInterfaceIdiom)
			{
				case UIUserInterfaceIdiom.Phone:
					DeviceType = IsPhoneTall ? DeviceTypes.IPhone5 : DeviceTypes.IPhone;
					break;
					
				case UIUserInterfaceIdiom.Pad:
					DeviceType = DeviceTypes.IPad;
					break;
					
				default:
					throw new DeviceExseption();
			}
		}

		public static bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
		{
			if (IsPhone)
				return toInterfaceOrientation == UIInterfaceOrientation.Portrait || toInterfaceOrientation == UIInterfaceOrientation.PortraitUpsideDown;
			else
				return toInterfaceOrientation == UIInterfaceOrientation.LandscapeLeft || toInterfaceOrientation == UIInterfaceOrientation.LandscapeRight;
		}
		
		public static float IdiomValue(float padValue, float phoneValue)
		{
			return IsPad ? padValue : phoneValue;
		}
		
		public static int IdiomValue(int padValue, int phoneValue)
		{
			return IsPad ? padValue : phoneValue;
		}
		
		public static string IdiomValue(string padValue, string phoneValue)
		{
			return IsPad ? padValue : phoneValue;
		}
		
		public static string IdiomImage(string padValue, string phoneValue, string retinaPhoneValue)
		{
			return IsPad ? padValue : IsRetina ? retinaPhoneValue : phoneValue;
		}
		

		public static PointF TranslateAccordingToOrientation(PointF location)
		{
			switch (Device.Orientation)
			{
				case UIInterfaceOrientation.Portrait:
					return location;

				case UIInterfaceOrientation.PortraitUpsideDown:
					return new PointF(768 - location.X, 1024 - location.Y);

				case UIInterfaceOrientation.LandscapeRight:
					return new PointF(location.Y, 768 - location.X);

				case UIInterfaceOrientation.LandscapeLeft:
					return new PointF(1024 - location.Y, location.X);

				default:
					return location;
			}
		}
	}

	// Характеризует девайсы с разным количеством точек (не пикселов)
	public enum DeviceTypes
	{
		IPad,
		IPhone,
		IPhone5
	}

	// Кидаем такой эксэпшн если код выполняется на девайсе для которого он не предназначен
	public class DeviceExseption : Exception
	{
	}
}

