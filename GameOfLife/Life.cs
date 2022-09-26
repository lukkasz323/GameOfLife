namespace GameOfLife
{
    public class Life
    {
        public Cell[,] Grid { get; set; } = new Cell[Console.WindowHeight, Console.WindowWidth / 2];
        public int Generation { get; set; } = 0;

        private void Initialize()
        {
            // Init all cells
            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    Grid[y, x] = new Cell(false, false);
                }
            }

            Grid[16, 24].IsAlive = true;
            Grid[14, 25].IsAlive = true;
            Grid[15, 25].IsAlive = true;
            Grid[16, 25].IsAlive = true;
            Grid[15, 26].IsAlive = true;
        }

        private void Update()
        {
            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    ref Cell cell = ref Grid[y, x];

                    cell.IsMarked = cell.CanBeToggled(Grid, y, x);
                }
            }

            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    ref Cell cell = ref Grid[y, x];

                    if (cell.IsMarked)
                    {
                        cell.IsAlive = !cell.IsAlive;
                    }
                }
            }

            Generation++;
        }

        private void Draw()
        {
            Console.Clear();

            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    ref Cell cell = ref Grid[y, x];

                    char sign = cell.IsAlive switch
                    {
                        false => ' ',
                        true => '*'
                    };

                    Console.Write($"{sign} ");
                }
            }
        }

        public void Run()
        {
            Initialize();
            while (true)
            {
                Draw();
                Update();
                Thread.Sleep(200);
            }
        }
    }
}