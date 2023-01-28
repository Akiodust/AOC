namespace AOG_blazer.Pages
{
    public partial class Day4
    {
        public string Input { get; set; }
        private string[] InputLines { get; set; }
        public string Output2 { get; set; }
        public void Solve()
        {
            Output2 = string.Empty;
            InputLines = Input.Split(Environment.NewLine);
            int fullyContains = 0;
            int partialyContains = 0;
            for (int i = 0; i < InputLines.Length; i++)
            {
                string interval1 = InputLines[i].Split(',').First();
                string interval2 = InputLines[i].Split(',').Last();
                int firstCompare1 = int.Parse(interval1.Split('-').First());
                int firstCompare2 = int.Parse(interval2.Split('-').First());
                int secondCompare1 = int.Parse(interval1.Split('-').Last());
                int secondCompare2 = int.Parse(interval2.Split('-').Last());
                fullyContains += Compare(firstCompare1, secondCompare1, firstCompare2, secondCompare2);
                partialyContains += CompareUltra(firstCompare1, secondCompare1, firstCompare2, secondCompare2);
            }
            Output2 += fullyContains.ToString() + Environment.NewLine;
            Output2 += partialyContains.ToString() + Environment.NewLine;
        }
        private int Compare(int first, int second, int third, int forth)
        {
            if (first <= third && second >= forth)
            {
                return 1;
            }
            if (third <= first && forth >= second)
            {
                return 1;
            }
            return 0;
        }
        private int CompareUltra(int first, int second, int third, int forth)
        {
            if (first <= third && second >= third)
            {
                return 1;
            }
            if (first <= forth && second >= forth)
            {
                return 1;
            }
            if (third <= first && forth >= first)
            {
                return 1;
            }
            if (third <= second && forth >= second)
            {
                return 1;
            }
            return 0;
        }
    }
}
