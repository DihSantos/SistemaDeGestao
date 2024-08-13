namespace SistemaDeGestao.Service
{
    public interface ISeedUserRoleInitial
    {
        Task SeedRolesAsync();
        Task SeedUserAsync();
    }
}
