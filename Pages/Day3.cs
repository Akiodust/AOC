namespace AOG_blazer.Pages
{
    public partial class Day3
    {
        public string Input { get; set; }
        private string[] InputLines { get; set; }
        private string letterPriority { get; set; } = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string Output2 { get; set; }
        public void Solve()
        {
            Output2 = string.Empty;
            InputLines = Input.Split(Environment.NewLine);
            int priorityPart1 =0;
            int priorityPart2 = 0;
            for (int i = 0; i < InputLines.Length; i++)
            {
                string firstHalf = InputLines[i].Remove((InputLines[i].Length/2));
                string secondHalf = InputLines[i].Remove(0, (InputLines[i].Length / 2));
                foreach(char ch in firstHalf)
                {
                    if (secondHalf.Contains(ch))
                    {
                        priorityPart1 += letterPriority.IndexOf(ch);
                        break;
                    }
                }
                if (i % 3 == 0)
                {
                    foreach (char ch in InputLines[i])
                    {
                        int groupContain = 0;
                        if(InputLines[i+1].Contains(ch))
                        {
                            groupContain++;
                        }
                        if (InputLines[i + 2].Contains(ch))
                        {
                            groupContain++;
                        }
                        if (groupContain == 2) 
                        {
                            priorityPart2 += letterPriority.IndexOf(ch);
                            break;
                        }
                    }
                }
                
            }
            Output2 += priorityPart1.ToString() + Environment.NewLine;
            Output2 += priorityPart2.ToString() + Environment.NewLine;
        }
    }
}
