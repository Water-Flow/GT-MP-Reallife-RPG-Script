namespace TerraTex_RL_RPG.Lib.Systems.LicenseSystem.LicenseTypes
{
    public abstract class FeatureLicense : ILicense
    {
        public abstract string GetFeatureName();

        public abstract int GetMinRequiredLevel();
        public abstract string GetLicenseIdentifierName();
        public abstract string GetHumanReadableName();
        public abstract string GetHumanReadableDescription();
        public abstract float GetLicensePrice();
    }
}