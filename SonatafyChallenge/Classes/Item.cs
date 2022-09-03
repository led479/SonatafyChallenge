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

        public decimal TaxValue
        {
            get
            {
                if (TaxEnum == TaxEnum.EXEMPT)
                    return 0;

                var taxValue = Value * TaxHelper.TaxPercentage(TaxEnum);

                /* Round the value up to the nearest 5 cents */
                return Math.Ceiling(taxValue * 20) / 20;
            }
        }

        public decimal TotalValue => Value + TaxValue;
    }
}
