using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CommandingWithMvvm
{
    public partial class CodeBehind : Page
    {
        public CodeBehind()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Set initial value
            SetTextBoxValue();
        }

        /// <summary>
        /// Sets the value of the textbox to the value of the private variable on the view
        /// </summary>
        private void SetTextBoxValue()
        {
            textBox1.Text = count.ToString();
        }

        /// <summary>
        /// Private variable to hold count
        /// </summary>
        int count = 0;

        /// <summary>
        /// Event handler for the button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Update private variable
            count++;
            //Refresh Text Box from private value
            SetTextBoxValue();
        }


    }
}