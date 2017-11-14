namespace System
{
    public static class StringExtensions
    {
        public static string ToDecimalString(this object obj)
        {
            return String.Format("{0:###,###,##0.00}", obj);
        }

        public static string ToDoubleString(this object obj)
        {
            return String.Format("{0:###,###,##0.00}", obj);
        }
    }
}
