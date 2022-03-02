/*
 * Minesweeper Form
 * Pawelski
 * 3/1/2022
 */

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

        /// <summary>
        /// Handles all click events for the CellLabels that make up
        /// the board on the form.
        /// </summary>
        /// <param name="sender">The CellLabel being clicked.</param>
        /// <param name="e">Cast to MouseEventArgs to determine mouse button clicked.</param>
        private void CellLabel_Click(object sender, EventArgs e)
        {
            CellLabel cellLabel = (CellLabel)sender;
            MouseEventArgs me = (MouseEventArgs)e;
            Cell cell = minefield.GetCell(cellLabel.Row, cellLabel.Column);
            UpdateCellLabel(cellLabel, me, cell);
        }

        private void BuildMinefield(int rows, int columns)
        {
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

            minefield = new Minefield(rows, columns, 10);
        }

        private void UpdateCellLabel(CellLabel cellLabel, MouseEventArgs me, Cell cell)
        {
            if (cellLabel.Enabled)
            {
                if (me.Button == MouseButtons.Right && !cell.HasFlag)
                {
                    cellLabel.Image = Properties.Resources.Flag;
                    cell.HasFlag = true;
                }
                else if (cell.HasFlag)
                {
                    cellLabel.Image = null;
                    cell.HasFlag = false;
                }
                else
                {
                    if ((cellLabel.Row + cellLabel.Column) % 2 == 0)
                    {
                        cellLabel.BackColor = ColorPalette.LightTan;
                    }
                    else
                    {
                        cellLabel.BackColor = ColorPalette.DarkTan;
                    }

                    if (cell.HasBomb)
                    {
                        cellLabel.Image = Properties.Resources.Bomb;
                    }
                    else
                    {
                        cellLabel.Text = cell.SurroundingBombs.ToString();
                    }
                    cellLabel.Enabled = false;
                }
            }
        }
    }
}
