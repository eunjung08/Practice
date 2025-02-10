using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(this.transform.GetChild(0).childCount == 0)
        {
            eventData.pointerDrag.transform.SetParent(this.transform.transform);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
    }
}
