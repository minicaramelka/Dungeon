using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private BoxCollider2D boxCollider;
    public float speed;
    public float positionOfPatrol;
    public Transform point;
    public bool moveingRight = true;
    public Transform player;
    public float stoppingDistance;
    public bool chill = false;
    public bool angry = false;
    public bool goBack = false;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol)
        {
            chill = true;
            angry = false;
            goBack = false;
        }

        if(Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }

        if(chill == true)
        {
            Chill();      
        }

        if (angry == true)
        {
            Angry();
        }

        if(goBack == true && chill != true)
        {
            GoBack();
        }
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Chill()
    {
        if(transform.position.x > point.position.x + positionOfPatrol)
        {
            moveingRight = false;
        }

        else if(transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight = true;
        }

        if(moveingRight)
        {
            speed = 0.8f;
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }

        else
        {
            speed = 0.8f;
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    public void Angry()
    {
        speed = 1.1f;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void GoBack()
    {
        speed = 0.8f;
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}
