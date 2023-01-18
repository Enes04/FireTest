using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public abstract void HitDamage(int damage);
    public float armor;
    public float health;
}
