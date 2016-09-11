package com.xpsurgery.cornershop.warehouse;

class InvalidNumItemsException extends RuntimeException {

	InvalidNumItemsException(int numItems) {
		super("Please supply a number of items greater than zero");
	}

}
