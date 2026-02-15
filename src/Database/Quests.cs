// 250214_code
// 250214_documentation

namespace Scruppy.Database;

internal class Quests
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<string> Objectives { get; set; }

    public int Xp { get; set; }

    public List<GrantedItems> GrantedItem { get; set; }

    public List<RequiredItems> RequiredItem { get; set; }

    public List<Rewards> Reward { get; set; }

    public Locations Location { get; set; }

    public GuideLinks GuideLink { get; set; }

    public string TraderName { get; set; }

    public int SortOrder { get; set; }

    public Positions Position { get; set; }

    public string MarkerCategory { get; set; }

    public string ImageUrl { get; set; }

    public string CreatedAt { get; set; }

    public string UpdatedAt { get; set; }

    public class GrantedItems
    {
        public string Id { get; set; }

        public TraderItems TraderItem { get; set; }

        public string ItemId { get; set; }

        public int Quantity { get; set; }
    }

    public class RequiredItems
    {
        public string Id { get; set; }

        public TraderItems TraderItem { get; set; }

        public string ItemId { get; set; }

        public int Quantity { get; set; }
    }

    public class Rewards
    {
        public string Id { get; set; }

        public TraderItems TraderItem { get; set; }

        public string ItemId { get; set; }

        public int Quantity { get; set; }
    }

    public class TraderItems
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string ItemType { get; set; }
        public string IconUrl { get; set; }
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

    public class Positions
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}