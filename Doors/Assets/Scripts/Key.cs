using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MouseClick
{
 protected override  void Touch()
 {
     GameManager.Instance.KeyClicked();
 }

    
}
