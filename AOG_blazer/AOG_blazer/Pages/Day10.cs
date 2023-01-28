namespace AOG_blazer.Pages
{
    public partial class Day10
    {
        public string Input { get; set; }
        private string[] InputLines { get; set; }
        private int[] meassurePoints { get; set; } = new int[] { 41, 81, 121, 161, 201, 241 };
        public string Output2 { get; set; }
        public void Solve()
        {
            Output2 = string.Empty;
            InputLines = Input.Split(Environment.NewLine);
            string display = string.Empty;
            int cycle = 1;
            int register = 1;
            int signalStrenght = 0;
            int currentRow = 1;
            for (int i = 0; i < InputLines.Length; i++)
            {
                if (InputLines[i].StartsWith("noop"))
                {
                    if (meassurePoints.Contains(cycle))
                    {
                        signalStrenght += cycle * register;
                        display += Environment.NewLine;
                        currentRow = 1;
                    }
                    if (register <= currentRow && register+2 >= currentRow)
                    {
                        display += "#";
                    }
                    else
                    {
                        display += ".";
                    }

                    cycle++;
                    continue;
                }
                int addx = int.Parse(InputLines[i].Split(" ").Last());
                for (int j = 0; j < 2; j++)
                {
                    if (meassurePoints.Contains(cycle))
                    {
                        signalStrenght += cycle * register;
                        display += Environment.NewLine;
                        currentRow = 1;
                    }

                    if (register <= currentRow && register+2 >= currentRow)
                    {
                        display += "#";
                    }
                    else
                    {
                        display += ".";
                    }

                    cycle++;
                }
                register += addx;
            }
            Output2 = display;
        }
    }
}
