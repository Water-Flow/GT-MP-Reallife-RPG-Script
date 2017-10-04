namespace TerraTex_RL_RPG.Lib.LicenseSystem
{
    public interface ILicense
    {
        int GetMinRequiredLevel();
        string GetLicenseIdentifierName();
        string GetHumanReadableName();
        string GetHumanReadableDescription();
        float GetLicensePrice();
    }
}