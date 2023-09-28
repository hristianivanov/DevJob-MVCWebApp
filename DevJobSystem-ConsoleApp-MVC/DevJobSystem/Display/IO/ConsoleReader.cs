using DevJobSystem.Display.IO.Contracts;

namespace DevJobSystem.Display.IO
{
	public class ConsoleReader : IReader
    {
        public string ReadLine()
            => Console.ReadLine();

    }
}
