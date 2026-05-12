namespace EnergeticProjectX.Classes
{
    public class Chekouts
    {
        public static void CheckOnlyNumber(KeyPressEventArgs e)
        {
            var ch = e.KeyChar;
            if (!char.IsControl(ch))
            {
                if (!char.IsNumber(ch))
                    e.Handled = true;
            }
        }

        public static void CheckPrice(KeyPressEventArgs e, string textInTextBox)
        {
            var ch = e.KeyChar;

            bool isPunctuationMarkEntered;

            if (textInTextBox.Contains(",") || textInTextBox.Contains('.'))
                isPunctuationMarkEntered = true;
            else
                isPunctuationMarkEntered = false;

            if (!char.IsControl(ch))
            {
                if (!char.IsNumber(ch) && ch != ',' && ch != '.')
                    e.Handled = true;
                else if ((ch == '.' || ch == ',') && isPunctuationMarkEntered == true)
                    e.Handled = true;
            }
        }
    }
}
