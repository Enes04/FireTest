using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class GameManager : MonoBehaviour
{
    public GameObject bulletPool;
    public GameObject[] bulletCollect;
    public static GameManager instance;
    public GunManager[] allCharacter;
    private void Awake()
    {
        instance = this;
        allCharacter = new GunManager[FindObjectsOfType<GunManager>().Length];
        allCharacter = FindObjectsOfType<GunManager>();
    }
}
