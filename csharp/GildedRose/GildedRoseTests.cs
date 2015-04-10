using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    using System.Collections.Generic;
    using Console;

    [TestClass]
    public class GildedRoseTests
    {
        private IList<Item> items;

        [TestInitialize]
        public void Initialize()
        {
            items = new List<Item>();
        }

        [TestMethod]
        public void WhenUpdateQualityOnRegularItem_ItShouldDecreaseSellIn()
        {
            // Arrange
            Item regular = new Item{Name = "regular", Quality = 5, SellIn = 10};
            items.Add(regular);

            const int expectedSellIn = 9;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedSellIn, regular.SellIn);
        }

        [TestMethod]
        public void WhenUpdateQualityOnRegularItem_ItShouldDecreaseQuality()
        {
            // Arrange
            Item regular = new Item { Name = "regular", Quality = 10, SellIn = 5 };
            items.Add(regular);

            const int expectedQuality = 9;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedQuality, regular.Quality);
        }

        [TestMethod]
        public void WhenUpdateQualityOnRegularItemAfterSellIn_ItShouldDecreaseQualityTwiceFast()
        {
            // Arrange
            Item regular = new Item { Name = "regular", Quality = 10, SellIn = 0 };
            items.Add(regular);

            const int expectedQuality = 8;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedQuality, regular.Quality);
        }

        [TestMethod]
        public void WhenUpdateQualityOnItemWithQualityZero_ItShouldNotDecreaseQuality()
        {
            // Arrange
            Item regular = new Item { Name = "regular", Quality = 0, SellIn = 10 };
            items.Add(regular);

            const int expectedQuality = 0;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedQuality, regular.Quality);
        }

        [TestMethod]
        public void WhenUpdateQualityOnItemWithQualityZeroAndAfterSellIn_ItShouldNotDecreaseQuality()
        {
            // Arrange
            Item regular = new Item { Name = "regular", Quality = 0, SellIn = 0 };
            items.Add(regular);

            const int expectedQuality = 0;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedQuality, regular.Quality);
        }

        [TestMethod]
        public void WhenUpdateQualityOnAgedBrie_ItShouldIncreaseQuality()
        {
            // Arrange
            Item agedBrie = new Item { Name = "Aged Brie", Quality = 5, SellIn = 10 };
            items.Add(agedBrie);

            const int expectedQuality = 6;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedQuality, agedBrie.Quality);
        }

        [TestMethod]
        public void WhenUpdateQualityOnAgedBrieAfterSellIn_ItShouldIncreaseQualityTwiceFast()
        {
            // Arrange
            Item agedBrie = new Item { Name = "Aged Brie", Quality = 5, SellIn = 0 };
            items.Add(agedBrie);

            const int expectedQuality = 7;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedQuality, agedBrie.Quality);
        }

        [TestMethod]
        public void WhenUpdateQualityOnItem_ItShouldNotIncreaseQualityOverFifty()
        {
            // Arrange
            Item agedBrie = new Item { Name = "Aged Brie", Quality = 50, SellIn = 10 };
            items.Add(agedBrie);

            const int expectedQuality = 50;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedQuality, agedBrie.Quality);
        }

        [TestMethod]
        public void WhenUpdateQualityOnSulfuras_ItShouldNotVaryQuality()
        {
            // Arrange
            Item sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 15, SellIn = 10 };
            items.Add(sulfuras);

            const int expectedQuality = 15;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedQuality, sulfuras.Quality);
        }

        [TestMethod]
        public void WhenUpdateQualityOnSulfuras_ItShouldNotVarySellIn()
        {
            // Arrange
            Item sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 15, SellIn = 8 };
            items.Add(sulfuras);

            const int expectedSellIn = 8;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedSellIn, sulfuras.SellIn);
        }

        [TestMethod]
        public void WhenUpdateQualityOnBackstageWithSellInMoreThanTen_ItShouldIncreaseQuality()
        {
            // Arrange
            Item backstage = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 15, SellIn = 11 };
            items.Add(backstage);

            const int expectedQuality = 16;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedQuality, backstage.Quality);
        }

        [TestMethod]
        public void WhenUpdateQualityOnBackstageWithSellInBetweenTenAndFive_ItShouldIncreaseQualityTwiceFast()
        {
            // Arrange
            Item backstage = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 15, SellIn = 6 };
            items.Add(backstage);

            const int expectedQuality = 17;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedQuality, backstage.Quality);
        }

        [TestMethod]
        public void WhenUpdateQualityOnBackstageWithSellInBetweenTenAndFive_ItShouldIncreaseQualityThriceFast()
        {
            // Arrange
            Item backstage = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 15, SellIn = 1 };
            items.Add(backstage);

            const int expectedQuality = 18;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedQuality, backstage.Quality);
        }

        [TestMethod]
        public void WhenUpdateQualityOnBackstageAfterSellIn_ItShouldDropQualityToZero()
        {
            // Arrange
            Item backstage = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 99999, SellIn = 0 };
            items.Add(backstage);

            const int expectedQuality = 0;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedQuality, backstage.Quality);
        }

        [TestMethod]
        [Ignore]
        public void WhenUpdateQualityOnConjuredItem_ItShouldDecreaseQualityTwiceFast()
        {
            // Arrange
            Item regular = new Item { Name = "Conjured Mana Cake", Quality = 10, SellIn = 5 };
            items.Add(regular);

            const int expectedQuality = 8;

            // Act
            GildedRose.UpdateQuality(items);

            // Assert
            Assert.AreEqual(expectedQuality, regular.Quality);
        }
    }
}