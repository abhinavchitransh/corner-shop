namespace CatalogueActions {

using Products;
using Ui;

class ListProductsCommand : UserCommand {

	private Catalogue catalogue;

	internal ListProductsCommand(Catalogue catalogue) {
		this.catalogue = catalogue;
	}

	public void run(UserInput cmd) {
		catalogue.list();
	}

}
}