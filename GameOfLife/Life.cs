namespace GameOfLife
{
    public class Life
    {
        private const string Title = "Game of Life (Enclosed) - Generation: ";

        public Cell[,] Grid { get; set; } = new Cell[Console.WindowHeight - 1, Console.WindowWidth / 2];
        public int Generation { get; set; } = 1;

        public void MarkCells()
        {
            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    ref Cell cell = ref Grid[y, x];

                    cell.IsMarked = cell.CanBeToggled(Grid, y, x);
                }
            }
        }

        public void ToggleMarkedCells()
        {
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
        }

        public void Initialize()
        {
            Console.Title = Life.Title + "1";

            // Init all cells
            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    Grid[y, x] = new Cell(false, false);
                }
            }

            // Starting pattern
            Grid[16, 24].IsAlive = true;
            Grid[14, 25].IsAlive = true;
            Grid[15, 25].IsAlive = true;
            Grid[16, 25].IsAlive = true;
            Grid[15, 26].IsAlive = true;
        }

        public void Update()
        {
            MarkCells();
            ToggleMarkedCells();

            Generation++;
            Console.Title = Title + Generation;
        }

        public void Draw()
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
            Draw();
            Thread.Sleep(1000);
            while (true)
            {
                Update();
                Draw();
                Thread.Sleep(200);
            }
        }
    }
}