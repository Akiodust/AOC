namespace AOG_blazer.Pages
{
    public partial class Day8
    {
        public string Input { get; set; }
        private string[] InputLines { get; set; }
        private List<List<int>> Map { get; set; } = new();
        public string Output2 { get; set; }
        public void Solve()
        {
            Map.Clear();
            Output2 = string.Empty;
            InputLines = Input.Split(Environment.NewLine);
            for (int i = 0; i < InputLines.Length; i++)
            {
                List<int> lineTrees = new List<int>();
                for (int j = 0; j < InputLines[i].ToArray().Length; j++)
                {
                    lineTrees.Add((int)char.GetNumericValue(InputLines[i].ToArray()[j]));
                }
                Map.Add(lineTrees);
            }
            int visibleTrees = 0;
            int maxRating = 0;
            for (int i = 1; i < Map.Count - 1; i++) 
            {
                for (int j = 1; j < Map[i].Count - 1; j++)
                {
                    int[] visibles = new int[4];
                    int[] scores = new int[4];
                    for (int k = 1; k <= i; k++)
                    {
                        if (Map[i][j] <= Map[i - k][j])
                        {
                            visibles[0]++;
                            scores[0]++;
                            break;
                        }
                        scores[0]++;
                    }
                    for (int k = 1; k <= j; k++)
                    {
                        if (Map[i][j] <= Map[i][j - k])
                        {
                            visibles[1]++;
                            scores[1]++;
                            break;
                        }
                        scores[1]++;
                    }
                    for (int k = 1; k <= Map[i].Count-i-1; k++)
                    {
                        if (Map[i][j] <= Map[i + k][j])
                        {
                            visibles[2]++;
                            scores[2]++;
                            break;
                        }
                        scores[2]++;
                    }
                    for (int k = 1; k <= Map.Count-j-1; k++)
                    {
                        if (Map[i][j] <= Map[i][j + k])
                        {
                            visibles[3]++;
                            scores[3]++;
                            break;
                        }
                        scores[3]++;
                    }
                    foreach(var visible in visibles)
                    {
                        if(visible == 0)
                        {
                            visibleTrees++;
                            int score = 1;
                            foreach(int sc in scores)
                            {
                                score *= sc;
                            }
                            if (score > maxRating)
                            {
                                maxRating = score;
                            }
                            break;
                        }
                    }
                }
            }
            visibleTrees += Map.Count * 2 + (Map[0].Count - 2) * 2;
            Output2 = visibleTrees.ToString()+Environment.NewLine;
            Output2 += maxRating.ToString();
        }
    }
}
