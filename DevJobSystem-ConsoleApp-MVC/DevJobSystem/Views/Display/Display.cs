namespace DevJobSystem.Display
{
	using Business;
	using DevJobSystem.Data;
	using DevJobSystem.Services;
	using DevJobSystem.Services.Interfaces;
	using IO;
	using IO.Contracts;

	public class Display
	{
		private readonly IWriter writer;
		private readonly IReader reader;
		private readonly ICompanyService companyService;
		private readonly DevJobSystemDbContext dbContext;

		private static int selectedOption = 0;
		private static int subMenuSelectedOption = 0;
		private static string[] mainMenuOptions = new string[]
		{
			"List of all",
			"Adding item",
			"Search item",
			"Delete item",
			"Other functionality",
			"Exit"
		};
		private static string[] subMenuOptionsListOfAll = new string[]
		{
			"Dev Companies",
			"Available Jobs",
			"Hired Programmers",
			"Back to Main Menu"
		};
		private string[] subMenuOptionsAddingItem = new string[]
		{
			"Company",
			"Job offer",
			"Programmer",
			"Back to Main Menu",
		};

		public Display()
		{
			this.writer = new ConsoleWriter();
			this.reader = new ConsoleReader();
			this.dbContext = new DevJobSystemDbContext();
			this.companyService = new CompanyService(dbContext);
		}

		public async Task Run()
		{
			await ShowMenu();
		}

		private async Task ShowMenu()
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			Console.CursorVisible = false;

			DrawMainMenu();

			while (true)
			{
				var key = Console.ReadKey(true).Key;

				switch (key)
				{
					case ConsoleKey.UpArrow:
						selectedOption = Math.Max(0, selectedOption - 1);
						break;

					case ConsoleKey.DownArrow:
						selectedOption = Math.Min(mainMenuOptions.Length - 1, selectedOption + 1);
						break;

					case ConsoleKey.Enter:
						if (selectedOption == mainMenuOptions.Length - 1)
						{
							Console.Clear();
							writer.WriteLine("Goodbye!");
							return;
						}
						else if (selectedOption == 0) //"List of all"
						{
							await ShowSubMenuListOfAll();
							Console.Clear();
							DrawMainMenu();
						}
						else if (selectedOption == 1) //"Adding item"
						{
							await ShowSubMenuAddingItem();
							Console.Clear();
							DrawMainMenu();
						}
						else
						{
							Console.Clear();
						}

						break;
				}

				DrawMainMenu();
			}
		}

		private async Task ShowSubMenuListOfAll()
		{
			DrawSubMenuListOfAll();

			while (true)
			{
				var key = Console.ReadKey(true).Key;

				switch (key)
				{
					case ConsoleKey.UpArrow:
						subMenuSelectedOption = Math.Max(0, subMenuSelectedOption - 1);
						break;

					case ConsoleKey.DownArrow:
						subMenuSelectedOption = Math.Min(subMenuOptionsListOfAll.Length - 1, subMenuSelectedOption + 1);
						break;

					case ConsoleKey.Enter:
						if (subMenuSelectedOption == subMenuOptionsListOfAll.Length - 1)
						{
							Console.Clear();
							return;
						}
						else
						{
							Console.Clear();
							
							//Dev companies
							if (subMenuSelectedOption == 0)
							{
								var companies = await this.companyService.AllAsync();

								writer.WriteLine(string.Join(", ", companies.Select(x => x.Name)));

								await Task.Delay(2000);
							}
							//Available Jobs
							else if (subMenuSelectedOption == 1)
							{
								writer.WriteLine("Jobs");
								await Task.Delay(2000);
							}
							//Hired Programmers
							else if (subMenuSelectedOption == 2)
							{
								writer.WriteLine("Jobs");
								await Task.Delay(2000);
							}
						}

						break;
				}

				DrawSubMenuListOfAll();
			}
		}
		private async Task ShowSubMenuAddingItem()
		{
			DrawSubMenuAddingItem();

			while (true)
			{
				var key = Console.ReadKey(true).Key;

				switch (key)
				{
					case ConsoleKey.UpArrow:
						subMenuSelectedOption = Math.Max(0, subMenuSelectedOption - 1);
						break;

					case ConsoleKey.DownArrow:
						subMenuSelectedOption = Math.Min(subMenuOptionsListOfAll.Length - 1, subMenuSelectedOption + 1);
						break;

					case ConsoleKey.Enter:
						if (subMenuSelectedOption == subMenuOptionsListOfAll.Length - 1)
						{
							Console.Clear();
							return;
						}
						else
						{
							Console.Clear();

							if (subMenuSelectedOption == 0)
							{
								writer.WriteLine("Company");
								await Task.Delay(2000);
							}
							else if (subMenuSelectedOption == 1)
							{
								writer.WriteLine("Job");
								await Task.Delay(2000);
							}
						}

						break;
				}

				DrawSubMenuAddingItem();
			}
		}

		private void DrawMainMenu()
		{
			Console.Clear();
			writer.WriteLine(@"
██████╗░███████╗██╗░░░██╗░░░░░██╗░█████╗░██████╗
██╔══██╗██╔════╝██║░░░██║░░░░░██║██╔══██╗██╔══██╗
██║░░██║█████╗░░╚██╗░██╔╝░░░░░██║██║░░██║██████╦╝
██║░░██║██╔══╝░░░╚████╔╝░██╗░░██║██║░░██║██╔══██╗
██████╔╝███████╗░░╚██╔╝░░╚█████╔╝╚█████╔╝██████╦╝
╚═════╝░╚══════╝░░░╚═╝░░░░╚════╝░░╚════╝░╚═════╝​​​​​");
			writer.WriteLine("Main Menu:");
			for (int i = 0; i < mainMenuOptions.Length; i++)
			{
				if (i == selectedOption)
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.DarkBlue;
					writer.Write("-> ");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkBlue;
					Console.BackgroundColor = ConsoleColor.Black;
					writer.Write("   ");
				}

				switch (i)
				{
					case 0:
						Console.ForegroundColor = ConsoleColor.Yellow; // "List of all"
						break;
					case 1:
						Console.ForegroundColor = ConsoleColor.Yellow; // "Adding item"
						break;
					case 2:
						Console.ForegroundColor = ConsoleColor.Yellow;
						break;
					case 3:
						Console.ForegroundColor = ConsoleColor.Yellow;
						break;
					case 4:
						Console.ForegroundColor = ConsoleColor.Yellow;
						break;
					default:
						Console.ForegroundColor = ConsoleColor.Red; // "Other functionality"
						break;
				}

				writer.WriteLine(mainMenuOptions[i]);

				Console.ResetColor();
			}

			Console.ResetColor();
		}
		private void DrawSubMenuListOfAll()
		{
			Console.Clear();
			writer.WriteLine("Sub Menu:");
			for (int i = 0; i < subMenuOptionsListOfAll.Length; i++)
			{
				if (i == subMenuSelectedOption)
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.DarkGreen;
					writer.Write("-> ");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					Console.BackgroundColor = ConsoleColor.Black;
					writer.Write("   ");
				}

				if (i == subMenuOptionsListOfAll.Length - 1)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
				}

				writer.WriteLine(subMenuOptionsListOfAll[i]);

				Console.ResetColor();
			}

			Console.ResetColor();
		}
		private void DrawSubMenuAddingItem()
		{
			Console.Clear();
			writer.WriteLine("Adding Item Sub-Menu:");

			for (int i = 0; i < subMenuOptionsAddingItem.Length; i++)
			{
				if (i == subMenuSelectedOption)
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.DarkYellow;
					writer.Write("-> ");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.BackgroundColor = ConsoleColor.Black;
					writer.Write("   ");
				}

				writer.WriteLine(subMenuOptionsAddingItem[i]);

				Console.ResetColor();
			}

			Console.ResetColor();
		}
	}
}
