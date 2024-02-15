using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private int hp;
   [SerializeField] private int damage;
   [SerializeField] private Animator animator;

   private void Update()
   {
      if (hp<=0)
      {
         Destroy(gameObject);
      }
   } 
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Weapon"))
      {
         if (animator!=null)
         {
            animator.Play("Enemy");
         }
      }
      hp -= damage; 
    }
}
