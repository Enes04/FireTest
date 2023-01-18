using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : Health
{
    public static EnemyManager instance;
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
            else if(health>0)
            {
                health--;
            }
            else
            {
                Death();
            }
            damage--;
        }
    }

    public void Death()
    {
        GetComponent<EnemyMovement>().animator.SetTrigger("Death");
        GetComponent<DetectCollider>().dead = true;
        GetComponent<Collider>().enabled = false;
    }
}
