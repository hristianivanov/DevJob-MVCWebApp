namespace DevJobSystem.Display
{
	using IO;
	using IO.Contracts;

	internal class Program
	{
		static async Task Main(string[] args)
		{
			IReader reader = new ConsoleReader();
			IWriter writer = new ConsoleWriter();

			Display display = new Display(writer, reader);
			await display.Run();
		}
	}
}