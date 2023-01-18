using System;
using UnityEngine;


public class Bullet : IResetable
{
    public Teams myteam;
    public int damage;
    public float waitResetTime;
    private float currentTime;
    private bool isMove;
    private GameObject parentGun;

    public void Fire(GameObject Gun)
    {
        isMove = true;
        parentGun = Gun;
    }
    private void Update()
    {
        if (isMove)
        {
            currentTime += Time.deltaTime;
            if (currentTime > waitResetTime)
            {
                ResetObject();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && myteam != other.GetComponent<Team>().myteam)
        {
            other.GetComponent<Health>().HitDamage(damage);
            ResetObject();
        }
    }

    public override void ResetObject()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        parentGun.GetComponent<GunManager>().bullets.Add(gameObject);
        gameObject.SetActive(false);
        currentTime = 0;
        isMove = false;
    }
}