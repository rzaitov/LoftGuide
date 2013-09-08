using MonoTouch.UIKit;

namespace LoftGuide.Screens.Engine
{
	public abstract class BaseTransition : ITransition
	{
		public UIViewController Target { get; private set; }

		public TransitionType Type { get; set; }

		protected BaseTransition(UIViewController target)
		{
			Target = target;
			Type = TransitionType.Normal;
		}

		public abstract void BeginAnimation();

		public abstract void Animate();

		public abstract void EndAnimation();
	}
}
