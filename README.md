# SonatafyChallenge

## Brief explanation of my design and assumptions

### Regarding the Item calculations:

I've decided to use the C# properties with just getters for item TaxValue and item TotalValue, because it looks cleaner, and fully incapsulates the logic in an easy way to read, and to update in the future.

### Regarding the SalesReceipt calculations:

I've decided to use the C# properties here as well to get the sales receipt SalesTaxes and Total, which just sums the Items TaxValue and TotalValue properties, respectively.
And I've created a method called 'GetStringRepresentation()', that returns a string in the format of the desired output of the challenge.

### Regarding the taxes:

The part that I struggled the most was fully understanding the Taxes (normal, exempt and imported), and how to implement it in code.

I've decided to separate the Import tax with the rest of the taxes, because it is an additional tax on top of the normal taxes.

So I've created the flag IsImported to represent imported items.
And I've created the enum TaxEnum, to represent the other taxes (NORMAL, EXEMPT).
I did go with an enum because new taxes types could be added in the future, and it would be easier to extend in comparison to it being just a flag like HasNormalTax or IsExempt.

### Regarding the unit tests:

I've decided mainly to test the calculations of items and sales receipts.
I've also included some mock data on the top of the test files.

### Item tests:

I've tested here:

- TotalValue
- Taxes regarding normal, exempt, imported normal and imported exempt
- Rounding of taxes

### Sales Receipt tests:

I've tested here:

- SalesTaxes
- Total
- GetStringRepresentation, checking if it contains the sales taxes, the total and if it groups multiple items on the same row.

And I've also included the expected inputs and outputs from the challenge at the end of the SalesReceiptTest.cs file.

# Files:

## Classes:

### Item

- Name : string
  -- Name of the item

- Value : decimal
  -- Shelf price of the item

- TaxEnum : TaxEnum
  -- Represents in which tax category the item is. Can be NORMAL or EXEMPT

- IsImported : bool
  -- Represents if the item is or isn't imported

- TaxValue : decimal
  -- Tax value of the item, which gets calculated based on the TaxEnum AND IsImported.

- TotalValue : decimal
  -- Sum of the Value and TaxValue

### SalesReceipt

- Items : List<Item>
  -- List of the items of the SalesReceipt

- SalesTaxes : decimal
  -- Sum of the TaxValue property of the items

- Total : decimal
  -- Sum of the TotalValue property of the items

- GetStringRepresentation() : string
  -- Returns a string representation of the Sales Receipt, in the same pattern as the expected outputs of the challenge.

  Example:

  ```
  Book: 24.98 (2 @ 12.49)
  Music CD: 16.49
  Chocolate bar: 0.85
  Sales Taxes: 1.50
  Total: 42.32
  ```

## Enums:

### TaxEnum

- Can have the values NORMAL, EXEMPT

## Helpers:

### TaxHelper

- TaxPercentage(TaxEnum taxEnum) : decimal
  -- Returns the percentage of tax passed as a parameter. Could be extended if new TaxEnums shows up.

- RoundTax(decimal value) : decimal
  -- Round the value up to the nearest 5 cents

### ConsoleInputHelper:

- exemptItemNames : List of strings
  -- List of names that should be classified as Tax Exempt.

- TryCreateItemFromConsoleInput(string input, out List<Item> items) : bool
  -- Reads the line from user input, and then creates the desired items. Handle empty strings, strings without the separator ' at ', without quantity and without values.

## Main Program:

- Basic console application, that allows the user to fill his shopping basket, and then print the sales receipt when he finishes.
