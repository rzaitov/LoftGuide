using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using LoftGuide.Touch.Common;
using LoftGuide.Screens.Engine;
using LoftGuide.Screens.StartScreen;
using LoftGuide.Screens.ScanScreen;
using LoftGuide.Screens.ExibitInfoScreen;

namespace LoftGuide.Screens
{
	public class MainViewController : ContainerViewController
	{
		private ITransition[] _startScreenApereance;
		private ITransition[] _fromStartScreenToScanScreen;

		private StartScreenViewController _startScreenViewController;
		private StartScreenController _startScreenController;

		private ZXingScannerViewController _scannerViewController;
		private ScanController _scanController;

		private ExibitInfoViewController _exibitInfoViewController;
		private ExibitInfoController _exibitInfoController;

		public MainViewController()
		{
			InitScreens();
			InitTransitions();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = UIColor.White;
			PerformTransitions(0, _startScreenApereance);
		}

		private void InitScreens()
		{
			_startScreenController = new StartScreenController();
			_startScreenViewController = new StartScreenViewController(_startScreenController);

			_scanController = new ScanController();
			_scannerViewController = new ZXingScannerViewController(_scanController);

			_exibitInfoController = new ExibitInfoController();
			_exibitInfoViewController = new ExibitInfoViewController(_exibitInfoController);
		}

		private void InitTransitions()
		{
			_startScreenApereance = new ITransition[]
			{
				new SimpleAppearanceTransition(_startScreenViewController, DefaultFrames.MainFrame)
			};
		}

	}
}

