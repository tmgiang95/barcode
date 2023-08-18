namespace Clean.WinF.Shared.Enums
{
    public enum AuthenticateChallenge : int
    {
        NoChallenge = 1,
        NewPasswordRequired = 2,
        MutiFactoryAuthentication = 3,
        PasswordResetRequired = 4
    }
}
