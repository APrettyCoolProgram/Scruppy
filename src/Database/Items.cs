// 250214_code
// 250214_documentation

namespace Scruppy.Database;

internal class Items
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Flavor { get; set; }

    public string Rarity { get; set; }

    public int Value { get; set; }

    public string ItemType { get; set; }

    public string SubCategory { get; set; }

    public string AmmoType { get; set; }

    public string SheildType { get; set; }

    public string LootArea { get; set; }

    public string Sources { get; set; }

    public Locations Location { get; set; }

    public GuideLinks GuideLink { get; set; }

    public string GameAssetId { get; set; }

    public string IconUrl { get; set; }

    public string CreatedAt { get; set; }

    public string UpdatedAt { get; set; }

    public List<string> Slot { get; set; }

    public List<string> Workbench { get; set; }

    public Stats Stat { get; set; }

    internal class Stats
    {
        public int Range { get; set; }

        public int Damage { get; set; }

        public int Health { get; set; }

        public int Radius { get; set; }

        public int Shield { get; set; }

        public double Weight { get; set; }

        public int Agility { get; set; }

        public int ArcStun { get; set; }

        public int Healing { get; set; }

        public int Stamina { get; set; }

        public int Stealth { get; set; }

        public int UseTime { get; set; }

        public int Duration { get; set; }

        public int FireRate { get; set; }

        public int Stability { get; set; }

        public int StackSize { get; set; }

        public double DamageMult { get; set; }

        public int RaiderStun { get; set; }

        public int WeightLimit { get; set; }

        public int AugmentSlots { get; set; }

        public int HealingSlots { get; set; }

        public int MagazineSize { get; set; }

        public int ReducedNoise { get; set; }

        public int ShieldCharge { get; set; }

        public int BackpackSlots { get; set; }

        public int QuickUseSlots { get; set; }

        public double DamagePerSecond { get; set; }

        public double MovementPenalty { get; set; }

        public int SafePocketSlots { get; set; }

        public double DamageMitigation { get; set; }

        public double HealingPerSecond { get; set; }

        public int ReducedEquipTime { get; set; }

        public double StaminaPerSecond { get; set; }

        public int IncreasedADSSpeed { get; set; }

        public int IncreasedFireRate { get; set; }

        public int ReducedReloadTime { get; set; }

        public int IlluminationRadius { get; set; }

        public int IncreasedEquipTime { get; set; }

        public int ReducedUnequipTime { get; set; }

        public string ShieldCompatibility { get; set; }

        public int IncreasedUnequipTime { get; set; }

        public int ReducedVerticalRecoil { get; set; }

        public int IncreasedBulletVelocity { get; set; }

        public int IncreasedVerticalRecoil { get; set; }

        public int ReducedMaxShotDispersion { get; set; }

        public int ReducedPerShotDispersion { get; set; }

        public int ReducedDurabilityBurnRate { get; set; }

        public int ReducedRecoilRecoveryTime { get; set; }

        public int IncreasedRecoilRecoveryTime { get; set; }

        public int ReducedDispersionRecoveryTime { get; set; }
    }

    public class Locations
    {
        public string Id { get; set; }
        public string Map { get; set; }
    }

    public class GuideLinks
    {
        public string Url { get; set; }
        public string Label { get; set; }
    }
}