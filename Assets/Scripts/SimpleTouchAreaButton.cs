using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SimpleTouchAreaButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool touched;
    private int pointerID;
    private bool canFire;

    void awake()
    {
        touched = false;
    }
   
    public void OnPointerDown(PointerEventData data)
    {
 //       Debug.Log(data.pointerId);
        if (!touched)
        {
            touched = true;
            pointerID = data.pointerId;
            canFire = true;
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (data.pointerId == pointerID)
        {            
            touched = false;
            canFire = false;
        }
    }

    public bool CanFire()
    {
        return canFire;
    }
}
