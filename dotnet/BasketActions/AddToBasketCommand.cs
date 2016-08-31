namespace BasketActions {

using System;
using Products;
using Ui;
using Warehouse;
using Basket;

class AddToBasketCommand : UserCommand {

	private Basket basket;
	private Warehouse warehouse;
	private Catalogue catalogue;

	internal AddToBasketCommand(Basket basket, Catalogue catalogue, Warehouse warehouse) {
		this.basket = basket;
		this.catalogue = catalogue;
		this.warehouse = warehouse;
	}

	public void run(UserInput cmd) {
		if (cmd.args.Length > 3) {
			Console.WriteLine("ERROR: Usage: a sku [numitems]");
			return;
		}
		string sku = cmd.Args(1);
		int numItems = 1;
		if (cmd.args.Length == 3) {
			try {
				numItems = int.Parse(cmd.Args(2));
			} catch (FormatException) {
				throw new UsageException("The number of items must be a number greater than zero.");
			}
		}
		if (numItems <= 0)
			throw new UsageException("The number of items must be a number greater than zero.");
		string[] skuCode = catalogue.lookupCode(sku);
		if (skuCode == null)
			throw new UsageException("Product " + sku + " unknown.");
		warehouse.mustStock(skuCode, numItems);
		basket.add(sku, catalogue, numItems);
	}

}
}