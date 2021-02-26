using System;
using System.Collections.Generic;
using System.Linq;

namespace SubItem
{
    public class Item
    {
        public IEnumerable<SubItem> GetSubItems()
            => Enumerable.Empty<SubItem>();
    }
}
