using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    /// <summary>
    /// Represents a GUI cell within the minefield.
    /// </summary>
    public partial class CellLabel : Label
    {
        /// <summary>
        /// Internal field to store whether the cell has a flag in it.
        /// </summary>
        private bool hasFlag;

        private readonly Image flagImage = Properties.Resources.Flag;

        /// <summary>
        /// Represents the row the cell belongs to within the minefield.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Represents the column the cell belongs to within the minefield.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Represents whether the cell has a flag in it.
        /// </summary>
        public bool HasFlag
        {
            get
            {
                return hasFlag;
            }
            set
            {
                hasFlag = value;
                if(hasFlag)
                {
                    this.Image = flagImage;
                }
                else
                {
                    this.Image = null;
                }
            }
        }

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
