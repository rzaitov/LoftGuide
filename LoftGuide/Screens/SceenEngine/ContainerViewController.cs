using MonoTouch.UIKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoftGuide.Screens.Engine
{
	public class ContainerViewController : UIViewController
	{
		[Obsolete ("Deprecated in iOS 6.0")]
		public override bool AutomaticallyForwardAppearanceAndRotationMethodsToChildViewControllers
		{
			get
			{
				return false;
			}
		}

		public override bool ShouldAutomaticallyForwardAppearanceMethods
		{
			get
			{
				return false;
			}
		}

		protected void PerformTransitions(double duration, params ITransition[] transitions)
		{
			BeginTransitions(transitions);

			UIView.Animate(duration, () => AnimateTransitions(transitions), () => EndTransitions(transitions));
		}

		private void AnimateTransitions(IEnumerable<ITransition> transitions)
		{
			foreach (var transition in transitions)
			{
				transition.Animate();
			}
		}

		private void BeginTransitions(IEnumerable<ITransition> transitions)
		{
			View.UserInteractionEnabled = false;

			foreach (var transition in transitions)
			{
				switch (transition.Type)
				{
					case TransitionType.Appearance:
						AddChildViewController(transition.Target);
						View.AddSubview(transition.Target.View);
						break;
					case TransitionType.Disappearance:
						transition.Target.WillMoveToParentViewController(null);
						break;
					case TransitionType.AppearanceUnder:
						AddChildViewController(transition.Target);
						View.AddSubview(transition.Target.View);
						View.SendSubviewToBack(transition.Target.View);
						transition.Target.ViewWillAppear(true);
						break;
				}

				transition.BeginAnimation();

				if (transition.Type != TransitionType.Normal)
				{
					transition.Target.BeginAppearanceTransition(transition.Type == TransitionType.Appearance, true);
				}
			}
		}

		private void EndTransitions(IEnumerable<ITransition> transitions)
		{
			View.UserInteractionEnabled = true;

			foreach (var transition in transitions)
			{
				if (transition.Type != TransitionType.Normal)
				{
					transition.Target.EndAppearanceTransition();
				}

				transition.EndAnimation();

				switch (transition.Type)
				{
					case TransitionType.Appearance:
						transition.Target.DidMoveToParentViewController(this);
						break;
					case TransitionType.Disappearance:
						transition.Target.View.RemoveFromSuperview();
						transition.Target.RemoveFromParentViewController();
						break;
					case TransitionType.AppearanceUnder:
						transition.Target.DidMoveToParentViewController(this);
						break;
				}
			}
		}
	}
}
