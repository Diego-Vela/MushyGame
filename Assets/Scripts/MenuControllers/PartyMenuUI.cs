using UnityEngine;
using TMPro;

public class PartyMenuUI : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterLevel;
    public GameObject hpBar;
    public GameObject maxHpBar;
    public TextMeshProGUI hpLabel;
    public GameObject expBar;
    public GameObject maxExpBar;
    public TextMeshProGUI expLabel;

    public setFields(CharacterStats character) {
        setName(character.characterName);
        setLevel(character.level);
        setHp(character.currentHp, character.maxHp);
        setExp(character.currentExp, character.maxExp);
    }

    private setName(string characterName) {
        this.characterName.text = characterName;
    }

    private setLevel(int characterLevel) {
        this.characterLevel.text = characterLevel;
    }

    private setHp(int currentHp, int maxHp) {
        float barPercent = currentHp/maxHp;
        this.hpBar.Anchors.Max.X  = 1-(maxHpBar.Width * barPercent);
        this.hpBar.Right = 0;

        this.hpLabel.text = $"{currentHp}/{maxHp}";
    }

    private setExp(int currentExp, int maxExp) {
        float barPercent = currentExp/maxExp;
        this.expBar.Anchors.Max.X =  2-(maxExpBar.Width * barPercent);

        
    }
}
