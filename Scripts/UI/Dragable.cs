using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class Dragable : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IDragHandler
{
    private Vector3 originPosition;
    private Vector2 originMousePosition;

    private RectTransform rectTransform;

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }
    // Use this for initialization
    void Start () {

        this.rectTransform = this.transform.parent.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out originMousePosition);
        Debug.LogError("Origin:" + originMousePosition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mouseLocalPosition;
        if (rectTransform&&eventData.pointerEnter&&eventData.pointerEnter.gameObject.tag=="Dragable")
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out mouseLocalPosition))
            {
                Vector3 dir = (mouseLocalPosition - originMousePosition);
                Debug.Log("Dir:" + dir);
                Debug.Log("Position:" + eventData.pointerEnter.transform.localPosition);
                eventData.pointerEnter.transform.localPosition += dir;
                Debug.Log("After Position:" + eventData.pointerEnter.transform.localPosition);
                Debug.Log(eventData.pointerEnter.transform.localPosition);
            }
            originMousePosition = mouseLocalPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        originMousePosition = Vector2.zero;
    }
}
