using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MouseClick
{
    public Animator _animator;
    private bool _isOpen;


public void chestAnimation()
{

_animator = GetComponent<Animator>();
    _animator.SetBool("IsOpen", _isOpen);
    _isOpen = !_isOpen;

}

 protected override  void Touch()
 {
;
     GameManager.Instance.chestScreenRun();

     chestAnimation();
 }

    
}
