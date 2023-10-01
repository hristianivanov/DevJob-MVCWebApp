namespace DevJobSystem
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			Display.Display display = new Display.Display();
			await display.Run();
		}
	}
}