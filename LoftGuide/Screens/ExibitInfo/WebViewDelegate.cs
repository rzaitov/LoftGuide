using System;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace LoftGuide.Screens.ExibitInfoScreen
{
	public class WebViewDelegate : UIWebViewDelegate
	{
		public WebViewDelegate()
		{
		}

		public override bool ShouldStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
		{
			return true;
		}
	}
}

