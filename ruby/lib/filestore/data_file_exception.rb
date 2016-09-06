package Filestore;

public class DataFileException extends RuntimeException {

	public DataFileException(String filename) {
		super("Could not read file " + filename);
	}

}
