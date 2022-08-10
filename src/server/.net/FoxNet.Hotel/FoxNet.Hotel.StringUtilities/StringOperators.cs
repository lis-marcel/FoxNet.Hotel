using System.Text;

namespace FoxNet.Hotel.StringUtilities
{
    public class StringOperators
    {
        private const string WORD_CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static Random random = new Random();

        public static string GetRndWord(int maxLength)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < maxLength; i++)
            {
                int randomIndex = random.Next(0, WORD_CHARS.Length);
                sb.Append(WORD_CHARS[randomIndex]);
            }

            return sb.ToString();
        }
    }
}