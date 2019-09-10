using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var itemIndex = 0; itemIndex < Items.Count; itemIndex++)
            {
                if (Items[itemIndex].Name == "Aged Brie")
                {
                    EditAgedBrieDetails(itemIndex);
                }
                else if (Items[itemIndex].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    EditBackStagePassesDetails(itemIndex);
                }
                else if (Items[itemIndex].Name.Contains("Conjured"))
                {
                    EditConjuredDetails(itemIndex);
                }
                else if (Items[itemIndex].Name != "Sulfuras, Hand of Ragnaros")
                {
                    EditOtherItemsThatAreNotSulfuras(itemIndex);
                }
            }
        }

        private void EditAgedBrieDetails(int itemIndex)
        {
            IncrementQualityIfNotGreaterThanMax(itemIndex);
            Items[itemIndex].SellIn--;
            if (Items[itemIndex].SellIn < 0)
            {
                IncrementQualityIfNotGreaterThanMax(itemIndex);
            }
        }

        private void EditBackStagePassesDetails(int itemIndex)
        {
            BackStagePassesQualityChange(itemIndex);
            Items[itemIndex].SellIn -= 1;
            if (Items[itemIndex].SellIn < 0 && Items[itemIndex].Quality > 0)
            {
                Items[itemIndex].Quality = 0;
            }
        }

        private void BackStagePassesQualityChange(int itemIndex)
        {
            IncrementQualityIfNotGreaterThanMax(itemIndex);
            if (Items[itemIndex].SellIn < 6)
            {
                IncrementQualityIfNotGreaterThanMax(itemIndex);
                IncrementQualityIfNotGreaterThanMax(itemIndex);
            }
            else if (Items[itemIndex].SellIn < 11)
            {
                IncrementQualityIfNotGreaterThanMax(itemIndex);
            }
        }

        private void EditConjuredDetails(int itemIndex)
        {
            if (Items[itemIndex].Quality > 1)
            {
                DecrementQualityIfNotLessThanMin(itemIndex);
                DecrementQualityIfNotLessThanMin(itemIndex);
            }
            Items[itemIndex].SellIn -= 1;
            if (Items[itemIndex].SellIn < 0)
            {
                DecrementQualityIfNotLessThanMin(itemIndex);
                DecrementQualityIfNotLessThanMin(itemIndex);
            }
        }

        private void EditOtherItemsThatAreNotSulfuras(int itemIndex)
        {
            DecrementQualityIfNotLessThanMin(itemIndex);

            Items[itemIndex].SellIn -= 1;
            if (Items[itemIndex].SellIn < 0)
            {
                DecrementQualityIfNotLessThanMin(itemIndex);
            }
        }

        private void IncrementQualityIfNotGreaterThanMax(int itemIndex)
        {
            if (Items[itemIndex].Quality < 50)
            {
                Items[itemIndex].Quality += 1;
            }
        }

        private void DecrementQualityIfNotLessThanMin(int itemIndex)
        {
            if (Items[itemIndex].Quality > 0)
            {
                Items[itemIndex].Quality -= 1;
            }
        }

    }
}
