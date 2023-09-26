using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerAnimations : MonoBehaviour
{
   private Animator _animator;

   private void Awake()
   {
      _animator = GetComponent<Animator>();
   }

   public void Attack()
   {
      _animator.SetTrigger("Attack");
   }
   
   public void Idle()
   {
      _animator.SetTrigger("idle");
   }

   public void Mock()
   {
      _animator.SetTrigger("Mock");
   }


}
