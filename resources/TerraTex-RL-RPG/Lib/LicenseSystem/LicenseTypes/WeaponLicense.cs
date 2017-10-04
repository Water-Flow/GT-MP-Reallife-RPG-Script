namespace TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes
{
    public abstract class WeaponLicense : ILicense
    {
        public abstract bool IsWeaponCoveredByThisLicense(int weaponHash);

        public abstract int GetMinRequiredLevel();
        public abstract string GetLicenseIdentifierName();
        public abstract string GetHumanReadableName();
        public abstract string GetHumanReadableDescription();
        public abstract float GetLicensePrice();
    }
}