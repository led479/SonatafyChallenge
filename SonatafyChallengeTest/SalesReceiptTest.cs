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

        #region Expected output from challenge
        [Fact]
        public void ExpectedOutput1()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Book",
                    TaxEnum = TaxEnum.EXEMPT,
                    IsImport = false,
                    Value = 12.49m
                },
                new Item
                {
                    Name = "Book",
                    TaxEnum = TaxEnum.EXEMPT,
                    IsImport = false,
                    Value = 12.49m
                },
                new Item
                {
                    Name = "Music CD",
                    TaxEnum = TaxEnum.NORMAL,
                    IsImport = false,
                    Value = 14.99m
                },
                new Item
                {
                    Name = "Chocolate bar",
                    TaxEnum = TaxEnum.EXEMPT,
                    IsImport = false,
                    Value = 0.85m
                },
            };
            var salesReceipt = new SalesReceipt { Items = items };
            var stringRepresentation = salesReceipt.GetStringRepresentation();

            Assert.Equal("Book: 24.98 (2 @ 12.49)\n" +
                            "Music CD: 16.49\n" +
                            "Chocolate bar: 0.85\n" +
                            "Sales Taxes: 1.50\n" +
                            "Total: 42.32", stringRepresentation);
        }

        [Fact]
        public void ExpectedOutput2()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Imported box of chocolates",
                    TaxEnum = TaxEnum.EXEMPT,
                    IsImport = true,
                    Value = 10.00m
                },
                new Item
                {
                    Name = "Imported bottle of perfume",
                    TaxEnum = TaxEnum.NORMAL,
                    IsImport = true,
                    Value = 47.50m
                },
            };
            var salesReceipt = new SalesReceipt { Items = items };
            var stringRepresentation = salesReceipt.GetStringRepresentation();

            Assert.Equal("Imported box of chocolates: 10.50\n" +
                            "Imported bottle of perfume: 54.65\n" +
                            "Sales Taxes: 7.65\n" +
                            "Total: 65.15", stringRepresentation);
        }

        [Fact]
        public void ExpectedOutput3()
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
            var salesReceipt = new SalesReceipt { Items = items };
            var stringRepresentation = salesReceipt.GetStringRepresentation();

            Assert.Equal("Imported bottle of perfume: 32.19\n" +
                            "Bottle of perfume: 20.89\n" +
                            "Packet of headache pills: 9.75\n" +
                            "Imported box of chocolates: 23.70 (2 @ 11.85)\n" +
                            "Sales Taxes: 7.30\n" +
                            "Total: 86.53", stringRepresentation);
        }
        #endregion
    }
}
