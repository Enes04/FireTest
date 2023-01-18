using System;
using UnityEngine;

public class PlayerManager : Health
{
   public static PlayerManager instance;
   private void Awake()
   {
      instance = this;
      Initialize();
   }

   private void Initialize()
   {
   
   }

   public override void HitDamage(int damage)
   {
      while (damage > 0)
      {
         if (armor > 0)
         {
            armor--;
         }
         else
         {
            health--;
         }
         damage--;
      }
   }
}
