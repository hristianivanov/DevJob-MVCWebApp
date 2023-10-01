namespace DevJobSystem.Display
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			Display display = new Display();
			await display.Run();
		}
	}
}