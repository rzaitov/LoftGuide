using System;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace LoftGuide.Screens.Engine
{
	public class AppearanceTransition : BaseTransition
	{
		public RectangleF Frame { get; private set; }

		public AppearanceTransition(UIViewController target, RectangleF frame)
			: base(target)
		{
			Frame = frame;
			Type = TransitionType.Appearance;
		}

		public override void BeginAnimation()
		{
			UIView v = Target.View;
			v.Frame = Frame;
			v.Superview.SendSubviewToBack(v);
		}

		public override void Animate()
		{

		}

		public override void EndAnimation()
		{

		}
	}
}

