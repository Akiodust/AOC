using Radzen;
using System;

namespace AOG_blazer.Pages.day_5
{
    public partial class Day_5
    {
        public string imput { get; set; } = string.Empty;
        public string[] Configur { get; set; } 
        public List<List<char>> configur = new List<List<char>>();
        public int answer { get; set; }
        private void Uploaded(UploadProgressArgs args, string name)
        {
            if (args.Progress == 100)
            {
                foreach (var file in args.Files)
                {
                    
                }
            }
        }
        private void Solve2() 
        { 

        }
    }
}
