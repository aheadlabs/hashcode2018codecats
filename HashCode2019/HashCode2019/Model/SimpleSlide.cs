using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2019.Model
{
    public class SimpleSlide
    {
        public bool Processed { get; set; }
        public List<Photo> Photos { get; }

        public List<string> Tags { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="photos">List with 1 or 2 photos to build the SimpleSlide</param>
        public SimpleSlide(List<Photo> photos)
        {
            Processed = false;
            Photos = photos;
            Tags = new List<string>();

            foreach (var photo in photos)
            {
                foreach(var tag in photo.Tags)
                {
                    if(!Tags.Contains(tag)){
                        Tags.Add(tag);
                    }
                }
            }

        }
    }
}
