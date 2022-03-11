using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MinesweeperForm : Form
    {

        private Minefield minefield;
        private int revealCount;

        public MinesweeperForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This builds the minefield when the form loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinesweeperForm_Load(object sender, EventArgs e)
        {
            BuildMinefield(10, 10);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMinefield(10, 10);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles all click events for the CellLabels that make up
        /// the board on the form.
        /// </summary>
        /// <param name="sender">The CellLabel being clicked.</param>
        /// <param name="e">Cast to MouseEventArgs to determine mouse button clicked.</param>
        private void CellLabel_Click(object sender, EventArgs e)
        {
            CellLabel cellLabel = sender as CellLabel;
            MouseEventArgs me = e as MouseEventArgs;
            Cell cell = minefield.GetCell(cellLabel.Row, cellLabel.Column);
            if (cellLabel.Enabled)
            {
                if (me.Button == MouseButtons.Right && !cell.HasFlag)
                {
                    cellLabel.Image = Properties.Resources.Flag;
                    cell.HasFlag = true;
                    if (minefield.HasFoundAllMines())
                    {
                        GameWon();
                    }
                }
                else if (cell.HasFlag)
                {
                    cellLabel.Image = null;
                    cell.HasFlag = false;
                }
                else
                {
                    RevealBackColor(cellLabel);
                    if (cell.HasBomb)
                    {
                        cellLabel.Image = Properties.Resources.Bomb;
                        GameLost();
                    }
                    else if (cell.SurroundingBombs > 0)
                    {
                        cellLabel.Text = cell.SurroundingBombs.ToString();
                    }
                    else
                    {
                        RevealArea(cell);
                    }
                }
            }
        }

        private void revealTimer_Tick(object sender, EventArgs e)
        {
            CellLabel cellLabel = mineFieldPanel.Controls[revealCount] as CellLabel;
            cellLabel.Text = "";
            
            cellLabel.Enabled = false;
            if (!minefield.GetCell(cellLabel.Row, cellLabel.Column).HasFlag)
            {
                cellLabel.BackColor = ColorPalette.Water;
            }
            else
            {
                cellLabel.Image = Properties.Resources.FlowerOverlay;
            }

            if (revealCount < mineFieldPanel.Controls.Count - 1)
            {
                revealCount++;
            }
            else
            {
                revealTimer.Enabled = false;
            }
        }

        private void BuildMinefield(int rows, int columns)
        {
            mineFieldPanel.Controls.Clear();
            revealTimer.Enabled = false;
            const int CELL_SIZE = 25;
            int y = 0;
            for (int i = 0; i < rows; i++)
            {
                int x = 0;
                for (int j = 0; j < columns; j++)
                {
                    CellLabel cell = new CellLabel();
                    cell.Location = new Point(x, y);
                    cell.Height = CELL_SIZE;
                    cell.Width = CELL_SIZE;
                    cell.Text = "";
                    cell.Enabled = true;
                    cell.Font = new Font(cell.Font.FontFamily, 12);
                    if ((i + j) % 2 == 0)
                    {
                        cell.BackColor = ColorPalette.LightGreen;
                    }
                    else
                    {
                        cell.BackColor = ColorPalette.DarkGreen;
                    }
                    cell.TextAlign = ContentAlignment.MiddleCenter;
                    cell.Row = i;
                    cell.Column = j;
                    cell.Click += new EventHandler(CellLabel_Click);
                    mineFieldPanel.Controls.Add(cell);
                    x += CELL_SIZE;
                }
                y += CELL_SIZE;
            }
            int centerX = (this.ClientSize.Width - mineFieldPanel.Width) / 2;
            int centerY = (this.ClientSize.Height- mineFieldPanel.Height) / 2;
            mineFieldPanel.Location = new Point(centerX, centerY);
            minefield = new Minefield(rows, columns, 2);
        }

        private void RevealBackColor(CellLabel cellLabel)
        {
            if ((cellLabel.Row + cellLabel.Column) % 2 == 0)
            {
                cellLabel.BackColor = ColorPalette.LightTan;
            }
            else
            {
                cellLabel.BackColor = ColorPalette.DarkTan;
            }
            cellLabel.Enabled = false;
        }

        private void RevealArea(Cell startCell)
        {
            List<Cell> areaCells = new List<Cell>();
            areaCells = minefield.ContinuousBlankCells(startCell);
            areaCells.AddRange(minefield.ContinousBlankCellsEdges(areaCells));
            foreach (Cell cell in areaCells)
            {
                foreach (CellLabel cellLabel in mineFieldPanel.Controls)
                {
                    if (cellLabel.Row == cell.Row
                        && cellLabel.Column == cell.Column)
                    {
                        RevealBackColor(cellLabel);
                        if (cell.SurroundingBombs > 0)
                        {
                            cellLabel.Text = cell.SurroundingBombs.ToString();
                        }
                    }
                }
            }
        }

        private void GameLost()
        {
            Cell[] bombLocations = minefield.GetBombLocations();
            foreach (Cell cell in bombLocations)
            {
                foreach (CellLabel cellLabel in mineFieldPanel.Controls)
                {
                    if (cellLabel.Row == cell.Row && cellLabel.Column == cell.Column && !cell.HasFlag)
                    {
                        RevealBackColor(cellLabel);
                        cellLabel.Image = Properties.Resources.Bomb;
                    }
                    cellLabel.Enabled = false;
                }
            }
        }

        private void GameWon()
        {
            revealCount = 0;
            revealTimer.Enabled = true;
        }

    }
}
