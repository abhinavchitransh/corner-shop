package com.xpsurgery.cornershop.catalogueActions;

import com.xpsurgery.cornershop.products.Catalogue;
import com.xpsurgery.cornershop.ui.UserCommand;

public class CatalogueActions {

	private Catalogue catalogue;

	public CatalogueActions(Catalogue catalogue) {
		this.catalogue = catalogue;
	}

	public UserCommand displayProductDetails() {
		return new DisplayProductDetailsCommand(catalogue);
	}

	public UserCommand listProducts() {
		return new ListProductsCommand(catalogue);
	}

}
