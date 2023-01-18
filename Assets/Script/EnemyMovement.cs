using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    private NavMeshAgent navMeshAgent;
    private EnemyGunManager enemyGunManager;
    private DetectCollider detectCollider;
    public Transform targetbullet;
    
    void Start()
    {
        detectCollider = GetComponent<DetectCollider>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyGunManager = GetComponent<EnemyGunManager>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (!detectCollider.dead)
        {
            if (enemyGunManager.bulletMagazine <= 0)
            {
                CheckBulletNear();
            }
            else
            {
                if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) 
                {
                    Vector3 point;
                    if (RandomPoint(Vector3.zero, detectCollider.distanceDetect, out point)) 
                    {
                        navMeshAgent.SetDestination(point);
                        animator.SetFloat("Speed", navMeshAgent.speed);
                        Quaternion rot =
                            Quaternion.LookRotation(-transform.position + point);
                        rot.x = 0;
                        rot.z = 0;
                        transform.GetChild(0).rotation = Quaternion.RotateTowards(transform.GetChild(0).rotation, rot, 20);
                    }
                }
            }
        }
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; 
        UnityEngine.AI.NavMeshHit hit;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas)) 
        { 
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
    public void CheckBulletNear()
    {
        float min = Vector3.Distance(transform.position,
            GameManager.instance.bulletCollect[0].transform.position);
        for (int i = 0; i < GameManager.instance.bulletCollect.Length; i++)
        {
            if (min > Vector3.Distance(transform.position,
                    GameManager.instance.bulletCollect[i].transform.position) && GameManager.instance.bulletCollect[i].GetComponent<Collider>().enabled)
            {
                min = Vector3.Distance(transform.position,
                    GameManager.instance.bulletCollect[i].transform.position);
                targetbullet = GameManager.instance.bulletCollect[i].transform;
            }
        }

        if (targetbullet != null)
        {
            navMeshAgent.SetDestination(targetbullet.position);
            animator.SetFloat("Speed", navMeshAgent.speed);
            Quaternion rot =
                Quaternion.LookRotation(-transform.position + targetbullet.transform.position);
            rot.x = 0;
            rot.z = 0;
            transform.GetChild(0).rotation = Quaternion.RotateTowards(transform.GetChild(0).rotation, rot, 20);
        }
    }
}