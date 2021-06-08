using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int collisionDamage = 10;
    public string collisionTag;

    private void OnCollisionEnter2d(Collision2D col)
    {
        if (col.gameObject.tag == collisionTag)
        {
            Health health = col.gameObject.GetComponent<Health>();
            health.TakeHit(collisionDamage);
        }
    }
}
