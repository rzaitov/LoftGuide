using System;

using MonoTouch.UIKit;

namespace LoftGuide.Screens.Engine
{
	public class DisappearanceTransition : BaseTransition
	{
		public DisappearanceTransition(UIViewController target)
			: base(target)
		{
			Type = TransitionType.Disappearance;
		}

		public override void BeginAnimation()
		{
		}

		public override void Animate()
		{
		}

		public override void EndAnimation()
		{
		}
	}
}

