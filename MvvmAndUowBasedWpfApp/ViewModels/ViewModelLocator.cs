using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace MvvmAndUowBasedWpfApp.ViewModels
{
    public class ViewModelLocator
    {
        #region Constructors
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
        }
        #endregion
        #region Properties
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        #endregion
        #region Methods
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
        #endregion
    }
}