using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ExpManager : MonoBehaviour
{
    public int level;
    public int currenyExp;
    public int expToLevel=10;
    public Slider expSlider;
    public TMP_Text currentLevelText;

    public float expGrowthMultipliter = 1.2f;

    public static event Action<int> OnLevelUp;
    public void Start()
    {
        UpdateUI();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GainExperience(2);
        }

    }
    public void OnEnable()
    {
        Enemy_Health.OnMonsterDefeated += GainExperience;
    }
    public void OnDisable()
    {
        Enemy_Health.OnMonsterDefeated -= GainExperience;
    }

    public void GainExperience(int amount)
    {
        currenyExp += amount;
        if (currenyExp >= expToLevel)
            LevelUP();
        UpdateUI();
    }
    public void LevelUP()
    {
        level++;
        currenyExp -= expToLevel;
        expToLevel=Mathf.RoundToInt(expToLevel*expGrowthMultipliter);
        OnLevelUp?.Invoke(1);

    }
    public void UpdateUI()
    {
        expSlider.maxValue = expToLevel;
        expSlider.value = currenyExp;
        currentLevelText.text = "Level:"+level;
    }
}
