using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonatafyChallenge
{
    public class Receipt
    {
        public List<Item> Items { get; set; }

        public decimal SalesTaxes => Items.Sum(x => x.TaxValue);
        public decimal Total => Items.Sum(x => x.TotalValue);
    }
}
