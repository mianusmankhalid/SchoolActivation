namespace SchoolActivation.Models
{
	public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            context.SaveChanges();
        }
    }
}
