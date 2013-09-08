using MonoTouch.UIKit;

namespace LoftGuide.Screens.Engine
{
	public interface ITransition
	{
		UIViewController Target { get; }

		TransitionType Type { get; }

		void BeginAnimation();

		void Animate();

		void EndAnimation();
	}
}
