namespace AOG_blazer.Pages
{
    public partial class Day7
    {
        public string Input { get; set; }
        private string[] InputLines { get; set; }
        private Dictionary<string, List<string>> Dirs { get; set; } = new();
        public string Output2 { get; set; }
        private List<int> SmallDirs { get; set; } = new List<int>();
        private const int diskSize = 70000000;
        private const int updateSize = 30000000;

        public void Solve()
        {
            Output2 = string.Empty;
            InputLines = Input.Split(Environment.NewLine);
            string currentDir = string.Empty;
            for (int i = 0; i < InputLines.Length; i++)
            {
                string line = InputLines[i];
                if (line.StartsWith("$ cd .."))
                {
                    currentDir = currentDir.Remove(currentDir.LastIndexOf("/"));
                    continue;
                }
                if (line.StartsWith("$ cd "))
                {
                    line = line.Replace("$ cd ", string.Empty);
                    currentDir += "/" + line;
                    continue;
                }
                List<string> items = new List<string>();
                i++;
                for (int j = i; j < InputLines.Length; i = j++)
                {
                    if (InputLines[j].StartsWith("$"))
                    {
                        break;
                    }
                    items.Add(InputLines[j]);
                }

                
                Dirs.Add(currentDir, items);
            }
            countSize(Dirs["//"].ToArray(), "//", true);
            Output2 = SmallDirs.Sum().ToString() + Environment.NewLine;
            SmallDirs.Clear();

            countSize(Dirs["//"].ToArray(), "//", false);
            SmallDirs.Sort();
            int neededToDelete = ((diskSize - SmallDirs.Last()) - updateSize) * -1;
            foreach (int dirSize in SmallDirs)
            {
                if(dirSize > neededToDelete)
                {
                    Output2 += dirSize.ToString() + Environment.NewLine;
                    break;
                }
            }
            
        }

        private int countSize(string[] values, string key, bool part)
        {
            int currentSize = 0;
            foreach (var value in values)
            {
                if (value.StartsWith("dir "))
                {
                    string newkey = key + "/" + value.Replace("dir ", string.Empty);
                    currentSize += countSize(Dirs[newkey].ToArray(), newkey, part);
                }
                else
                {
                    currentSize += int.Parse(value.Split(' ').First());
                }
            }
            if(part)
            {
                if ((currentSize < 100000))
                {
                    SmallDirs.Add(currentSize);
                }
            }
            else
            {
                SmallDirs.Add(currentSize);
            }
            return currentSize;
        }

    }
}
