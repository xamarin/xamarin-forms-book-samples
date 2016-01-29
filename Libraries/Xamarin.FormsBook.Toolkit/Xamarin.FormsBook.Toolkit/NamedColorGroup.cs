using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class NamedColorGroup : List<NamedColor>
    {
        // Instance members.
        private NamedColorGroup(string title, string shortName, Color colorShade)
        {
            this.Title = title;
            this.ShortName = shortName;
            this.ColorShade = colorShade;
        }

        public string Title { private set; get; }

        public string ShortName { private set; get; }

        public Color ColorShade { private set; get; }

        // Static members.
        static NamedColorGroup()
        {
            // Create all the groups
            List<NamedColorGroup> groups = new List<NamedColorGroup>
            {
                new NamedColorGroup("Grays", "Gry", new Color(0.75, 0.75, 0.75)),
                new NamedColorGroup("Reds", "Red", new Color(1, 0.75, 0.75)),
                new NamedColorGroup("Yellows", "Yel", new Color(1, 1, 0.75)),
                new NamedColorGroup("Greens", "Grn", new Color(0.75, 1, 0.75)),
                new NamedColorGroup("Cyans", "Cyn", new Color(0.75, 1, 1)),
                new NamedColorGroup("Blues", "Blu", new Color(0.75, 0.75, 1)),
                new NamedColorGroup("Magentas", "Mag", new Color(1, 0.75, 1))
            };

            foreach (NamedColor namedColor in NamedColor.All)
            {
                Color color = namedColor.Color;
                int index = 0;

                if (color.Saturation != 0)
                {
                    index = 1 + (int)((12 * color.Hue + 1) / 2) % 6;
                }
                groups[index].Add(namedColor);
            }

            foreach (NamedColorGroup group in groups)
            {
                group.TrimExcess();
            }

            All = groups;
        }

        public static IList<NamedColorGroup> All { private set; get; }
    }
}
