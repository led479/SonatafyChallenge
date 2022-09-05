using SonatafyChallenge;
using System;
using System.Collections.Generic;
using Xunit;

namespace SonatafyChallengeTest
{
    public class SalesReceiptTest
    {
        private SalesReceipt MockSalesReceipt()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Imported bottle of perfume",
                    TaxEnum = TaxEnum.NORMAL,
                    IsImport = true,
                    Value = 27.99m
                },
                new Item
                {
                    Name = "Bottle of perfume",
                    TaxEnum = TaxEnum.NORMAL,
                    IsImport = false,
                    Value = 18.99m
                },
                new Item
                {
                    Name = "Packet of headache pills",
                    TaxEnum = TaxEnum.EXEMPT,
                    IsImport = false,
                    Value = 9.75m
                },
                new Item
                {
                    Name = "Imported box of chocolates",
                    IsImport = true,
                    TaxEnum = TaxEnum.EXEMPT,
                    Value = 11.25m
                },
                new Item
                {
                    Name = "Imported box of chocolates",
                    IsImport = true,
                    TaxEnum = TaxEnum.EXEMPT,
                    Value = 11.25m
                },

            };

            return new SalesReceipt
            {
                Items = items
            };
        }

        [Fact]
        public void SalesTaxesShouldReturnSumOfItemsTaxes()
        {
            var salesReceipt = MockSalesReceipt();

            Assert.Equal(7.30m, salesReceipt.SalesTaxes);
        }

        [Fact]
        public void TotalShouldReturnSumOfItemsTotalValues()
        {
            var salesReceipt = MockSalesReceipt();

            Assert.Equal(86.53m, salesReceipt.Total);
        }


        [Fact]
        public void GetStringRepresentationShouldContainSalesTaxes()
        {
            var salesReceipt = MockSalesReceipt();
            var stringRepresentation = salesReceipt.GetStringRepresentation();

            Assert.Contains("Sales Taxes: 7.30", stringRepresentation);
        }


        [Fact]
        public void GetStringRepresentationShouldContainTotal()
        {
            var salesReceipt = MockSalesReceipt();
            var stringRepresentation = salesReceipt.GetStringRepresentation();

            Assert.Contains("Total: 86.53", stringRepresentation);
        }

        [Fact]
        public void GetStringRepresentationShouldGroupItemsWithSameName()
        {
            var salesReceipt = MockSalesReceipt();
            var stringRepresentation = salesReceipt.GetStringRepresentation();

            Assert.Contains("Imported box of chocolates: 23.70 (2 @ 11.85)", stringRepresentation);
            Assert.DoesNotContain("Imported box of chocolates: 11.85", stringRepresentation);
        }
    }
}
