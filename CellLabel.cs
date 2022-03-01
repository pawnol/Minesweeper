using System.Windows.Forms;

namespace Minesweeper
{
    /// <summary>
    /// Represents a GUI cell within the minefield.
    /// </summary>
    public partial class CellLabel : Label
    {
        /// <summary>
        /// Represents the row the cell belongs to within the minefield.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Represents the column the cell belongs to within the minefield.
        /// </summary>
        public int Column { get; set; }

        public CellLabel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
