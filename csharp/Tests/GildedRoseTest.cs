using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [TestCase(0)]
        [TestCase(-1)]
        public void TestAgedBrie_OutOfDate_QualityIncreaseByTwo(int sellInDate)
        {
            var initialQuality = 10;
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellInDate, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(initialQuality+2, Items[0].Quality);
        }

        [TestCase(10)]
        [TestCase(1)]
        public void TestAgedBrie_BeforeSellIn_QualityIncrement(int sellInDate)
        {
            var initialQuality = 10;
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellInDate, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(initialQuality + 1, Items[0].Quality);
        }

        [TestCase(11)]
        [TestCase(12)]
        public void TestBackStagePasses_MoreThanTenDaysBeforeSellIn_QualityIncrement(int sellInDate)
        {
            var initialQuality = 10;
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellInDate, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(initialQuality + 1, Items[0].Quality);
        }

        [TestCase(10)]
        [TestCase(6)]
        public void TestBackStagePasses_TenToFiveDaysBeforeSellIn_QualityIncreaseByTwo(int sellInDate)
        {
            var initialQuality = 10;
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellInDate, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(initialQuality + 2, Items[0].Quality);
        }

        [TestCase(5)]
        [TestCase(1)]
        public void TestBackStagePasses_FiveToZeroDaysBeforeSellIn_QualityIncreaseByThree(int sellInDate)
        {
            var initialQuality = 10;
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellInDate, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(initialQuality + 3, Items[0].Quality);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestBackStagePasses_OutOfDate_QualityZero(int sellInDate)
        {
            var initialQuality = 10;
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellInDate, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestSulfuras_OutOfDate_NoChangeInQuality(int sellInDate)
        {
            var initialQuality = 80;
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellInDate, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(initialQuality, Items[0].Quality);
        }

        [TestCase(2)]
        [TestCase(1)]
        public void TestSulfuras_BeforeSellIn_NoChangeInQuality(int sellInDate)
        {
            var initialQuality = 80;
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellInDate, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(initialQuality, Items[0].Quality);
        }

        [TestCase(2)]
        [TestCase(1)]
        public void TestOtherItems_BeforeSellIn_QualityDecrements(int sellInDate)
        {
            var initialQuality = 10;
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = sellInDate, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(initialQuality - 1, Items[0].Quality);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestOtherItems_OutOfDate_QualityDecreasesByTwo(int sellInDate)
        {
            var initialQuality = 10;
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = sellInDate, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(initialQuality - 2, Items[0].Quality);
        }

        [TestCase(2)]
        [TestCase(1)]
        public void TestConjuredItems_BeforeSellIn_QualityDecreasesByTwo(int sellInDate)
        {
            var initialQuality = 10;
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured ksaj", SellIn = sellInDate, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(initialQuality - 2, Items[0].Quality);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestConjuredItems_OutOfDate_QualityDecreasesByFour(int sellInDate)
        {
            var initialQuality = 10;
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured ksaj", SellIn = sellInDate, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(initialQuality - 4, Items[0].Quality);
        }


        [TestCase(0, 0)]
        [TestCase(-1, 1)]
        [TestCase(0, 1)]
        [TestCase(-1, 0)]
        public void TestWhenItemNearZeroIsNeverLessThanZero(int sellInDate, int initialQuality)
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Conjured", SellIn = sellInDate, Quality = initialQuality },
                new Item { Name = "sdjhsdfkj", SellIn = sellInDate, Quality = initialQuality }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
            Assert.AreEqual(0, Items[1].Quality);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestAgedBrie_OutOfDate_NotMoreThanFifty(int sellInDate)
        {
            var initialQuality = 50;
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = sellInDate, Quality = initialQuality }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(initialQuality, Items[0].Quality);
        }

        [TestCase(5)]
        [TestCase(1)]
        public void TestBackStagePasses_LessThanFiveDaysBefore_NotMoreThanFifty(int sellInDate)
        {
            var initialQuality = 50;
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellInDate, Quality = initialQuality }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(initialQuality, Items[0].Quality);
        }
    }
}
