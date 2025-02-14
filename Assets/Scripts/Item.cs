using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum ItemInfo
{
    Potion,
    Speed
}
public class Item : MonoBehaviour
{
    ItemInfo itemInfo;
    void Start()
    {
        SetItem();
    }
    void SetItem()
    {
        itemInfo = (ItemInfo)Random.Range(0, (int)ItemInfo.Speed+1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AddBuff(other.GetComponent<Player>());
            CreateInventory inventory = FindObjectOfType<CreateInventory>();
            if(inventory != null)
            {
                Debug.Log("d");
                inventory.getItem();
            }
        }
    }

    void AddBuff (Player player)
    {
        switch (itemInfo)
        {
            case ItemInfo.Potion:
                {

                    player.ItemPotion();
                    Debug.Log("potion");
                    Destroy(this.gameObject);
                }
                break;
            case ItemInfo.Speed:
                {
                    player.ItemSpeed();
                    Debug.Log("speed");
                    Destroy(this.gameObject);
                }
                break;
        }
    }
}
