namespace DevJobSystem.Common
{
	public static class EntityValidationConstants
	{
		public static class Company
		{
			public const int NameMaxLength = 50;
			public const int NameMinLength = 3;

			public const int AddressMaxLength = 50;
			public const int AddressMinLength = 50;
		}

		public static class Programmer
		{
			public const int FirstNameMinLength = 2;
			public const int FirstNameMaxLength = 50;

			public const int LastNameMinLength = 3;
			public const int LastNameMaxLength = 50;
		}

		public static class JobApplication
		{
			public const int CandidateNameMaxLength = 100;
		}
	}
}
