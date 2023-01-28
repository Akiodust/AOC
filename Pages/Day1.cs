using System.Diagnostics.CodeAnalysis;

namespace AOG_blazer.Pages
{
    public partial class Day1
    {
        public string Input { get; set; }
        private string[] InputLines { get; set; }
        private List<int> Elves { get; set; } = new List<int>();
        public string Output2 { get; set; }
        public void Solve()
        {
            Output2 = string.Empty;
            Elves.Clear();
            InputLines = Input.Split(Environment.NewLine);
            int currentElf = 0;
            int max = 0;
            for (int i = 0; i < InputLines.Length; i++)
            {
                if (string.IsNullOrEmpty(InputLines[i]))
                {
                    Elves.Add(currentElf);
                    currentElf = 0;
                }
                else
                {
                    currentElf += int.Parse(InputLines[i]);
                }
            }
            Elves.Sort();
            Output2 += Elves.Last().ToString() + Environment.NewLine;
            Output2 += Elves.OrderByDescending(x => x).Take(3).Sum();

        }
    }
}
