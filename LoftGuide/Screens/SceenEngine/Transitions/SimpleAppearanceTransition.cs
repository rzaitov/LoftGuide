using System;
using System.Drawing;

namespace LoftGuide.Screens.Engine
{
	public class SimpleAppearanceTransition : BaseTransition
	{
		public RectangleF Frame { get; private set; }

		public SimpleAppearanceTransition(RectangleF frame)
		{
			Frame = frame;
		}

		public override void BeginAnimation()
		{
			throw new NotImplementedException();
		}

		public override void Animate()
		{
			throw new NotImplementedException();
		}

		public override void EndAnimation()
		{
			throw new NotImplementedException();
		}
	}
}

