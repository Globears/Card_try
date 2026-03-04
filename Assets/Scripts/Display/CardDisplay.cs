using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 操控卡牌的Object的脚本
/// </summary>
public class CardDisplay : MonoBehaviour
{
    public Card Card;
    public TextMeshPro text;

    public Vector3 offset;
    public SlotDisplay currentSlot;
    public List<SlotDisplay> hoverSlots;
    private Vector3 originalScale = new Vector3(1f, 1f, 1f);
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale.Set(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        CardInfo info = CardsInfo.GetCardInfo(Card.Id);
        text.text = info.action_name + "\n" + info.action_description + "\n" + info.bonus_action_name + "\n" + info.bonus_action_description;
    }

    // Update is called once per frame
    void Update()
    {
        if(Graveyard.Instance.Contains(Card))
        {
            Destroy(gameObject);
        }
    }

    void OnMouseEnter()
    {
        //transform.localScale = originalScale * 1.2f;
    }

    void OnMouseExit()
    {
        //transform.localScale = originalScale;
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPos();
        HandLayoutManager.Instance.Remove(this);
        if(currentSlot != null)
        {
            currentSlot.Release(this);
            currentSlot = null;
        }
        
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    void OnMouseUp()
    {
        
        if(hoverSlots.Count == 0)
        {
            HandLayoutManager.Instance.Hold(this);
        }
        else
        {
            //比较哪个最近，选择最近的那个嵌入
            SlotDisplay closestSlot = null;
            float closestDistance = float.MaxValue;
            foreach (SlotDisplay slot in hoverSlots)
            {
                float distance = Vector3.Distance(transform.position, slot.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestSlot = slot;
                }
            }
            currentSlot = closestSlot;
            closestSlot.Add(this);

            closestSlot.slot.Hold(this.Card);
            Hand.Instance.Remove(this.Card);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        SlotDisplay hover = collision.GetComponent<SlotDisplay>();
        if(hover != null)
        {
            hoverSlots.Add(hover);
        }
        Debug.Log("entering slot");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        SlotDisplay hover = collision.GetComponent<SlotDisplay>();
        if(hover != null && hoverSlots.Contains(hover))
        {
            hoverSlots.Remove(hover);
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 0;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void setPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void setPosition(Vector2 position)
    {
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }

    public void Bind(Card card)
    {
        this.Card = card;
    }
}
