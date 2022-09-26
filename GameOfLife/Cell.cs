namespace GameOfLife
{
    public class Cell
    {
        public bool IsAlive { get; set; }
        public bool IsMarked { get; set; }

        public bool InDanger(Cell[,] Grid, int y, int x)
        {
            if (!IsAlive) { throw new InvalidOperationException("Cell must be alive"); }

            var neighbours = new (int, int)[] // (y, x) offsets
            {
                (-1, -1),
                (-1, 0),
                (-1, 1),
                (0, -1),
                (0, 1),
                (1, -1),
                (1, 0),
                (1, 1)
            };
            int neighbours_count = 0;

            foreach ((int, int) offset in neighbours)
            {
                Cell neighbour_cell = Grid[y + offset.Item1, x + offset.Item2];

                if (neighbour_cell.IsAlive)
                {
                    neighbours_count++;
                }
            }

            return !(neighbours_count == 2 || neighbours_count == 3);
        }

        public bool CanBeRevived(Cell[,] Grid, int y, int x)
        {
            if (IsAlive) { throw new InvalidOperationException("Cell must be dead"); }

            var neighbours = new (int, int)[] // (y, x) offsets
            {
                (-1, -1),
                (-1, 0),
                (-1, 1),
                (0, -1),
                (0, 1),
                (1, -1),
                (1, 0),
                (1, 1)
            };
            int neighbours_count = 0;

            foreach ((int, int) offset in neighbours)
            {
                try
                {
                    Cell neighbour_cell = Grid[y + offset.Item1, x + offset.Item2];

                    if (neighbour_cell.IsAlive)
                    {
                        neighbours_count++;
                    }
                }
                catch (IndexOutOfRangeException) { }
            }

            return (neighbours_count == 3);
        }

        public Cell(bool isAlive, bool isMarked)
        {
            IsAlive = isAlive;
            IsMarked = isMarked;
        }
    }
}