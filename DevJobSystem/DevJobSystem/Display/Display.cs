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
		private static List<string> menuOptions = new List<string> { "Option 1", "Option 2", "Option 3", "Exit" };

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

        //public async Task Run()
		//{
		//	throw new NotImplementedException();
		//}

        #region exmp

        public async Task Run()
        {
	        //await _employeeBusiness.InitialInsertInfo();

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

				        output = "Succesfully got department list";
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

				        output = $"Succesfully added employee .";
			        }
			        else if (input[0] == "7")
			        {
				        writer.Write($"Type employee's id : ");
				        int empployeeId = int.Parse(reader.ReadLine());
				        writer.Write($"Type employee's new salary :");
				        decimal newSalary = decimal.Parse(reader.ReadLine());

				        //await _employeeBusiness.UpdateEmployeeSalary(empployeeId, newSalary);

				        output = $"Succesfully updated employee salary .";
			        }
			        else if (input[0] == "8")
			        {
				        writer.Write($"Type project id : ");
				        int projectId = int.Parse(reader.ReadLine());

				        //await _employeeBusiness.FinishedProject(projectId);

				        output = $"Project was succesfully deleted";
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

        private async Task ShowMenu()
        {
	        //Console.OutputEncoding = System.Text.Encoding.UTF8;
	        Console.CursorVisible = false;
	        DrawMenu();

	        while (true)
	        {
		        var key = Console.ReadKey(true).Key;

		        switch (key)
		        {
			        case ConsoleKey.UpArrow:
				        selectedOption = Math.Max(0, selectedOption - 1);
				        break;

			        case ConsoleKey.DownArrow:
				        selectedOption = Math.Min(menuOptions.Count - 1, selectedOption + 1);
				        break;

			        case ConsoleKey.Enter:
				        if (selectedOption == menuOptions.Count - 1)
				        {
					        Console.Clear();
					        Console.WriteLine("Goodbye!");
					        return;
				        }
				        else
				        {
					        Console.Clear();
					        Console.WriteLine("You selected: " + menuOptions[selectedOption]);
					        Console.WriteLine("Press Enter to continue...");
					        Console.ReadLine();
					        DrawMenu();
				        }

				        break;
		        }

		        DrawMenu();

		        //writer.WriteLine("1. List of all department");
		        //writer.WriteLine("2. List of all employees by given department");
		        //writer.WriteLine("3. List of all employees by given salary");
		        //writer.WriteLine("4. List of all employees working on project");
		        //writer.WriteLine("5. Average salary for department");
		        //writer.WriteLine("6. Add employee");
		        //writer.WriteLine("7. Update employee salary");
		        //writer.WriteLine("8. Finish project");
		        //writer.WriteLine("9. Exit");
	        }
        }

        private static void DrawMenu()
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
			for (int i = 0; i < menuOptions.Count; i++)
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

				Console.WriteLine(menuOptions[i]);
			}

			Console.ResetColor();
		}
	}
}
