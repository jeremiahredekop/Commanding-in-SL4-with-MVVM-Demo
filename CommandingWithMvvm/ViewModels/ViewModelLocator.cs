

namespace CommandingWithMvvm.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// Use the <strong>mvvmlocatorproperty</strong> snippet to add ViewModels
    /// to this locator.
    /// </para>
    /// <para>
    /// In Silverlight and WPF, place the ViewModelLocator in the App.xaml resources:
    /// </para>
    /// <code>
    /// &lt;Application.Resources&gt;
    ///     &lt;vm:ViewModelLocator xmlns:vm="clr-namespace:CommandingWithMvvm.ViewModels"
    ///                                  x:Key="Locator" /&gt;
    /// &lt;/Application.Resources&gt;
    /// </code>
    /// <para>
    /// Then use:
    /// </para>
    /// <code>
    /// DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
    /// </code>
    /// <para>
    /// You can also use Blend to do all this with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {

        private static Binding1ViewModel _binding1ViewModel;

        /// <summary>
        /// Gets the Binding1ViewModel property.
        /// </summary>
        public static Binding1ViewModel Binding1ViewModelStatic
        {
            get
            {
                if (_binding1ViewModel == null)
                {
                    CreateBinding1ViewModel();
                }

                return _binding1ViewModel;
            }
        }

        /// <summary>
        /// Gets the Binding1ViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public Binding1ViewModel Binding1ViewModel
        {
            get
            {
                return Binding1ViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Binding1ViewModel property.
        /// </summary>
        public static void ClearBinding1ViewModel()
        {
            _binding1ViewModel.Cleanup();
            _binding1ViewModel = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the Binding1ViewModel property.
        /// </summary>
        public static void CreateBinding1ViewModel()
        {
            if (_binding1ViewModel == null)
            {
                _binding1ViewModel = new Binding1ViewModel();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            ClearBinding1ViewModel();
        }

    }
}