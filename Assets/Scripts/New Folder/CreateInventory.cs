using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateInventory : MonoBehaviour
{
    //슬롯 개수
    public int slotCntWidth = 4;
    public int slotCntHeight = 4;
    //슬롯 사이즈
    public int slotWidthSize = 64;
    public int slotHeightSize = 64;
    //슬롯 프리팹
    public GameObject prefabSlot;
    public RectTransform parentObj;
    public Sprite backSprite;
    public int SlotTopBarSize = 20;
    GameObject inventory;
    public List<GameObject> slots = new List<GameObject>();
    public GameObject prefabItem;

    void Start()
    {
        SetInventory();

        //List<Item> item = new List<Item>();
        //Item i = new Item();
        //item.Add(i);

        //SetItem(item);
    }

    public void getItem()
    {
        List<Item> item = new List<Item>();
        Item i = new Item();
        item.Add(i);

        SetItem(item);
    }
    void SetInventory()
    {
        inventory = new GameObject();
        Image image = inventory.AddComponent<Image>();
        if(backSprite != null)
        {
            image.sprite = backSprite;
        }
        RectTransform inventoryRT = inventory.GetComponent<RectTransform>();
        inventoryRT.SetParent(parentObj);
        inventoryRT.anchoredPosition = Vector3.zero;
        inventoryRT.sizeDelta = new Vector2(slotWidthSize * slotCntWidth, slotHeightSize * slotCntHeight + SlotTopBarSize);
        inventoryRT.name = "Inventory";

        //인벤토리 움직일 헤더 생성
        GameObject backTop = new GameObject();
        Image backTopimg = backTop.AddComponent<Image>();
        backTopimg.color = Color.blue;
        RectTransform backTopRT = backTop.GetComponent<RectTransform>();
        backTopRT.SetParent(inventoryRT);
        backTopRT.pivot = Vector2.up;
        backTopRT.anchorMin = Vector2.up;
        backTopRT.anchorMax = Vector2.up;
        backTopRT.anchoredPosition = Vector3.zero;
        backTopRT.sizeDelta = new Vector2(slotWidthSize * slotCntWidth, SlotTopBarSize);
        backTop.AddComponent<DragObject>();

        for (int i = 0; i < slotCntHeight; i++)
        {
            for(int j = 0; j < slotCntWidth; j++)
            {
                GameObject slot = Instantiate(prefabSlot);
                RectTransform slotRT = slot.GetComponent<RectTransform>();
                slotRT.SetParent(inventoryRT);
                slotRT.pivot = Vector2.up;
                slotRT.anchorMin = Vector2.up;
                slotRT.anchorMax = Vector2.up;
                slotRT.anchoredPosition = Vector3.zero;
                slotRT.anchoredPosition += new Vector2(slotWidthSize * i, -(slotHeightSize * j) - SlotTopBarSize);
                slotRT.sizeDelta = new Vector2(slotWidthSize, slotHeightSize);
                slotRT.name = i + "," + j;
                slots.Add(slot);
            }
        }
    }

    public void SetItem(List<Item> item)
    {
        for(int i=0; i<item.Count; i++)
        {
            GameObject it = Instantiate(prefabItem);
            RectTransform itRT = it.GetComponent<RectTransform>();
            itRT.SetParent(slots[i]. GetComponent<RectTransform>());
            itRT.pivot = new Vector2(0.5f, 0.5f);
            itRT.anchorMin = Vector2.zero;
            itRT.anchorMax = Vector2.one;
            itRT.offsetMin = new Vector2(10, 10);
            //offsetMax의 경우 반대
            itRT.offsetMax = new Vector2(-10, -10);
            it.AddComponent<DragObject>().parentTr = it.transform;
        }
    }
}
