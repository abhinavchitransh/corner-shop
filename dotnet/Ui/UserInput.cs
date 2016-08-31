namespace Ui {

public class UserInput {

	internal char command;
	public string[] args;

	internal UserInput(string line) {
		command = line[0];
		args = line.Split(null);
	}

	public string Args(int i) {
		if (i < 0)
			throw new IllegalArgumentException();
		return (i < args.Length) ? args[i] : null;
	}

}
}