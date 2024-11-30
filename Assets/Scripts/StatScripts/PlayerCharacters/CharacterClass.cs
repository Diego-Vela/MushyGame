using UnityEngine;

#region Global Methods
public static class CharacterClass {
    // Shared method to apply multipliers to a character's stats
    public static void ApplyMultipliers(CharacterStats character, float hpMultiplier, float attackMultiplier, float dexterityMultiplier, float intelligenceMultiplier, float speedMultiplier, float expMultiplier, string className) {
        character.characterClass = className;
        character.hp *= hpMultiplier;
        character.attack *= attackMultiplier;
        character.dexterity *= dexterityMultiplier;
        character.intelligence *= intelligenceMultiplier;
        character.speed *= speedMultiplier;
        character.expMultiplier = expMultiplier;

        //Debug.Log($"{className} multipliers applied to {character.characterName}");
    }
}
#endregion

#region Character Classes
public static class Villager
{
    public static string ClassName => "Villager";
    public static float HpMultiplier => 1f;
    public static float AttackMultiplier => 1f;
    public static float DexterityMultiplier => 1f;
    public static float IntelligenceMultiplier => 1f;
    public static float SpeedMultiplier => 1f;
    public static float ExpMultiplier => 1.25f;

    public static void ApplyMultipliers(CharacterStats character)
    {
        CharacterClass.ApplyMultipliers(character, HpMultiplier, AttackMultiplier, DexterityMultiplier, IntelligenceMultiplier, SpeedMultiplier, ExpMultiplier, ClassName);
    }
}

public static class Warrior
{
    public static string ClassName => "Warrior";
    public static float HpMultiplier => 1.5f;
    public static float AttackMultiplier => 2f;
    public static float DexterityMultiplier => 1f;
    public static float IntelligenceMultiplier => 0.5f;
    public static float SpeedMultiplier => 0.7f;
    public static float ExpMultiplier => 1f;

    public static void ApplyMultipliers(CharacterStats character)
    {
        CharacterClass.ApplyMultipliers(character, HpMultiplier, AttackMultiplier, DexterityMultiplier, IntelligenceMultiplier, SpeedMultiplier, ExpMultiplier, ClassName);
    }
}
#endregion
