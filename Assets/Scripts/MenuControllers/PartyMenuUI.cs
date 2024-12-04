using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PartyMenuUI : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterLevel;
    public GameObject hpBarObject;
    private RectTransform hpBar;
    public TextMeshProUGUI hpLabel;
    public GameObject expBarObject;
    private RectTransform expBar;
    public TextMeshProUGUI expLabel;
    public GameObject image;

    public void Initialize() {
        hpBar = hpBarObject.GetComponent<RectTransform>();
        expBar = expBarObject.GetComponent<RectTransform>();
    }

    public void SetFields(CharacterStats character) {
        SetName(character.characterName);
        SetLevel(character.level);
        SetHp(character.currentHp, character.hp);
        SetExp(character.currentExp, character.expToNextLevel);
        SetImage(character.image);
    }

    private void SetName(string characterName) {
        this.characterName.text = characterName;
    }

    private void SetLevel(int characterLevel) {
        this.characterLevel.text = $"{characterLevel}";
    }

    private void SetHp(float currentHp, float maxHp) {
        if (maxHp <= 0) return;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);

        float barPercent = currentHp/maxHp;
        this.hpBar.anchorMax = new Vector2(barPercent, hpBar.anchorMax.y);

        this.hpLabel.text = $"{Mathf.FloorToInt(currentHp)}/{Mathf.FloorToInt(maxHp)}";

    }

    private void SetExp(float currentExp, float maxExp) {
        if (maxExp <= 0) return;
        currentExp = Mathf.Clamp(currentExp, 0, maxExp);

        float barPercent = currentExp/maxExp;
        this.expBar.anchorMax = new Vector2(barPercent, expBar.anchorMax.y);
        
        this.expLabel.text = $"{Mathf.FloorToInt(currentExp)}/{Mathf.FloorToInt(maxExp)}";
    }

    private void SetImage(Texture2D image) {
        this.image.GetComponent<RawImage>().texture = image;
    }
}
