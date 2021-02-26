using System;
using System.Collections.Generic;
using System.Linq;

namespace SubItem
{
    public class GetSubItem
    {
        /// <summary>
        /// Gets a sub-item summary for a given item number.
        /// </summary>
        /// <param name="itemNumber">The item number of the item to get the sub-item summary of.</param>
        public SubItemSummary[] GetSubItemSummaryOld(string itemNumber)
            =>  GetSubItems(itemNumber).SelectMany(item => TransformSubItems(item, item.GetSubItems())).ToArray();

        // public SubItemSummary[] GetSubItemSummary(string itemNumber)
        // {
        //     IEnumerable<Item> subItems = GetSubItems(itemNumber);

        //     List<SubItemSummary> subItemSummary = new List<SubItemSummary>();

        //     foreach (Item item in subItems)
        //     {
        //         IEnumerable<SubItemSummary> tempSummaries = TransformSubItems(item, item.GetSubItems());

        //         subItemSummary.AddRange(tempSummaries);
        //     }

        //     return subItemSummary.ToArray();
        // }

        public IEnumerable<Item> GetSubItems(string itemNumber)
            => Enumerable.Empty<Item>();

        public IEnumerable<SubItemSummary> TransformSubItems(Item item, IEnumerable<SubItem> subItems)
            => Enumerable.Empty<SubItemSummary>();
    }
}
