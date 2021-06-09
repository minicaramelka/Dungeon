using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHeal : MonoBehaviour
{
    public int collisionHeal = 10;
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == collisionTag)
        {
            PlayerHealth health = col.gameObject.GetComponent<PlayerHealth>();
            health.SetHealth(collisionHeal);
            Destroy(gameObject);
        }
    }
}
