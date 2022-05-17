namespace Persistence.SeedData
{
    public static class SeedAppData
    {
        public static async Task SeedData(PublicDataContext context)
        {
            var riksavtalen = CollectiveAgreementSeedData.CreateRiksAvtalen();
            var employers = EmployerSeedData.CreateEmployers(riksavtalen);

            if (!context.Employers.Any())
            {
                await context.CollectiveAgreeements.AddAsync(riksavtalen);
                await context.Employers.AddRangeAsync(employers);
            }

            await context.SaveChangesAsync();
        }
    }
}
