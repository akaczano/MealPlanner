using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MealPlanning
{
    class UserPreferences
    {

        public int ListLeftMargin { get; set; } = 5;
        public int ListVerticalPadding { get; set; } = 5;
        public Color ListSelectColor { get; set; } = Color.Blue;
        public Color ListHoverColor { get; set; } = Color.LightBlue;
        public Color ListDefaultColor { get; set; } = Color.Black;
    }
}
