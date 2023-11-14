namespace GWI.Services
{
    public interface ISessao
    {
        void addTokenLogin(Login login);

        Login getTokenLogin();
        void deleteTokenLogin();
    }
}

