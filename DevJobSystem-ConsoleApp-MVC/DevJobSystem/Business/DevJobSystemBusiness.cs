namespace DevJobSystem.Business
{
	using System.ComponentModel.DataAnnotations;

	using Data;

	public class DevJobSystemBusiness
	{
		private readonly DevJobSystemDbContext dbContext;

        public DevJobSystemBusiness()
        {
            dbContext = new DevJobSystemDbContext();
        }

        private static async Task<bool> IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}
