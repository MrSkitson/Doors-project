using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MouseClick
{
 protected override  void Touch()
 {
     GameManager.Instance.GameOver();
 }

    
}
