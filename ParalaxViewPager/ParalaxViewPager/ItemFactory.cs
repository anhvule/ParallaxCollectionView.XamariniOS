using System;
using System.Collections.Generic;

namespace ParallaxViewPager
{
    public class ItemFactory
    {
        private static List<string> _campaignImages = new List<string>()
        {
            "campaign8.jpg",
            "campaign5.jpg",
            "campaign6.jpg",
            "campaign7.jpg"
        };

        public static List<Item> Create()
        {
            List<string> campaignImages = _campaignImages;

            var list = new List<Item>();
            for (int i = 0; i < campaignImages.Count; i++)
            {
                list.Add(new Item()
                    {
                        ImageUrl = campaignImages[i],
                    });
            }

            return list;
        }
    }
}

