using System;

namespace LoftGuide.Screens
{
	public class ScreenControllerBase
	{
		public ScreenControllerBase()
		{
		}

		protected void TryRaiseEvent(Action eventHandler)
		{
			if(eventHandler != null)
			{
				eventHandler();
			}
		}
	}
}

