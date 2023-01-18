using System;
using UnityEngine;

public class DetectCollider : MonoBehaviour
{
    private LayerMask layerMask;
    private GameObject nearEnemy;
    public float distanceDetect;
    public bool lookAt;
    public bool dead;
    private void Start()
    {
        layerMask = LayerMask.GetMask("Enemy");
    }

    private void Update()
    {
        if (!dead)
            DetectEnemy();
    }

    #region DetectEnemyAndLook

    public void DetectEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distanceDetect, layerMask);

        if (colliders.Length > 1)
        {
            float minDist = distanceDetect;

            for (int i = 0; i < colliders.Length; i++)
            {
                if (minDist > Vector3.Distance(transform.position, colliders[i].transform.position) &&
                    colliders[i].GetComponent<Team>().myteam != GetComponent<Team>().myteam && !colliders[i].GetComponent<DetectCollider>().dead)
                    nearEnemy = colliders[i].gameObject;
            }

            if (nearEnemy != null && nearEnemy.GetComponent<Team>().myteam != GetComponent<Team>().myteam && nearEnemy.GetComponent<Collider>().enabled)
                LookEnemy();
            else
            {
                lookAt = true;
            }
        }
        else
        {
            lookAt = true;
        }
    }

    public void LookEnemy()
    {
        lookAt = false;
        Quaternion rot =
            Quaternion.LookRotation(-transform.position + nearEnemy.transform.position);
        rot.x = 0;
        rot.z = 0;
        transform.GetChild(0).rotation = Quaternion.RotateTowards(transform.GetChild(0).rotation, rot, 20);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanceDetect);
    }

    #endregion

    #region CollectBullet

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collect"))
        {
            GetComponent<GunManager>().BulletMagazineUpdate(other.GetComponent<CollectArmy>().collectCount);
            other.GetComponent<CollectArmy>().CloseObj();
        }
    }

    #endregion
}