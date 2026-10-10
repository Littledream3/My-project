using UnityEngine;

public class SkillManger : MonoBehaviour
{
    public Player_Combat combat;


    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpent;
    }
    private void disable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpent;
    }
    private void HandleAbilityPointSpent(SkillSlot slot)
    {
        string skillName = slot.skillSO.skillName;
        switch (skillName)
        {
            case "Max Health Boost":
                StatsManager.Instance.UpdateMaxHealth(1);
                break;
            case "sword Slash":
                combat.enabled =true;
                break;
            default:
                Debug.LogWarning("Unknown skill:" + skillName);
                break;
        }
    }
}
