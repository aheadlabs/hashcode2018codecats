using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HashCode2020
{
    public class Slide
    {
        #region Public Fields

        public List<Photo> Photos;

        #endregion Public Fields

        #region Public Properties

        public List<string> Tags
        {
            get
            {
                return Photos.SelectMany(p => p.Tags).GroupBy(s => s).Select(s => s.Key).ToList();
            }
        }

        #endregion Public Properties

        #region Public Methods

        public static List<Slide> CreateSlides(List<Photo> photos)
        {
            var slids = new List<Slide>();
            var temp = new List<Photo>();

            foreach (var photo in photos)
            {
                if (photo.Orientation == "H")
                    slids.Add(new Slide(new Photo[] { photo }));
                else
                {
                    //TODO: como determinar si añadimos una o dos fotos??
                    temp.Add(photo);

                    if (temp.Count == 2)
                    {
                        slids.Add(new Slide(temp.ToArray()));
                        temp.Clear();
                    }
                }
            }

            return slids;
        }

        #endregion Public Methods

        #region Private Constructors

        private Slide(Photo[] photos)
        {
            Photos = photos.ToList();
        }

        #endregion Private Constructors
    }
}