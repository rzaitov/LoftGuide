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
		private ITransition[] _fromScanScreenToStartScreen;

		private ITransition[] _fromScanScreenToInfoScreen;
		private ITransition[] _fromInfoScreenToScanScreen;

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
			_startScreenController.OnStartScanPressed += GoFromStartScreenToScanScreen;
			_startScreenViewController = new StartScreenViewController(_startScreenController);

			_scanController = new ScanController();
			_scanController.ScanCanceled += GoFromScanScreenToStartScreen;
			_scanController.ScanCompletedWithResult += GoFromScanScreenToInfoScreen;
			_scannerViewController = new ZXingScannerViewController(_scanController);

			_exibitInfoController = new ExibitInfoController();
			_exibitInfoController.ShowScanScreen += GoFromInfoScreenToScanScreen;
			_exibitInfoViewController = new ExibitInfoViewController(_exibitInfoController);
		}

		void GoFromInfoScreenToScanScreen ()
		{
			PerformTransitions(0.5f, _fromInfoScreenToScanScreen);
		}

		void GoFromScanScreenToInfoScreen ()
		{
			InvokeOnMainThread(() => PerformTransitions(0.5f, _fromScanScreenToInfoScreen));
		}

		void GoFromScanScreenToStartScreen ()
		{
			PerformTransitions(0.5f, _fromScanScreenToStartScreen);
		}

		void GoFromStartScreenToScanScreen ()
		{
			PerformTransitions(0.5f, _fromStartScreenToScanScreen);
		}

		private void InitTransitions()
		{
			ITransition hideScanScreen = new MoveTransition(_scannerViewController) { EndFrame = DefaultFrames.TheBottomOfMainFrame, Type = TransitionType.Disappearance };
			ITransition showScanScreen = new MoveTransition(_scannerViewController) { StartFrame = DefaultFrames.TheBottomOfMainFrame, EndFrame = DefaultFrames.MainFrame, Type = TransitionType.Appearance };

			_startScreenApereance = new ITransition[]
			{
				new AppearanceTransition(_startScreenViewController, DefaultFrames.MainFrame)
			};

			_fromStartScreenToScanScreen = new ITransition[]
			{
				showScanScreen,
				new DisappearanceTransition(_startScreenViewController)
			};

			_fromScanScreenToStartScreen = new ITransition[]
			{
				hideScanScreen,
				new AppearanceTransition(_startScreenViewController, DefaultFrames.MainFrame),
			};

			_fromScanScreenToInfoScreen = new ITransition[]
			{
				hideScanScreen,
				new AppearanceTransition(_exibitInfoViewController, DefaultFrames.MainFrame),
			};

			_fromInfoScreenToScanScreen = new ITransition[]
			{
				showScanScreen,
				new DisappearanceTransition(_exibitInfoViewController),
			};
		}

	}
}

