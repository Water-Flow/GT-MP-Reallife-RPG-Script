namespace TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes
{
    public abstract class FeatureLicense : ILicense
    {
        public abstract string GetFeatureName();

        public abstract int GetMinRequiredLevel();
        public abstract string GetLicenseIdentifierName();
        public abstract float GetLicensePrice();
    }
}