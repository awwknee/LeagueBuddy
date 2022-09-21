using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeagueBuddyConnector.Models.LiveGame
{
    public partial class LiveGameData
    {
        [JsonPropertyName("activePlayer")]
        public ActivePlayer ActivePlayer { get; set; }

        [JsonPropertyName("allPlayers")]
        public AllPlayer[] AllPlayers { get; set; }

        [JsonPropertyName("events")]
        public Events Events { get; set; }

        [JsonPropertyName("gameData")]
        public GameData GameData { get; set; }
    }

    public partial class Abilities
    {
        [JsonPropertyName("Passive")]
        public Ability Passive { get; set; }

        [JsonPropertyName("Q")]
        public Ability Q { get; set; }

        [JsonPropertyName("W")]
        public Ability W { get; set; }

        [JsonPropertyName("E")]
        public Ability E { get; set; }

        [JsonPropertyName("R")]
        public Ability R { get; set; }
    }

    public partial class Ability
    {
        [JsonPropertyName("abilityLevel")]
        public int AbilityLevel { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("rawDescription")]
        public string RawDescription { get; set; }

        [JsonPropertyName("rawDisplayName")]
        public string RawDisplayName { get; set; }
    }

    public partial class ChampionStats
    {
        [JsonPropertyName("abilityPower")]
        public float AbilityPower { get; set; }

        [JsonPropertyName("armor")]
        public float Armor { get; set; }

        [JsonPropertyName("armorPenetrationFlat")]
        public float ArmorPenetrationFlat { get; set; }

        [JsonPropertyName("armorPenetrationPercent")]
        public float ArmorPenetrationPercent { get; set; }

        [JsonPropertyName("attackDamage")]
        public float AttackDamage { get; set; }

        [JsonPropertyName("attackRange")]
        public float AttackRange { get; set; }

        [JsonPropertyName("attackSpeed")]
        public float AttackSpeed { get; set; }

        [JsonPropertyName("bonusArmorPenetrationPercent")]
        public float BonusArmorPenetrationPercent { get; set; }

        [JsonPropertyName("bonusMagicPenetrationPercent")]
        public float BonusMagicPenetrationPercent { get; set; }

        [JsonPropertyName("cooldownReduction")]
        public float CooldownReduction { get; set; }

        [JsonPropertyName("critChance")]
        public float CritChance { get; set; }

        [JsonPropertyName("critDamage")]
        public float CritDamage { get; set; }

        [JsonPropertyName("currentHealth")]
        public float CurrentHealth { get; set; }

        [JsonPropertyName("healthRegenRate")]
        public float HealthRegenRate { get; set; }

        [JsonPropertyName("lifeSteal")]
        public float LifeSteal { get; set; }

        [JsonPropertyName("magicLethality")]
        public float MagicLethality { get; set; }

        [JsonPropertyName("magicPenetrationFlat")]
        public float MagicPenetrationFlat { get; set; }

        [JsonPropertyName("magicPenetrationPercent")]
        public float MagicPenetrationPercent { get; set; }

        [JsonPropertyName("magicResist")]
        public float MagicResist { get; set; }

        [JsonPropertyName("maxHealth")]
        public float MaxHealth { get; set; }

        [JsonPropertyName("moveSpeed")]
        public float MoveSpeed { get; set; }

        [JsonPropertyName("physicalLethality")]
        public float PhysicalLethality { get; set; }

        [JsonPropertyName("resourceMax")]
        public float ResourceMax { get; set; }

        [JsonPropertyName("resourceRegenRate")]
        public float ResourceRegenRate { get; set; }

        [JsonPropertyName("resourceType")]
        public string ResourceType { get; set; }

        [JsonPropertyName("resourceValue")]
        public float ResourceValue { get; set; }

        [JsonPropertyName("spellVamp")]
        public float SpellVamp { get; set; }

        [JsonPropertyName("tenacity")]
        public float Tenacity { get; set; }
    }

    public partial class FullRunes
    {
        [JsonPropertyName("generalRunes")]
        public Keystone[] GeneralRunes { get; set; }

        [JsonPropertyName("keystone")]
        public Keystone Keystone { get; set; }

        [JsonPropertyName("primaryRuneTree")]
        public Keystone PrimaryRuneTree { get; set; }

        [JsonPropertyName("secondaryRuneTree")]
        public Keystone SecondaryRuneTree { get; set; }

        [JsonPropertyName("statRunes")]
        public StatRune[] StatRunes { get; set; }
    }

    public partial class Keystone
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("rawDescription")]
        public string RawDescription { get; set; }

        [JsonPropertyName("rawDisplayName")]
        public string RawDisplayName { get; set; }
    }

    public partial class StatRune
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("rawDescription")]
        public string RawDescription { get; set; }
    }

    public partial class AllPlayer
    {
        [JsonPropertyName("championName")]
        public string ChampionName { get; set; }

        [JsonPropertyName("isBot")]
        public bool IsBot { get; set; }

        [JsonPropertyName("isDead")]
        public bool IsDead { get; set; }

        [JsonPropertyName("items")]
        public Item[] Items { get; set; }

        [JsonPropertyName("level")]
        public long Level { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("rawChampionName")]
        public string RawChampionName { get; set; }

        [JsonPropertyName("respawnTimer")]
        public float RespawnTimer { get; set; }

        [JsonPropertyName("runes")]
        public Runes Runes { get; set; }

        [JsonPropertyName("scores")]
        public Scores Scores { get; set; }

        [JsonPropertyName("skinID")]
        public long SkinId { get; set; }

        [JsonPropertyName("summonerName")]
        public string SummonerName { get; set; }

        [JsonPropertyName("summonerSpells")]
        public SummonerSpells SummonerSpells { get; set; }

        [JsonPropertyName("team")]
        public string Team { get; set; }
    }

    public partial class Item
    {
        [JsonPropertyName("canUse")]
        public bool CanUse { get; set; }

        [JsonPropertyName("consumable")]
        public bool Consumable { get; set; }

        [JsonPropertyName("count")]
        public long Count { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("itemID")]
        public long ItemId { get; set; }

        [JsonPropertyName("price")]
        public long Price { get; set; }

        [JsonPropertyName("rawDescription")]
        public string RawDescription { get; set; }

        [JsonPropertyName("rawDisplayName")]
        public string RawDisplayName { get; set; }

        [JsonPropertyName("slot")]
        public long Slot { get; set; }
    }

    public partial class Runes
    {
        [JsonPropertyName("keystone")]
        public Keystone Keystone { get; set; }

        [JsonPropertyName("primaryRuneTree")]
        public Keystone PrimaryRuneTree { get; set; }

        [JsonPropertyName("secondaryRuneTree")]
        public Keystone SecondaryRuneTree { get; set; }
    }

    public partial class Scores
    {
        [JsonPropertyName("assists")]
        public long Assists { get; set; }

        [JsonPropertyName("creepScore")]
        public long CreepScore { get; set; }

        [JsonPropertyName("deaths")]
        public long Deaths { get; set; }

        [JsonPropertyName("kills")]
        public long Kills { get; set; }

        [JsonPropertyName("wardScore")]
        public float WardScore { get; set; }
    }

    public partial class SummonerSpells
    {
        [JsonPropertyName("summonerSpellOne")]
        public Ability SummonerSpellOne { get; set; }

        [JsonPropertyName("summonerSpellTwo")]
        public Ability SummonerSpellTwo { get; set; }
    }

    public partial class Events
    {
        [JsonPropertyName("Events")]
        public Event[] EventsEvents { get; set; }
    }

    public partial class Event
    {
        [JsonPropertyName("EventID")]
        public long EventId { get; set; }

        [JsonPropertyName("EventName")]
        public string EventName { get; set; }

        [JsonPropertyName("EventTime")]
        public float EventTime { get; set; }
    }

    public partial class GameData
    {
        [JsonPropertyName("gameMode")]
        public string GameMode { get; set; }

        [JsonPropertyName("gameTime")]
        public float GameTime { get; set; }

        [JsonPropertyName("mapName")]
        public string MapName { get; set; }

        [JsonPropertyName("mapNumber")]
        public long MapNumber { get; set; }

        [JsonPropertyName("mapTerrain")]
        public string MapTerrain { get; set; }
    }
}
