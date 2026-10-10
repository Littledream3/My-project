using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statsSlot;
    public CanvasGroup statsCanvas;

    private bool statsOpen = false;
    
    private void Start()
    {
        UpdateAllStats();
    }
    private void Update()
    {
        if(Input.GetButtonDown("ToggleStats"))
            if (statsOpen)
            {
                statsCanvas.alpha = 0f;
                UpdateAllStats();
                statsOpen = false;
                Time.timeScale = 1f;
            }

            else
            {
                statsCanvas.alpha = 1f;
                UpdateAllStats();
                statsOpen = true;
                Time.timeScale = 0f;
            }

    }
    public void UpdateDamage()
    {
        statsSlot[0].GetComponentInChildren<TMP_Text>().text = "Damage:" + StatsManager.Instance.damage;

    }
    public void UpdateSpeed()
    {
        statsSlot[1].GetComponentInChildren<TMP_Text>().text = "Speed:" + StatsManager.Instance.speed;

    }
    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateSpeed();
    }

}
