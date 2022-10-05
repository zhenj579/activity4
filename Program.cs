using System;

interface Terminal
{
	List<string> commandHistory { get; set; }
	List<string> commands { get; }
	bool isAdministrator { get; set; }
	int processID { get; }
}
	

class Console : Terminal
{
	public List<string> commandHistory { get; set; } = new List<string>();
	public List<string> commands { get; } = new List<string> {"hi", "bye", "help", "admin", "history"};
	public bool isAdministrator { get; set; } = false;
	public int processID { get; } = 1;

	public string this[int i]
	{
		get { return commands[i]; }
	}

	public void runCommand(string command)
	{
		command = command.ToLower();
		if(command == "hi")
		{
			System.Console.WriteLine("hi");
		}
		else if(command == "bye")
		{
			System.Console.WriteLine("bye");
		}
		else if(command == "help")
		{
			foreach (var cmd_ in commands)
			{
				System.Console.WriteLine(cmd_);
			}
		}
		else if(command == "admin")
		{
			if(isAdministrator)
			{
				System.Console.WriteLine("admin");
			}
			else
			{
				System.Console.WriteLine("sorry you are not an admin.");
			}
		}
		else if(command == "history")
		{
			foreach (var cmd_ in commandHistory)
			{
				System.Console.WriteLine(cmd_);
			}
		}
		else if(command == "pid")
		{
			System.Console.WriteLine(processID);
		}
		else
		{
			System.Console.WriteLine("command not recognized");
		}
		commandHistory.Add(command);
	}
}

class MainClass
{
	static void Main(string[] args)
	{
		var terminal = new Console();
		terminal.runCommand("pid");
		terminal.runCommand("history");
		System.Console.WriteLine(terminal[1]);
		System.Console.ReadLine();
	}
}
