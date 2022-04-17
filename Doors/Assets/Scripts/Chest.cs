using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MouseClick
{
 protected override  void Touch()
 {
     GameManager.Instance.chestScreenRun();
 }

    
}
