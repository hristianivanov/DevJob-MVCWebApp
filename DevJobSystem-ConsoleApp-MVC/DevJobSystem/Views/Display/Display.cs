namespace DevJobSystem.Display
{
	using Data;
	using Services;
	using Services.Interfaces;

	public class Display
	{
		private readonly ICompanyService companyService;
		private readonly IJobService jobService;
		private readonly IProgrammerService programmerService;
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
			"All Programmers",
			"Back to Main Menu",
		};
		private string[] subMenuOptionsAddingItem = new string[]
		{
			"Company",
			"Job offer",
			"Programmer",
			"Back to Main Menu",
		};

		private string[] subMenuOptionsSearchItem = new string[]
		{
			"Company by address",
			"Companies by programmers max count",
			"Jobs by technology (requirements)",
			"Jobs by salary in range (min/max)",
			"Back to Main Menu",
		};

		private string[] subMenuOptionsDeleteItem = new string[]
		{
			"Company by name",
			"Job offer by id",
			"Programmer by id",
			"Back to Main Menu",
		};
		private string[] subMenuOptionsOthrFunc = new string[]
		{
			"Update Job Offer by ID",
			"Hire programmer to company",
			"Apply for job", // this is not done
			"Back to Main Menu",
		};

		public Display()
		{
			this.dbContext = new DevJobSystemDbContext();
			this.companyService = new CompanyService(dbContext);
			this.jobService = new JobService(dbContext);
			this.programmerService = new ProgrammerService(dbContext);
		}

		public async Task Run()
		=> await ShowMenu();
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
							Console.WriteLine("Goodbye!");
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
						else if (selectedOption == 2) //"Search item"
						{
							await ShowSubMenuSearchItem();
							Console.Clear();
							DrawMainMenu();
						}
						else if (selectedOption == 3) //"Delete item"
						{
							await ShowSubMenuDeleteItem();
							Console.Clear();
							DrawMainMenu();
						}
						else if (selectedOption == 4) //"Other func"
						{
							await ShowSubMenuOthrFunc();
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
			subMenuSelectedOption = 0;
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

								foreach (var company in companies)
								{
									Console.WriteLine(company.Name);
								}

								Console.WriteLine();
								await Task.Delay(2000);
							}
							//Available Jobs
							else if (subMenuSelectedOption == 1)
							{
								var jobs = await this.jobService.AllAsync();

								foreach (var job in jobs)
								{
									Console.WriteLine($"{job.Description} -> {job.Salary:f2}");
								}

								Console.WriteLine();
								await Task.Delay(2000);
							}
							//All Programmers
							else if (subMenuSelectedOption == 2)
							{
								var programmers = await this.programmerService.AllAsync();

								foreach (var programmer in programmers)
								{
									Console.WriteLine($"{programmer.FirstName} {programmer.LastName} / {programmer.Experience} years / {programmer.Salary} euro / {programmer.Skill}");
								}

								Console.WriteLine();
								await Task.Delay(2000);
							}
						}

						Console.WriteLine("Press enter to continue...");
						Console.ReadLine();
						break;
				}

				DrawSubMenuListOfAll();
			}
		}
		private async Task ShowSubMenuAddingItem()
		{
			subMenuSelectedOption = 0;
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

							//Company
							if (subMenuSelectedOption == 0)
							{
								try
								{
									Console.Write("Enter company's name : ");
									string companyName = Console.ReadLine()!;

									Console.Write("Enter company's address : ");
									string companyAddress = Console.ReadLine()!;

									await this.companyService.CreateAsync(companyName, companyAddress);
								}
								catch (Exception e)
								{
									Console.WriteLine(e);
								}

								await Task.Delay(2000);
								Console.WriteLine("You successfully created the new company!");
								await Task.Delay(1000);

								Console.Clear();
							}
							//Job offer
							else if (subMenuSelectedOption == 1)
							{
								try
								{
									Console.Write("Enter job's description :");
									string jobDescription = Console.ReadLine()!;

									Console.Write("Enter job's requirements :");
									string jobRequirements = Console.ReadLine()!;

									Console.Write("Enter job's salary :");
									decimal jobSalary = decimal.Parse(Console.ReadLine()!);

									await this.jobService.CreateAsync(jobDescription, jobRequirements, jobSalary);
								}
								catch (Exception e)
								{
									Console.WriteLine(e);
								}

								await Task.Delay(2000);
								Console.WriteLine("You successfully created the new job offer!");
								await Task.Delay(1000);

								Console.Clear();
							}
							//Programmer
							else if (subMenuSelectedOption == 2)
							{
								try
								{
									Console.Write("Enter programmer's first name :");
									string programmerFirstName = Console.ReadLine()!;

									Console.Write("Enter programmer's last name :");
									string programmerLastName = Console.ReadLine()!;

									Console.Write("Enter programmer's skill (technologies) :");
									string programmerSkill = Console.ReadLine()!;

									Console.Write("Enter programmer's experience (digits) :");
									int programmerExperience = int.Parse(Console.ReadLine()!);

									Console.Write("Enter programmer's salary :");
									decimal programmerSalary = decimal.Parse(Console.ReadLine()!);

									await this.programmerService.CreateAsync(programmerFirstName, programmerLastName,
										programmerExperience, programmerSkill, programmerSalary);
								}
								catch (Exception e)
								{
									Console.WriteLine(e);
								}

								await Task.Delay(2000);
								Console.WriteLine("You successfully created the new programmer!");
								await Task.Delay(1000);

								Console.Clear();
							}
						}

						break;
				}

				DrawSubMenuAddingItem();
			}
		}
		private async Task ShowSubMenuSearchItem()
		{
			subMenuSelectedOption = 0;
			DrawSubMenuSearchItem();

			while (true)
			{
				var key = Console.ReadKey(true).Key;

				switch (key)
				{
					case ConsoleKey.UpArrow:
						subMenuSelectedOption = Math.Max(0, subMenuSelectedOption - 1);
						break;

					case ConsoleKey.DownArrow:
						subMenuSelectedOption = Math.Min(subMenuOptionsSearchItem.Length - 1, subMenuSelectedOption + 1);
						break;

					case ConsoleKey.Enter:
						if (subMenuSelectedOption == subMenuOptionsSearchItem.Length - 1)
						{
							Console.Clear();
							return;
						}
						else
						{
							Console.Clear();

							//company by address
							if (subMenuSelectedOption == 0)
							{
								Console.Write("Enter address value : ");
								string address = Console.ReadLine()!;

								var company = await this.companyService.GetCompanyByAddressAsync(address);

								if (company != null)
								{
									Console.WriteLine("Successfully found result :");
									await Console.Out.WriteLineAsync($"{company.Name} ,{company.Address} -> {company.AvgSalary}");
								}
								else
									await Console.Out.WriteLineAsync("There is no result!");
							}
							//company by programmers max count
							else if (subMenuSelectedOption == 1)
							{
								Console.Write("Enter programmers count : ");
								int count = int.Parse(Console.ReadLine()!);

								var companies = await this.companyService.GetCompaniesByMaxProgrammersCountAsync(count);

								foreach (var company in companies)
								{
									await Console.Out.WriteLineAsync($"{company.Name}");
								}
							}
							// jobs by technology  (requirements)
							else if (subMenuSelectedOption == 2)
							{
								Console.Write("Enter technology : ");
								string technology = Console.ReadLine()!;

								var jobs = await this.jobService.AllJobsByTechnologyAsync(technology);

								foreach (var job in jobs)
								{
									await Console.Out.WriteLineAsync($"{job.Description} -> {job.Salary:f2}");
								}
							}
							// jobs by salary in range (min/max)
							else if (subMenuSelectedOption == 3)
							{
								Console.Write("Enter minimum salary value : ");
								decimal min = decimal.Parse(Console.ReadLine()!);

								Console.Write("Enter maximum salary value : ");
								decimal max = decimal.Parse(Console.ReadLine()!);

								var jobs = await this.jobService.AllBySalaryAsync(min, max);

								foreach (var job in jobs)
								{
									await Console.Out.WriteLineAsync($"{job.Description} {job.Requirements} / {job.Salary:f2}");
								}
							}
						}

						Console.WriteLine("Press enter to continue...");
						Console.ReadLine();
						break;
				}

				DrawSubMenuSearchItem();
			}
		}
		private async Task ShowSubMenuDeleteItem()
		{
			subMenuSelectedOption = 0;
			DrawSubMenuDeleteItem();

			while (true)
			{
				var key = Console.ReadKey(true).Key;

				switch (key)
				{
					case ConsoleKey.UpArrow:
						subMenuSelectedOption = Math.Max(0, subMenuSelectedOption - 1);
						break;

					case ConsoleKey.DownArrow:
						subMenuSelectedOption = Math.Min(subMenuOptionsDeleteItem.Length - 1, subMenuSelectedOption + 1);
						break;

					case ConsoleKey.Enter:
						if (subMenuSelectedOption == subMenuOptionsDeleteItem.Length - 1)
						{
							Console.Clear();
							return;
						}
						else
						{
							Console.Clear();

							//company by name
							if (subMenuSelectedOption == 0)
							{
								Console.Write("Enter company's name to delete :");
								string name = Console.ReadLine()!;

								bool result = await this.companyService.DeleteByNameAsync(name);

								if (result)
									Console.WriteLine("Successful delete!");
								else
									Console.WriteLine("Unsuccessful delete!");
							}
							//job offer by id (int)
							else if (subMenuSelectedOption == 1)
							{
								Console.Write("Enter job's offer id (int) : ");
								int id = int.Parse(Console.ReadLine()!);

								bool result = await this.jobService.DeleteByIdAsync(id);

								if (result)
									Console.WriteLine("Successful delete!");
								else
									Console.WriteLine("Unsuccessful delete!");
							}
							// programmer by id (guid)
							else if (subMenuSelectedOption == 2)
							{
								Console.Write("Enter programmer's id : ");
								string id = Console.ReadLine()!;

								bool result = await this.programmerService.DeleteById(id);

								if (result)
									Console.WriteLine("Successful delete!");
								else
									Console.WriteLine("Unsuccessful delete!");
							}
						}

						Console.WriteLine("Press enter to continue...");
						Console.ReadLine();
						break;
				}

				DrawSubMenuDeleteItem();
			}
		}
		private async Task ShowSubMenuOthrFunc()
		{
			subMenuSelectedOption = 0;
			DrawSubMenuOthrFunc();

			while (true)
			{
				var key = Console.ReadKey(true).Key;

				switch (key)
				{
					case ConsoleKey.UpArrow:
						subMenuSelectedOption = Math.Max(0, subMenuSelectedOption - 1);
						break;

					case ConsoleKey.DownArrow:
						subMenuSelectedOption = Math.Min(subMenuOptionsOthrFunc.Length - 1, subMenuSelectedOption + 1);
						break;

					case ConsoleKey.Enter:
						if (subMenuSelectedOption == subMenuOptionsOthrFunc.Length - 1)
						{
							Console.Clear();
							return;
						}
						else
						{
							Console.Clear();

							//update job offer by id (int)
							if (subMenuSelectedOption == 0)
							{
								Console.Write("Enter job offer id for update : ");
								int id = int.Parse(Console.ReadLine()!);

								Console.Write("Enter job offer's description : ");
								string description = Console.ReadLine()!;

								Console.Write("Enter job offer's salary : ");
								decimal salary = decimal.Parse(Console.ReadLine()!);

								Console.Write("Enter job offer's requirements : ");
								string requirements = Console.ReadLine()!;

								await this.jobService.UpdateJob(id, description, salary, requirements);

								Console.WriteLine("All done! Go check the results.");
							}
							//hire programmer to company
							else if (subMenuSelectedOption == 1)
							{
								Console.Write("Enter company id (guid) :");
								string companyId = Console.ReadLine()!;

								Console.Write("Enter programmer id (guid) :");
								string programmerId = Console.ReadLine()!;

								await this.companyService.HireProgrammer(companyId, programmerId);

								Console.WriteLine("All done! Go check the results.");
							}
						}

						Console.WriteLine("Press enter to continue...");
						Console.ReadLine();
						break;
				}

				DrawSubMenuOthrFunc();
			}
		}

		private void DrawMainMenu()
		{
			Console.Clear();
			Console.WriteLine(@"
██████╗░███████╗██╗░░░██╗░░░░░██╗░█████╗░██████╗
██╔══██╗██╔════╝██║░░░██║░░░░░██║██╔══██╗██╔══██╗
██║░░██║█████╗░░╚██╗░██╔╝░░░░░██║██║░░██║██████╦╝
██║░░██║██╔══╝░░░╚████╔╝░██╗░░██║██║░░██║██╔══██╗
██████╔╝███████╗░░╚██╔╝░░╚█████╔╝╚█████╔╝██████╦╝
╚═════╝░╚══════╝░░░╚═╝░░░░╚════╝░░╚════╝░╚═════╝​​​​​");
			Console.WriteLine("Main Menu:");
			for (int i = 0; i < mainMenuOptions.Length; i++)
			{
				if (i == selectedOption)
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.DarkBlue;
					Console.Write("-> ");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkBlue;
					Console.BackgroundColor = ConsoleColor.Black;
					Console.Write("   ");
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

				Console.WriteLine(mainMenuOptions[i]);

				Console.ResetColor();
			}

			Console.ResetColor();
		}
		private void DrawSubMenuListOfAll()
		{
			Console.Clear();
			Console.WriteLine("Sub Menu:");
			for (int i = 0; i < subMenuOptionsListOfAll.Length; i++)
			{
				if (i == subMenuSelectedOption)
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.DarkGreen;
					Console.Write("-> ");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					Console.BackgroundColor = ConsoleColor.Black;
					Console.Write("   ");
				}

				if (i == subMenuOptionsListOfAll.Length - 1)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
				}

				Console.WriteLine(subMenuOptionsListOfAll[i]);

				Console.ResetColor();
			}

			Console.ResetColor();
		}
		private void DrawSubMenuAddingItem()
		{
			Console.Clear();
			Console.WriteLine("Adding Item Sub-Menu:");

			for (int i = 0; i < subMenuOptionsAddingItem.Length; i++)
			{
				if (i == subMenuSelectedOption)
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.DarkYellow;
					Console.Write("-> ");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.BackgroundColor = ConsoleColor.Black;
					Console.Write("   ");
				}

				if (i == subMenuOptionsAddingItem.Length - 1)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
				}

				Console.WriteLine(subMenuOptionsAddingItem[i]);

				Console.ResetColor();
			}

			Console.ResetColor();
		}
		private void DrawSubMenuSearchItem()
		{
			Console.Clear();
			Console.WriteLine("Search Item Sub-Menu:");

			for (int i = 0; i < subMenuOptionsSearchItem.Length; i++)
			{
				if (i == subMenuSelectedOption)
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.DarkMagenta;
					Console.Write("-> ");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkMagenta;
					Console.BackgroundColor = ConsoleColor.Black;
					Console.Write("   ");
				}

				if (i == subMenuOptionsSearchItem.Length - 1)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
				}

				Console.WriteLine(subMenuOptionsSearchItem[i]);

				Console.ResetColor();
			}

			Console.ResetColor();
		}
		private void DrawSubMenuDeleteItem()
		{
			Console.Clear();
			Console.WriteLine("Delete Item Sub-Menu:");

			for (int i = 0; i < subMenuOptionsDeleteItem.Length; i++)
			{
				if (i == subMenuSelectedOption)
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Cyan;
					Console.Write("-> ");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.BackgroundColor = ConsoleColor.Black;
					Console.Write("   ");
				}

				if (i == subMenuOptionsDeleteItem.Length - 1)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
				}

				Console.WriteLine(subMenuOptionsDeleteItem[i]);

				Console.ResetColor();
			}

			Console.ResetColor();
		}
		private void DrawSubMenuOthrFunc()
		{
			Console.Clear();
			Console.WriteLine("Other functionality Sub-Menu:");

			for (int i = 0; i < subMenuOptionsOthrFunc.Length; i++)
			{
				if (i == subMenuSelectedOption)
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.Write("-> ");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.BackgroundColor = ConsoleColor.Black;
					Console.Write("   ");
				}

				if (i == subMenuOptionsOthrFunc.Length - 1)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
				}

				Console.WriteLine(subMenuOptionsOthrFunc[i]);

				Console.ResetColor();
			}

			Console.ResetColor();
		}

	}
}
