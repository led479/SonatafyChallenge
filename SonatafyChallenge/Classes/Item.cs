using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonatafyChallenge
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TaxEnum TaxEnum { get; set; }
        public bool IsImport { get; set; }

        public decimal TaxValue
        {
            get
            {
                var taxValue = Value * TaxHelper.TaxPercentage(TaxEnum);
                taxValue = TaxHelper.RoundTax(taxValue);

                if (IsImport)
                {
                    taxValue += Value * 0.05m;
                    taxValue = TaxHelper.RoundTax(taxValue);
                }

                return taxValue;
            }
        }

        public decimal TotalValue => Value + TaxValue;
    }
}
