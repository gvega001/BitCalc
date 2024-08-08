public static class NumeralSystemConverter
{
    public static string ConvertFromDecimal(int decimalNumber, string system)
    {
        return system switch
        {
            "Binary" => Convert.ToString(decimalNumber, 2),
            "Hexadecimal" => Convert.ToString(decimalNumber, 16).ToUpper(),
            "Octal" => Convert.ToString(decimalNumber, 8),
            _ => decimalNumber.ToString()
        };
    }

    public static int ConvertToDecimal(string number, string system)
    {
        return system switch
        {
            "Binary" => Convert.ToInt32(number, 2),
            "Hexadecimal" => Convert.ToInt32(number, 16),
            "Octal" => Convert.ToInt32(number, 8),
            _ => int.Parse(number)
        };
    }
}
