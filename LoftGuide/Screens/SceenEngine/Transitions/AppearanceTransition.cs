using System;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace LoftGuide.Screens.Engine
{
	public class SimpleAppearanceTransition : BaseTransition
	{
		public RectangleF Frame { get; private set; }

		public SimpleAppearanceTransition(UIViewController target, RectangleF frame)
			: base(target)
		{
			Frame = frame;
			Type = TransitionType.Appearance;
		}

		public override void BeginAnimation()
		{
			Target.View.Frame = Frame;
		}

		public override void Animate()
		{

		}

		public override void EndAnimation()
		{

		}
	}
}

