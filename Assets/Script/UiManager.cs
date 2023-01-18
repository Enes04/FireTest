using System;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
   public TextMeshProUGUI playerBulletMagazine;

   public static UiManager instance;

   private void Awake()
   {
      instance = this;
   }
}
