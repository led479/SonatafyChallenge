using SonatafyChallenge;
using System;
using Xunit;

namespace SonatafyChallengeTest
{
    public class ItemTest
    {
        private Item MockItemWithNormalTax()
        {
            return new Item
            {
                Name = "Music CD",
                TaxEnum = TaxEnum.NORMAL,
                IsImported = false
            };
        }

        private Item MockItemWithExemptTax()
        {
            return new Item
            {
                Name = "Book",
                TaxEnum = TaxEnum.EXEMPT,
                IsImported = false
            };
        }

        private Item MockImportItemWithNormalTax()
        {
            return new Item
            {
                Name = "Imported bottle of perfume",
                TaxEnum = TaxEnum.NORMAL,
                IsImported = true
            };
        }

        private Item MockImportItemWithExemptTax()
        {
            return new Item
            {
                Name = "Imported box of chocolates",
                TaxEnum = TaxEnum.EXEMPT,
                IsImported = true
            };
        }

        [Fact]
        public void TotalValueShouldReturnTaxValuePlusValue()
        {
            var item = MockItemWithNormalTax();
            item.Value = 14.99m;

            Assert.Equal(14.99m, item.Value);
            Assert.Equal(1.5m, item.TaxValue);
            Assert.Equal(14.99m + 1.5m, item.TotalValue);
        }

        [Fact]
        public void ItemsWithExemptTaxShouldHaveTaxValueAsZero()
        {
            var item = MockItemWithExemptTax();
            item.Value = 12.49m;

            Assert.Equal(0.00m, item.TaxValue);
        }

        [Fact]
        public void ItemsWithNormalTaxShouldHaveTaxValueAsTenPercent()
        {
            var item = MockItemWithNormalTax();
            item.Value = 14.99m;

            Assert.Equal(1.50m, item.TaxValue);
        }

        [Fact]
        public void ImportItemsWithNormalTaxShouldHaveTaxValueAsTenPercentPlusFivePercent()
        {
            var item = MockImportItemWithNormalTax();
            item.Value = 27.99m;

            Assert.Equal(4.20m, item.TaxValue);
        }


        [Fact]
        public void ImportItemsWithExemptTaxShouldHaveTaxValueAsZeroPlusFivePercent()
        {
            var item = MockImportItemWithExemptTax();
            item.Value = 11.25m;

            Assert.Equal(0.60m, item.TaxValue);
        }

        [Fact]
        public void TaxValueShouldBeRoundedUpToTheNearestFiveCents()
        {
            /* NORMAL Tax Items */
            var itemNormalTax = MockItemWithNormalTax();
            itemNormalTax.Value = 14.99m;

            Assert.Equal(1.50m, itemNormalTax.TaxValue);

            /* IMPORTED NORMAL Tax Items */
            var importedItemNormalTax = MockImportItemWithNormalTax();
            importedItemNormalTax.Value = 27.99m;

            Assert.Equal(4.20m, importedItemNormalTax.TaxValue);

            /* IMPORTED EXEMPT Tax Items */
            var importedItemExemptTax = MockImportItemWithExemptTax();
            importedItemExemptTax.Value = 11.25m;

            Assert.Equal(0.60m, importedItemExemptTax.TaxValue);
        }
    }
}
