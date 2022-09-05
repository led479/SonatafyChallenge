using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonatafyChallenge
{
    public static class ConsoleInputHelper
    {
        private static readonly List<string> exemptItemNames = new List<string>
        {
            "book", "chocolate", "pill"
        };

        public static bool TryCreateItemFromConsoleInput(string input, out List<Item> items)
        {
            items = new List<Item>();

            if (string.IsNullOrEmpty(input) || !input.Contains(" at ") || !input.Contains(" "))
                return false;

            int quantity;
            if (!int.TryParse(input.Split(" ")[0], out quantity))
                return false;

            var quantityString = input.Split(" ")[0];
            var nameWithQuantity = input.Split(" at ")[0].Trim();
            var name = nameWithQuantity.Replace(quantityString, "").Trim();

            var taxEnum = exemptItemNames.Any(x => name.ToLower().Contains(x)) ? TaxEnum.EXEMPT : TaxEnum.NORMAL;

            var isImport = name.StartsWith("Imported");
            decimal value;
            if (!decimal.TryParse(input.Split(" at ")[1], out value))
                return false;

            for (int i = 0; i < quantity; i++)
            {
                var item = new Item
                {
                    Name = name,
                    IsImported = isImport,
                    TaxEnum = taxEnum,
                    Value = value
                };

                items.Add(item);
            }
            
            return true;
        }

    }
}
