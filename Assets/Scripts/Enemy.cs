using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private int hp;
   [SerializeField] private int damage;
   [SerializeField] private Animator animator;
   [SerializeField] private Collider col;

   private void Update()
   {
      if (hp<=0)
      {
         animator.Play("die");
         col.enabled = false;
      }
   } 
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Weapon"))
      {
         hp -= damage;
         animator.Play("hit");
      }
   }
}
