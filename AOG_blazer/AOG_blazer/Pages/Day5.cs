using System.Linq.Dynamic.Core;
using System.Runtime.InteropServices;

namespace AOG_blazer.Pages
{
    public partial class Day5
    {
        public string Input { get; set; }
        private string[] InputLines { get; set; }
        private string[] Storage9000 { get; set; } = new string[9];
        private string[] Storage9001 { get; set; } = new string[9];
        public string Output { get; set; }

        public void Solve()
        {
            Output = string.Empty;
            InputLines = Input.Split(Environment.NewLine);
            int shift = 0;
            for (int i = 0; i < InputLines.Length; i++)
            {
                if (string.IsNullOrEmpty(InputLines[i]))
                {
                    shift = i + 1;
                    break;
                }
                char[] chars= InputLines[i].ToCharArray();
                for (int j = 0; j < InputLines[i].Length; j+=4)
                {
                    char c = chars[j + 1];
                    if(char.IsLetter(c))
                    {
                        Storage9000[j / 4] += c.ToString();
                        Storage9001[j / 4] += c.ToString();
                    }
                }
            }
            for (int i = 0; i < Storage9000.Length; i++)
            {
                Storage9000[i] = ReverseString(Storage9000[i]);
                Storage9001[i] = ReverseString(Storage9001[i]);
            }

            for (int i = shift; i < InputLines.Length; i++)
            {
                if (string.IsNullOrEmpty(InputLines[i]))
                {
                    break;
                }
                string line = InputLines[i];
                line = line.Replace("move ", "");
                line = line.Replace(" from ", "/");
                line = line.Replace(" to ", "/");
                string[] parameter = line.Split('/');
                Storage9000 = InstructionEXE(Storage9000, int.Parse(parameter[0]), int.Parse(parameter[1]), int.Parse(parameter[2]), true);
                Storage9001 = InstructionEXE(Storage9001, int.Parse(parameter[0]), int.Parse(parameter[1]), int.Parse(parameter[2]), false);
            }
            for (int i = 0; i < Storage9000.Length; i++)
            {
                Output += Storage9000[i].ToCharArray().Last().ToString(); 
            }
            Output += Environment.NewLine;
            for (int i = 0; i < Storage9001.Length; i++)
            {
                Output += Storage9001[i].ToCharArray().Last().ToString();
            }

        }

        private string ReverseString(string text)
        {
                char[] chars = text.ToCharArray();
                Array.Reverse(chars);
                return new string(chars);
        }

        private string[] InstructionEXE(string[] storage, int count, int from, int to, bool part)
        {
            string crane = storage[from - 1].Substring(storage[from - 1].Length - count);
            storage[from - 1] = storage[from - 1].Remove(storage[from - 1].Length - count);
            if(part)
            {
                storage[to - 1] += ReverseString(crane);
            }
            else
            {
                storage[to - 1] += crane;
            }
            return storage;
        }

    }
}
