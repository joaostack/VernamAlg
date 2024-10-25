using Lolcat;

namespace CifraVernam
{
    class Program
    {
        static RainbowStyle style = new RainbowStyle();
        static Rainbow rainbow = new Rainbow(style);
        static void Main(string[] args)
        {
            string key = RandomKey(10);
            string vernam = "";
            string text = "Ola Mundo!";

            for (int i = 0; i < text.Length; i++)
            {
                vernam += (char)(text[i] ^ key[i]);
            }

            rainbow.WriteLineWithMarkup($"Chave: {key}");
            rainbow.WriteLineWithMarkup($"Texto encriptado: {ToHex(vernam)}");
        }

        static string ToHex(string input)
        {
            char[] chars = input.ToCharArray();
            string hexOutput = "";
            foreach (char c in chars)
            {
                hexOutput += ((int)c).ToString("X2");
            }

            return hexOutput;
        }

        static string RandomKey(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            string password = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }
    }
}