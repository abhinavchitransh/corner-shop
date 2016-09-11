package com.xpsurgery.cornershop.basketActions;

import com.xpsurgery.cornershop.basket.Basket;
import com.xpsurgery.cornershop.products.Catalogue;
import com.xpsurgery.cornershop.ui.UserCommand;
import com.xpsurgery.cornershop.warehouse.Warehouse;

public class BasketActions {

	private Basket basket;
	private Catalogue catalogue;
	private Warehouse warehouse;

	public BasketActions(Basket basket, Catalogue catalogue, Warehouse warehouse) {
		this.basket = basket;
		this.catalogue = catalogue;
		this.warehouse = warehouse;
	}

	public UserCommand addToBasket() {
		return new AddToBasketCommand(basket, catalogue, warehouse);
	}

	public UserCommand displayBasket() {
		return new DisplayBasketCommand(basket);
	}

	public UserCommand checkout() {
		return new CheckoutCommand(basket, warehouse);
	}

}
