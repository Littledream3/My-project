using UnityEngine;

public class Loot : MonoBehaviour
{
    public ItemSO itemSO;
    public SpriteRenderer sr;
    public Animator anim;

    public int quamtity;

    public void OnValidate()
    {
        if (itemSO == null) 
        {
            return;
        }
        sr.sprite=itemSO.icon;
        this.name = itemSO.itemName;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.Play("LootPickup");
            Destroy(gameObject, .5f);
        }
    }
}
