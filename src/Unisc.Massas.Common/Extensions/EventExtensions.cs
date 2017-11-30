using System.Windows.Input;

namespace Unisc.Massas.Core.Extensions
{
    public static class EventExtensions
    {
        public static bool IsNumber(this KeyEventArgs e)
        {
            return e.Key == Key.NumPad0
                || e.Key == Key.NumPad1
                || e.Key == Key.NumPad2
                || e.Key == Key.NumPad3
                || e.Key == Key.NumPad4
                || e.Key == Key.NumPad5
                || e.Key == Key.NumPad6
                || e.Key == Key.NumPad7
                || e.Key == Key.NumPad8
                || e.Key == Key.NumPad9
                || e.Key == Key.D0
                || e.Key == Key.D1
                || e.Key == Key.D2
                || e.Key == Key.D3
                || e.Key == Key.D4
                || e.Key == Key.D5
                || e.Key == Key.D6
                || e.Key == Key.D7
                || e.Key == Key.D8
                || e.Key == Key.D9;
        }
    }
}
