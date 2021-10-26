namespace endpoints
{
    public class Pluralization
    {
        public static string GetPluralization(int n, string form1, string form2, string form3)
        {
            if (n % 100 > 10 && n % 100 < 15) { return form3; }
            else if (n % 10 == 1) { return form1; }
            else if (n % 10 > 1 && n % 10 < 5) { return form2; }
            else
            {
                return form3;
            }
        }
    }
}