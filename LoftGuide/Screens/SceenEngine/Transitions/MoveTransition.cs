using MonoTouch.UIKit;
using System.Drawing;

namespace LoftGuide.Screens.Engine
{
	public class MoveTransition : BaseTransition
	{
		public RectangleF? StartFrame { get; set; }

		public RectangleF? EndFrame { get; set; }

		public MoveTransition(UIViewController target) : base(target)
		{
		}

		public override void BeginAnimation()
		{
			if (StartFrame.HasValue)
			{
				Target.View.Frame = StartFrame.Value;
			}
		}

		public override void Animate()
		{
			if (EndFrame.HasValue)
			{
				Target.View.Frame = EndFrame.Value;
			}
		}

		public override void EndAnimation()
		{
		}
	}
}
