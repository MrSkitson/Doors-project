using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class MouseClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler

{
    public static MouseClick Instance;
   public bool ChestIsOpen; 

  


private GameManager gameManager;

public void Start()
{
    
   gameManager = GetComponent<GameManager>();
    
}
//Place for add light effect when courser come to Chest BoxCollider
public void OnPointerEnter(PointerEventData pointerEvenetData)
{
    Debug.Log("Change light");

}

//Place for add normal light effect when courser exit to Chest BoxCollider
public void OnPointerExit(PointerEventData pointerEvenetData)
{
    Debug.Log("Light return to normal");
}

public void OnPointerDown(PointerEventData pointerEventData)
{
Debug.Log(" Game Object Clicked!");
ChestIsOpen = true;
// THis is a PROBLEM PLACE
GameManager.Instance.chestScreenRun();
}
//Check when was click to Chest Box Collider
public void OnPointerClick(PointerEventData pointerEventData)
    {

        //Output to console the clicked GameObject's  the following message. You can replace this with your own actions for when clicking the GameObject.
        //Debug.Log(" Game Object Clicked!");
        //ChestIsOpen = true;
       
//gameManager.GetComponent<GameManager>().chestScreenRun();
    }
   
}

