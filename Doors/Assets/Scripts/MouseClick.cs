using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class MouseClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler

{


protected virtual void Touch()
{

}

public void Start()
{
    
}



//Place for add light effect when courser come to Chest BoxCollider
public void OnPointerEnter(PointerEventData pointerEvenetData)
{
    Debug.Log("Change light");
//     Material mat = Text.materialForRendering;
// Debug.Log(mat.GetFloat("_GlowPower"));

}

//Place for add normal light effect when courser exit to Chest BoxCollider
public void OnPointerExit(PointerEventData pointerEvenetData)
{
    Debug.Log("Light return to normal");
}

public void OnPointerDown(PointerEventData pointerEventData)
{
Debug.Log(" Game Object Clicked!");
Touch();

}

}

