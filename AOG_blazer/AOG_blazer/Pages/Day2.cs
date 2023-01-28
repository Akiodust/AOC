namespace AOG_blazer.Pages
{
    public partial class Day2
    {
        public string Input { get; set; }
        private string[] InputLines { get; set; }
        public string Output2 { get; set; }

        public void Solve()
        {
            Output2 = string.Empty;
            InputLines = Input.Split(Environment.NewLine);
            string[] options = new string[]{ "AZ,0X", "BX,0X", "CY,0X", "AX,3Y", "BY,3Y", "CZ,3Y", "CX,6Z", "AY,6Z", "BZ,6Z" };
            int currentScorePart1 = 0;
            int currentScorePart2 = 0;
            for (int i = 0; i < InputLines.Length; i++)
            {
                string chars = InputLines[i].Replace(" ", string.Empty);
                foreach (string option in options)
                {
                    if (option.StartsWith(chars))
                    {
                        currentScorePart1 += (int)char.GetNumericValue(option[3]);
                        break;
                    }
                }
                currentScorePart1 += charValue(chars[1]);
                foreach (string option in options)
                {
                    if (option[0].Equals(chars[0]) && option[4].Equals(chars[1])) 
                    {
                        currentScorePart2 += (int)char.GetNumericValue(option[3]);
                        currentScorePart2 += charValue(option[1]);
                        break;
                    }
                } 
            }
            Output2 += currentScorePart1 + Environment.NewLine;
            Output2 += currentScorePart2 + Environment.NewLine;

        }
        private int charValue(char letter)
        {
            switch (letter)
            {
                case 'X':
                    return 1;
                case 'Y':
                    return 2;
                case 'Z':
                    return 3;
            }
            return 0;
        }
    }
}
