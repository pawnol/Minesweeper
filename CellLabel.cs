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

        /// <summary>
        /// Represents whether the control is enabled. This hides the property
        /// Enabled inherited from Label to allow the ability to change the 
        /// appearance of the control.
        /// </summary>
        new public bool Enabled { get; set; }

        /// <summary>
        /// Creates a CellLabel object.
        /// </summary>
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
