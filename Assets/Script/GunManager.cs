using System.Collections.Generic;
using UnityEngine;


public abstract class GunManager : MonoBehaviour
{
    public abstract void Fire(Transform target);
    
    public abstract void BulletMagazineUpdate(int bulletCount);
    public ParticleSystem muzzleFlash;
    public Transform muzzlePosition;
    
    public GameObject bullet;
    public float rateOfFire;
    [HideInInspector]
    public int bulletMagazine;
    [HideInInspector]
    public List<GameObject> bullets;
}
