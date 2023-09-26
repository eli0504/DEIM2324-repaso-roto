using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      // Si el Player colisiona con moneda, CoinsManager actualiza el contador y la moneda desaparece
      if (other.gameObject.CompareTag("Player"))
      {
         CoinsManager.sharedInstance.UpdateCoins(); 
         Destroy(gameObject);
      }
   }
}
