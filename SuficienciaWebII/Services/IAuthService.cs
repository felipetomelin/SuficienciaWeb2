namespace SuficienciaWebII.Services
{
    public interface IAuthService
    {
        (string, DateTime) GerarJwtAuth();
    }
}