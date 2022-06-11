namespace Persistence.SeedData
{
    public static class SeedAppData
    {
        public static async Task SeedData(PublicDataContext context)
        {
            var aml = AmlSeedData.Create();
            var riksavtalen = CollectiveAgreementSeedData.Create();
            var employers = EmployerSeedData.CreateEmployers(riksavtalen);

            if (!context.Employers.Any())
            {
                await context.Aml.AddAsync(aml);
                await context.CollectiveAgreeements.AddAsync(riksavtalen);
                await context.Employers.AddRangeAsync(employers);
            }

            await context.SaveChangesAsync();
        }
    }
}
