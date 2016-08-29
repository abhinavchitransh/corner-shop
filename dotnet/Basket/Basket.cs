namespace Basket {

using Products;
using Warehouse;
using System.Collections.Generic;

public class Basket {

	private IDictionary<string, BasketItem> items;
	
	public Basket() {
		items = new Dictionary<string, BasketItem>();
	}

	public IList<BasketItem> list() {
		IList<BasketItem> result = new List<BasketItem>();
		foreach (string sku in sortedSkus())
			result.Add(items[sku]);
		return result;
	}

	private IList<string> sortedSkus() {
		IList<string> skus = new List<string>(items.keySet());
		java.util.Collections.sort(skus);
		return skus;
	}

	public void add(string skuId, Catalogue catalogue, int numItems) {
		Sku sku = catalogue.lookup(skuId);
		if (items.ContainsKey(skuId)) {
			BasketItem existing = items[skuId];
			items.Add(skuId, new BasketItem(skuId, existing.title, existing.price, existing.count + numItems));
		} else {
			items.Add(skuId, new BasketItem(skuId, sku.title, sku.price, numItems));
		}
	}

	public void checkout(Warehouse warehouse) {
		if (items.Count == 0) {
			System.err.println("Your basket is empty!");
			return;
		}
		double totalPrice = currentTotal() / 100.0;
		foreach (string sku in items.Keys)
			warehouse.fulfill(sku, items[sku].count);
		items = new Dictionary<string, BasketItem>();
		System.out.printf("All items checked out. Total price £%5.02f\n", totalPrice);
	}

	private int currentTotal() {
		int total = 0;
		foreach (BasketItem item in items.Values)
			total += item.count * item.price;
		if (total > 2000)
			total -= (total/10);
		return total;
	}

}
}