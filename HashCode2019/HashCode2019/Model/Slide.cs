using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HashCode2019
{
    public class Slide
    {
        public List<Photo> Photos;

        public List<string> Tags
        {
            get
            {
                return new List<string>(); //Photos.SelectMany(p => p.Tags).GroupBy((s, k) => s);
            }
        }

        public Slide(List<Photo> photos)
        {
            Photos = photos;
        }

    }
}
