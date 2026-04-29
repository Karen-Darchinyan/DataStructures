using static System.Net.Mime.MediaTypeNames;

namespace MyHashFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "lorem ipsum dolor";

            Console.WriteLine(HashingString(str));

            string input = string.Empty;

            while (!input.Equals("quit"))
            {
                Console.WriteLine("> ");
                input = Console.ReadLine();

                Console.WriteLine($"Folding: {FoldingHash(input)}");
            }
        }

        static int FoldingHash(string input)
        {
            int hashValue = 0;
            int startIndex = 0;
            int currentFourBytes;

            do
            {
                currentFourBytes = GetNextBytes(startIndex, input);
                unchecked
                {
                    hashValue += currentFourBytes;
                }
                startIndex += 4;
            } while (currentFourBytes != 0);

            return hashValue;
        }

        static int GetNextBytes(int startIndex, string str)
        {
            int currentFourBytes = 0;

            currentFourBytes += GetBytes(str, startIndex);
            Console.WriteLine("GetBytes(str, startIndex): " + GetBytes(str, startIndex));
            Console.WriteLine("currentFourBytes: " + currentFourBytes);
            currentFourBytes += GetBytes(str, startIndex + 1) << 8;
            currentFourBytes += GetBytes(str, startIndex + 2) << 16;
            currentFourBytes += GetBytes(str, startIndex + 3) << 24;
            Console.WriteLine("currentFourBytes: " + currentFourBytes);

            return currentFourBytes;
        }

        static int GetBytes(string str, int index)
        {
            if (index < str.Length)
            {
                return (int)str[index];
            }

            return 0;
        }

        /// <summary>
        /// Իմ գրած տարբերակը, սակայն սխալ է, քանի որ ես դարձնում եմ տեքստ և նոր աշխատում դրանց հետ, դա ավելի է բարդեցնում
        /// Հաշվում է տողի hash-ը՝ 4 սիմվոլանոց բլոկներով (առանց binary conversion-ի)
        /// </summary>
        /// <param name="s">Մուտքային տող</param>
        /// <returns>Հաշված hash արժեք</returns>
        public static decimal HashingString(string s)
        {
            decimal dec = 0;
            int charCount = 4;
            string str = string.Empty;
            for (int i = 0; i < s.Length; i += 4)
            {
                if(i + 4 > s.Length)
                    str = s.Substring(i, s.Length - i);
                else
                    str = s.Substring(i, charCount);

                Console.WriteLine(BinaryToDecimal(Binary(str)));
                
                dec += BinaryToDecimal(Binary(str));
            }

            return dec;
        }

        public static string Binary(string s)
        {
            int sum = 0;
            string binary = string.Empty;
            foreach (char ch in s)
            {
                string bin = Convert.ToString(ch, 2).PadLeft(8, '0');

                binary += bin;
            }

            return binary;
        }
        public static decimal BinaryToDecimal(string binary)
        {
            decimal dec = 0;                                          

            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '0')
                {
                    dec += 0;
                }
                else
                {
                    int x = 1;
                    for (int j = binary.Length - 1 - i; j > 0; j--)
                    {
                        x *= 2;
                    }
                  
                    dec += x;
                }
            }

            return dec;
        }
    }
}
