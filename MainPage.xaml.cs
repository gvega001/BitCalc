using System.Collections.ObjectModel;

namespace BitCalc
{
    public partial class MainPage : ContentPage
    {
        private string selectedSystem = "Binary";
        private ObservableCollection<string> _history;

        public MainPage()
        {
            InitializeComponent();
            _history = new ObservableCollection<string>();
            HistoryListView.ItemsSource = _history;
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
            int decimalValue = NumeralSystemConverter.ConvertToDecimal(binaryString, "Binary");
            // Convert the decimal value to the selected system
            string result = NumeralSystemConverter.ConvertFromDecimal(decimalValue, selectedSystem);
            // Update the decimal label
            DecimalLabel.Text = $"{selectedSystem}: {result}";
            // Add to history
            _history.Add($"{binaryString} (Binary) = {result} ({selectedSystem})");
        }

        private void OnSystemChanged(object sender, EventArgs e)
        {
            selectedSystem = SystemPicker.SelectedItem.ToString();
            UpdateDecimalDisplay();
        }

        private void OnAnd(object sender, EventArgs e)
        {
            PerformBitwiseOperation(BitwiseOperations.And);
        }

        private void OnOr(object sender, EventArgs e)
        {
            PerformBitwiseOperation(BitwiseOperations.Or);
        }

        private void OnXor(object sender, EventArgs e)
        {
            PerformBitwiseOperation(BitwiseOperations.Xor);
        }

        private void OnNot(object sender, EventArgs e)
        {
            int a = NumeralSystemConverter.ConvertToDecimal(GetBinaryString(), "Binary");
            int result = BitwiseOperations.Not(a);
            string resultString = NumeralSystemConverter.ConvertFromDecimal(result, selectedSystem);
            DecimalLabel.Text = $"{selectedSystem}: {resultString}";
            _history.Add($"NOT {a} (Binary) = {resultString} ({selectedSystem})");
        }

        private void PerformBitwiseOperation(Func<int, int, int> operation)
        {
            int a = NumeralSystemConverter.ConvertToDecimal(GetBinaryString(), "Binary");
            // For demonstration, we'll use 8 as the second operand
            int b = 8;
            int result = operation(a, b);
            string resultString = NumeralSystemConverter.ConvertFromDecimal(result, selectedSystem);
            DecimalLabel.Text = $"{selectedSystem}: {resultString}";
            _history.Add($"{a} AND {b} (Binary) = {resultString} ({selectedSystem})");
        }

        private string GetBinaryString()
        {
            return $"{Button0.Text}{Button1.Text}{Button2.Text}{Button3.Text}{Button4.Text}{Button5.Text}{Button6.Text}{Button7.Text}";
        }
    }
}
