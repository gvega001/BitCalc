namespace BitCalc
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnBinaryButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                // Toggle the button's state
                if (button.Text == "0")
                {
                    button.Text = "1";
                    button.BackgroundColor = Colors.White;
                    button.TextColor = Colors.Black;
                }
                else
                {
                    button.Text = "0";
                    button.BackgroundColor = Colors.Black;
                    button.TextColor = Colors.White;
                }

                // Update the decimal value display
                UpdateDecimalDisplay();
            }
        }

        private void UpdateDecimalDisplay()
        {
            // Construct the binary string from the button texts
            string binaryString = $"{Button0.Text}{Button1.Text}{Button2.Text}{Button3.Text}{Button4.Text}{Button5.Text}{Button6.Text}{Button7.Text}";
            // Convert the binary string to a decimal value
            int decimalValue = Convert.ToInt32(binaryString, 2);
            // Update the decimal label
            DecimalLabel.Text = $"Decimal: {decimalValue}";
        }
    }
}
