using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MouseClick : MonoBehaviour, IPointerClickHandler

{
   private bool ChestIsOpen; 

private GameManager gameManager;

public void Start()
{
    gameManager = GetComponent<GameManager>();
    
}

public void OnPointerClick(PointerEventData pointerEventData)
    {

        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log( " Game Object Clicked!");

    }

   public void OnMouseDown()
   {
       Debug.Log("This");
     gameManager.chestScreenRun();
       
       
   } 
}
public class Chest
{

}