using System.Drawing;

namespace Minesweeper
{
    /// <summary>
    /// Stores the RGP values for all the colors needed for the application.
    /// </summary>
    readonly struct ColorPalette
    {
        /// <summary>
        /// Gets a color represented by an RGB value of 174, 219, 10.
        /// </summary>
        public static Color LightGreen
        {
            get
            {
                return Color.FromArgb(174, 219, 10);
            }
        }

        /// <summary>
        /// Gets a color represented by an RGB value of 155, 195, 9.
        /// </summary>
        public static Color DarkGreen
        {
            get
            {
                return Color.FromArgb(155, 195, 9);
            }
        }

        /// <summary>
        /// Gets a color represented by an RGB value of 210, 180, 140.
        /// </summary>
        public static Color LightTan
        {
            get
            {
                return Color.FromArgb(210, 180, 140);
            }
        }

        /// <summary>
        /// Gets a color represented by an RGB value of 198, 159, 108.
        /// </summary>
        public static Color DarkTan
        {
            get
            {
                return Color.FromArgb(198, 159, 108);
            }
        }

        public static Color Water
        {
            get
            {
                return Color.FromArgb(51, 204, 255);
            }
        }
    }
}
