using UnityEngine;
using TMPro;

public class SkillTreeManager : MonoBehaviour
{
    public SkillSlot[] skillSlots;
    public TMP_Text pointsText;
    public int availablePoints;
    
    
    
    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointsSpent;
        SkillSlot.OnSkillMaxed += HandleSkillMaxed;
        ExpManager.OnLevelUp += UpdateAblilityPoints;
    }
    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointsSpent;
        SkillSlot.OnSkillMaxed -= HandleSkillMaxed;
        ExpManager.OnLevelUp -= UpdateAblilityPoints;
    }
    private void Start()
    {
        foreach (SkillSlot slot  in skillSlots)
        {
            slot.skillButton.onClick.AddListener(()=>CheckAvailablePoints(slot));
            
        }
        UpdateAblilityPoints(0);
    }
    private void CheckAvailablePoints(SkillSlot slot)
    {
        if (availablePoints != 0)
        {
            slot.TryUpgradeSkill();
        }
    }
    private void HandleAbilityPointsSpent(SkillSlot skillSlot)
    {
        if (availablePoints>0)
        {
            UpdateAblilityPoints(-1);

        }
        {
            
        }
    }

    private void HandleSkillMaxed(SkillSlot skillSlot)
    {
        foreach(SkillSlot slot in skillSlots)
        {
            if (!slot.isUnlocked && slot.CanUnlockSkill())

            slot.Unlock();
        }
    }
    public void UpdateAblilityPoints(int amount)
    {
        availablePoints += amount;
        pointsText.text = "Points:" + availablePoints;
    }
}
