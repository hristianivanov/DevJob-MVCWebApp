namespace DevJobSystem.Display
{
	using Business;
	using IO;
	using IO.Contracts;

	public class Display
	{
		private readonly DevJobSystemBusiness business;
		private readonly IWriter writer;
		private readonly IReader reader;

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

		public Display()
		{
			this.writer = new ConsoleWriter();
			this.reader = new ConsoleReader();
			this.business = new DevJobSystemBusiness();
		}

		public Display(IWriter writer, IReader reader)
		{
			this.reader = reader;
			this.writer = writer;
		}

		#region exmp

		public async Task Run()
		{
			while (true)
			{
				Console.Clear();

				await ShowMenu();

				var input = reader
					.ReadLine()
					.Split();

				Console.Clear();

				string output = string.Empty;
				if (input[0] == "9")
				{
					Environment.Exit(0);
				}

				try
				{
					if (input[0] == "1")
					{
						//List<Department> departments = await _employeeBusiness.GetAllDepartments();

						//if (departments.Count == 0)
						throw new ArgumentException("Departments count is 0");

						output = "Successfully got department list";
					}
					else if (input[0] == "2")
					{
						writer.Write($"Type department name : ");
						string departmentName = reader.ReadLine();

						//List<string> employees = await _employeeBusiness.GetEmployeesNameByDepartment(departmentName);

						//if (employees.Count == 0)
						output = "There are no employees in that department .";
						//else
						//output = string.Join(", ", employees);
					}
					else if (input[0] == "3")
					{
						writer.Write($"Type salary : ");
						decimal salary = decimal.Parse(reader.ReadLine());

						//List<Employee> employees = await _employeeBusiness.GetEmployeesBySalary(salary);

						//if (!employees.Any())
						output = "There are no employees with that salary .";
						//else
						//output = string.Join(", ", employees.Select(e => $"{e.FirstName} {e.LastName}"));
					}
					else if (input[0] == "4")
					{
						writer.Write($"Type project name : ");
						string projectName = reader.ReadLine();

						//List<string> employees = await _employeeBusiness.GetEmployeesNameByWorkingProject(projectName);

						//if (!employees.Any())
						output = $"There is not existing project with that name .";
						//else
						//output = string.Join(", ", employees);
					}
					else if (input[0] == "5")
					{
						writer.Write($"Type department name : ");
						string departmentName = reader.ReadLine();

						//decimal avgSalary = await _employeeBusiness.GetAverageSalaryByDepartment(departmentName);

						//output = $"Average salary is {avgSalary} .";
					}
					else if (input[0] == "6")
					{
						writer.Write($"Type employee's info in order 'firstName lastName salary departmentName'");
						string[] employeeArgs = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
						string firstName = employeeArgs[1];
						string lastName = employeeArgs[2];
						decimal salary = decimal.Parse(employeeArgs[3]);
						string departmentName = employeeArgs[4];

						//await _employeeBusiness.AddEmployee(firstName, lastName, salary, departmentName);

						output = $"Successfully added employee .";
					}
					else if (input[0] == "7")
					{
						writer.Write($"Type employee's id : ");
						int empployeeId = int.Parse(reader.ReadLine());
						writer.Write($"Type employee's new salary :");
						decimal newSalary = decimal.Parse(reader.ReadLine());

						//await _employeeBusiness.UpdateEmployeeSalary(empployeeId, newSalary);

						output = $"Successfully updated employee salary .";
					}
					else if (input[0] == "8")
					{
						writer.Write($"Type project id : ");
						int projectId = int.Parse(reader.ReadLine());

						//await _employeeBusiness.FinishedProject(projectId);

						output = $"Project was successfully deleted";
					}
					else
					{
						throw new InvalidOperationException();
					}

					writer.WriteLine(output);

					Thread.Sleep(2000);
				}
				catch (Exception ex)
				{
					writer.WriteLine(ex.Message);
				}
			}

		}

		#endregion

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
							// Handle sub-menu options here
							// Example:
							if (subMenuSelectedOption == 0)
							{
								writer.WriteLine("Companies");
								await Task.Delay(2000);
							}
							else if (subMenuSelectedOption == 1)
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
						else
						{
							Console.Clear();
							//Handle other main menu options here
						}

						break;
				}

				DrawMainMenu();
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

				writer.WriteLine(mainMenuOptions[i]);
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

	}
}
