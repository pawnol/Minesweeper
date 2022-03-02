using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    /// <summary>
    /// Stores the state of an individual cell within the bomb field.
    /// </summary>
    class Cell
    {
        /// <summary>
        /// Backing field that stores the cell's row rank.
        /// </summary>
        private int _row;
        /// <summary>
        /// Retieves the cell's row rank.
        /// </summary>
        public int Row 
        {
            get => _row;
        }

        /// <summary>
        /// Backing field that stores the cell's column rank.
        /// </summary>
        private int _column;
        /// <summary>
        /// Retieves the cell's column rank.
        /// </summary>
        public int Column
        {
            get => _column;
        }

        /// <summary>
        /// Backing field that stores whether the cell has a bomb.
        /// </summary>
        private bool _hasBomb;
        /// <summary>
        /// Retieves whether the cell has a bomb.
        /// </summary>
        public bool HasBomb
        {
            get => _hasBomb;
            set => _hasBomb = value;
        }

        /// <summary>
        /// Backing field that stores the number of bombs that surround the cell.
        /// </summary>
        private int _surroundingBombs;
        /// <summary>
        /// Retieves the number of bombs that surround the cell.
        /// </summary>
        public int SurroundingBombs
        {
            get => _surroundingBombs;
            set => _surroundingBombs = value;
        }

        /// <summary>
        /// Backing field that stores whether the cell currently has a flag.
        /// </summary>
        private bool _hasFlag;
        /// <summary>
        /// Retieves or sets whether the cell has a flag.
        /// </summary>
        public bool HasFlag
        {
            get => _hasFlag;
            set => _hasFlag = value;
        }

        /// <summary>
        /// Creates a cell object with a given row and column rank, and
        /// no bomb, flag, or surrouding bombs.
        /// </summary>
        /// <param name="row">Row rank of the cell.</param>
        /// <param name="column">Column rank of the cell.</param>
        public Cell(int row, int column)
        {
            _row = row;
            _column = column;
            _hasBomb = false;
            _hasFlag = false;
            _surroundingBombs = 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Cell other = obj as Cell;
            if (other == null)
            {
                return false;
            }
            return this._row == other._row && this._column == other._column;
        }
    }
}
