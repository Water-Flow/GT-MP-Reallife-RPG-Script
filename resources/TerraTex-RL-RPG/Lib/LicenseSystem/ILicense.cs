namespace TerraTex_RL_RPG.Lib.LicenseSystem
{
    public interface ILicense
    {
        int GetMinRequiredLevel();
        string GetLicenseIdentifierName();
        float GetLicensePrice();
    }
}