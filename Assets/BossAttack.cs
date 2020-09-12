using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform player;
    Animator ani;
    public GameObject iceball;
    public float speed;
    public float moveSpeed;
    public float bossRange;
    public float bossatttime;
    public bool front;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void BossSkill()
    {
        float x = transform.position.x + 1.5f;
        float x1 = transform.position.x - 1.5f;
        float y = transform.position.y;
        Vector3 pos = new Vector3(x, y, 0);
        Vector3 pos1 = new Vector3(x1, y, 0);
        if (front==true) Instantiate(iceball, pos, Quaternion.identity);
        if(front==false) Instantiate(iceball, pos1, Quaternion.identity);
        
        bossatttime = 0;
    }

    void Update()
    {
        
        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if(distToPlayer<bossRange)
        {
            chasePlayer();
        }
        if(distToPlayer<2f)
        {
            stopPlayer();
        }
        if (distToPlayer < 3f && bossatttime>=2)
        {
            ani.SetTrigger("attack");
            BossSkill();
        }
        


        bossatttime += Time.deltaTime;

    }
    void chasePlayer()
    {
        if(transform.position.x  < player.transform.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector3(1, 1, 1);
            front = true;
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector3(-1,1, 1);
            front = false;
        }
    }
    void stopPlayer()
    {
        rb.velocity = new Vector2(0, 0);
    }
    /*private void FixedUpdate()
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2.MoveTowards(rb.position, target, speed);
    }*/

}
