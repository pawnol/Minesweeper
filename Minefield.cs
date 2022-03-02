using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    /// <summary>
    /// Stores all the cells in the minefield and provides an interface to interact with
    /// the cells.
    /// </summary>
    class Minefield
    {
        /// <summary>
        /// Backing field that stores the total number of bombs in the minefield.
        /// </summary>
        private int _totalBombs;
        /// <summary>
        /// Retieves the total number of bombs in the minefield.
        /// </summary>
        public int TotalBombs
        {
            get => _totalBombs;
        }

        /// <summary>
        /// Backing field that stores all the cells in the minefield.
        /// </summary>
        private Cell[,] field;

        /// <summary>
        /// Creates a new minefield with a given number of rows, columns, and bombs.
        /// </summary>
        /// <param name="rows">Number of rows within the minefield.</param>
        /// <param name="columns">Number of columns within the minefield.</param>
        /// <param name="totalBombs">Number of bombs within the minefield.</param>
        public Minefield(int rows, int columns, int totalBombs)
        {
            // Initialize all cells.
            field = new Cell[rows, columns];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = new Cell(i, j);
                }
            }

            // Initialize all cells with bombs.
            _totalBombs = totalBombs;
            Random random = new Random();
            for (int i = 0; i < _totalBombs; i++)
            {
                bool addedBomb = false;
                while (!addedBomb)
                {
                    int row = random.Next(0, rows);
                    int column = random.Next(0, columns);
                    if (!field[row, column].HasBomb)
                    {
                        field[row, column].HasBomb = true;
                        addedBomb = true;
                    }
                }
            }

            // Initial cell numbers.
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j].HasBomb)
                    {
                        field[i, j].SurroundingBombs = -1;
                        continue;
                    }
                    int count = 0;
                    for (int k = i - 1; k <= i + 1; k++)
                    {
                        for (int m = j - 1; m <= j + 1; m++)
                        {
                            if (k >= 0
                                && k < field.GetLength(0)
                                && m >= 0
                                && m < field.GetLength(1)
                                && field[k, m].HasBomb)
                            {
                                count++;
                            }
                        }
                    }
                    field[i, j].SurroundingBombs = count;
                }
            }
        }

        /// <summary>
        /// Retieves a cell from the minefield.
        /// </summary>
        /// <param name="row">Row rank of the cell to retieve.</param>
        /// <param name="column">Column rank of the cell to retrieve</param>
        /// <returns>The cell at the given row andn column ranks.</returns>
        public Cell GetCell(int row, int column)
        {
            return field[row, column];
        }

        /// <summary>
        /// Determines whether all the mines in the minefield have been found and
        /// marked with a flag.
        /// </summary>
        /// <returns>A bool indicating whether all the mines are marked.</returns>
        public bool HasFoundAllMines()
        {
            Cell[] bombLocations = GetBombLocations();
            foreach (Cell cell in bombLocations)
            {
                if (cell.HasBomb && !cell.HasFlag)
                {
                    return false;
                }
            }
            return true;
        }

        public Cell[] GetBombLocations()
        {
            int index = 0;
            Cell[] bombLocations = new Cell[_totalBombs];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j].HasBomb)
                    {
                        bombLocations[index] = field[i, j];
                        index++;
                    }
                }
            }
            return bombLocations;
        }

        public List<Cell> ContinuousBlankCells (Cell center)
        {
            return ContinuousBlankCells(center, new List<Cell>());
        }

        public List<Cell> ContinuousBlankCells (Cell center, List<Cell> blankCells)
        {
            blankCells.Add(center);
            for (int i = center.Row - 1; i <= center.Row + 1; i++)
            {
                for (int j = center.Column - 1; j <= center.Column + 1; j++)
                {
                    if (i < 0
                        || i >= field.GetLength(0)
                        || j < 0
                        || j >= field.GetLength(1))
                    {
                        continue;
                    }
                    else if (field[i, j].Equals(center))
                    {
                        continue;
                    }
                    else if (field[i, j].SurroundingBombs == 0
                        && !blankCells.Contains(field[i, j]))
                    {
                        ContinuousBlankCells(field[i, j], blankCells);
                    }
                }
            }
            return blankCells;
        }

        public List<Cell> ContinousBlankCellsEdges (List<Cell> cells)
        {
            List<Cell> newCells = new List<Cell>(cells);
            foreach (Cell centerCell in cells)
            {
                for (int i = centerCell.Row - 1; i <= centerCell.Row + 1; i++)
                {
                    for (int j = centerCell.Column - 1; j <= centerCell.Column + 1; j++)
                    {
                        if (i < 0
                        || i >= field.GetLength(0)
                        || j < 0
                        || j >= field.GetLength(1))
                        {
                            continue;
                        }
                        else if (field[i, j].SurroundingBombs > 0 && !cells.Contains(field[i, j]))
                        {
                            newCells.Add(field[i, j]);
                        }
                    }
                }
            }
            return newCells;
        }
    }
}
