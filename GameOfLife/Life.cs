using System.Runtime.Versioning;

namespace GameOfLife;

[SupportedOSPlatform("windows")]
public class Life
{
    private string Title { get; set; }

    public Cell[,] Grid { get; set; }
    public int Height { get; set; } = 40;
    public int Width { get; set; } = 60;
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
        Console.Title = Title + "1";
        Console.WindowHeight = Height + 1;
        Console.WindowWidth = Width * 2;


        // Init all cells
        for (int y = 0; y < Grid.GetLength(0); y++)
        {
            for (int x = 0; x < Grid.GetLength(1); x++)
            {
                Grid[y, x] = new Cell(false, false);
            }
        }

        // Starting pattern
        int midY = Grid.GetLength(0) / 2;
        int midX = Grid.GetLength(1) / 2;

        Grid[midY + 1, midX - 1].IsAlive = true;
        Grid[midY - 1, midX].IsAlive = true;
        Grid[midY, midX].IsAlive = true;
        Grid[midY + 1, midX].IsAlive = true;
        Grid[midY, midX + 1].IsAlive = true;
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
            Console.WriteLine();
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

    public Life(string[] args)
    {
        try
        {
            int argHeight = int.Parse(args[0]);
            int argWidth = int.Parse(args[1]);

            Height = argHeight;
            Width = argWidth;
        }
        catch (IndexOutOfRangeException) { }
        catch (FormatException) { }

        Grid = new Cell[Height, Width];
        Title = $"Game of Life (W: {Width}, H: {Height}) - Generation: ";
    }
}