using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonatafyChallenge
{
    public class SalesReceipt
    {
        public List<Item> Items { get; set; }

        public decimal SalesTaxes => Items.Sum(x => x.TaxValue);
        public decimal Total => Items.Sum(x => x.TotalValue);

        public string GetStringRepresentation()
        {
            if (Items.Count == 0)
            {
                return "This sales receipt doesn't have any items.";
            }

            var salesReceiptString = "";
            foreach (var itemsGrouped in Items.GroupBy(x => x.Name))
            {
                salesReceiptString += $"{itemsGrouped.Key}: {itemsGrouped.Sum(x => x.TotalValue):0.00}";

                var itemsGroupedCount = itemsGrouped.Count();
                if (itemsGroupedCount > 1)
                {
                    salesReceiptString += $" ({itemsGroupedCount} @ {itemsGrouped.First().TotalValue:0.00})";
                }

                salesReceiptString += "\n";
            }

            salesReceiptString += $"Sales Taxes: {SalesTaxes:0.00}\n";
            salesReceiptString += $"Total: {Total:0.00}";

            return salesReceiptString;
        }
    }
}
