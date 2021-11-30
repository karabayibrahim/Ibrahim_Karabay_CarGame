using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButRight : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.CurrentLevel.Player.MoveRightBool(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.Instance.CurrentLevel.Player.MoveRightBool(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
