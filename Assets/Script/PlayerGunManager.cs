using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunManager : GunManager
{
    [HideInInspector]
    private float waitFire;
    private DetectCollider detectCollider;
    private void Start()
    {
        detectCollider = GetComponent<DetectCollider>();
        UiManager.instance.playerBulletMagazine.text = bulletMagazine.ToString();
        for (int i = 0; i < 45; i++)
        {
            GameObject tempBullet = Instantiate(bullet,GameManager.instance.bulletPool.transform);
            tempBullet.GetComponent<Bullet>().myteam = GetComponent<Team>().myteam;
            bullets.Add(tempBullet);
            tempBullet.SetActive(false);
        }
    }

    private void Update()
    {
        if (!detectCollider.lookAt)
        {
            waitFire += Time.deltaTime;
            if (waitFire > rateOfFire)
            {
                waitFire = 0;
                Fire(transform);
            }
        }
    }

    public override void Fire(Transform target)
    {
        if (bullets.Count > 0 && bulletMagazine>0)
        {
            bulletMagazine--;
            UiManager.instance.playerBulletMagazine.text = bulletMagazine.ToString();
            GameObject curBullet = bullets[0];
            muzzleFlash.Play();
            bullets.RemoveAt(0);
            curBullet.SetActive(true);
            curBullet.transform.position = muzzlePosition.position;
            curBullet.transform.rotation = transform.GetChild(0).rotation;
            curBullet.GetComponent<Rigidbody>().velocity = curBullet.transform.forward * 60;
            curBullet.GetComponent<Bullet>().Fire(gameObject);
        }
    }

    public override void BulletMagazineUpdate(int bulletCount)
    {
        bulletMagazine += bulletCount;
        UiManager.instance.playerBulletMagazine.text = GetComponent<GunManager>().bulletMagazine.ToString();
    }
}