namespace AOG_blazer.Pages
{
    public partial class Day6
    {
        public string Input { get; set; }
        public string Output2 { get; set; }
        
        private void Solve()
        {
            int starts = 0;
            Output2 = string.Empty;
            starts = FindStart(3, 4);
            Output2 += starts.ToString() + Environment.NewLine;
            starts = FindStart(starts, 14);
            Output2 += starts.ToString() + Environment.NewLine;
        }
        public int FindStart(int startIndex, int charLeinght)
        {
            char[] chars = Input.ToCharArray();
            for (int i = startIndex; i < chars.Length; i++)
            {
                int corect = 0;
                for (int j = 0; j < charLeinght; j++)
                {

                    for (int k = 0; k < charLeinght; k++)
                    {
                        if (chars[i - j].Equals(chars[i - k]))
                        {
                            corect++;
                        }
                    }
                }
                if (corect < (charLeinght+1))
                {
                    return i + 1;
                }
            }
            return 0;
        }
    }
}
