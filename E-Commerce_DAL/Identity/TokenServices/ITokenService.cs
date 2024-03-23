namespace E_Commerce_DAL;

public interface ITokenService
{
    string CreateToken(AppUser user);
}