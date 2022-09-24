using System.Runtime.CompilerServices;

namespace GameOfLife
{
    public class Life
    {
        public int[,] Grid { get; set; } = new int[Console.WindowHeight, Console.WindowWidth / 2];

        private void Initialize()
        {
            Grid[10, 11] = 1;
            Grid[10, 12] = 1;
            Grid[10, 13] = 1;

            Grid[10, 25] = 1;
            Grid[11, 25] = 1;
            Grid[12, 25] = 1;
        }

        private void Update()
        {
            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    
                }
            }
        }

        private void Draw()
        {
            Console.Clear();

            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    char sign = Grid[y, x] switch
                    {
                        0 => ' ',
                        1 => '*',
                        _ => throw new SwitchExpressionException()
                    };

                    Console.Write($"{sign} ");
                }
            }
        }

        public void Run()
        {
            Initialize();

            bool run = true;
            while (run)
            {
                Draw();
                Update();
                Console.ReadKey(true);
            }
        }
    }
}