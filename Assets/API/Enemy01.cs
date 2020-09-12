using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Enemy01 : enemy
{
    [Header("移動速度"), Range(0, 100)]
    public float speed;
    private SpriteRenderer sprPlayer;
    private Animator ani;
    public int E01Health;
    private void Move()
    {
        float y = Mathf.Sin(Time.time) * Random.Range(-15, 15) * Time.deltaTime;
        transform.Translate(0, y, 0);
        if (sprPlayer.flipX == false)
            transform.Translate(speed * 1 * Time.deltaTime, 0, 0);
        if (gameObject.transform.position.x >= 4)
            sprPlayer.flipX = true;
        if (sprPlayer.flipX == true)
            transform.Translate(speed * -1 * Time.deltaTime, 0, 0);
        if (gameObject.transform.position.x <= -4)
            sprPlayer.flipX = false;


    }
    private void attackent()
    {
        if (gameObject.transform.position.x >= 3)//|| gameObject.transform.position.x <= -3
            ani.SetTrigger("attack");
    }

    public override void TakeDamage(int damage)
    {
        E01Health -= damage;
        Vector3 pos = new Vector3(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y, 0);
        ani.SetTrigger("hit");
        GameObject points = Instantiate(hitPrint, transform.position, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + damage;
        if (E01Health <= 0)
        {
            if (dropRate <= 10)
            {
                Instantiate(potion, pos, Quaternion.identity);
            }
            GroundNum.bosskiller--;
            ani.SetTrigger("die");
            for (int i = 0; i < Random.Range(1, 5); i++)
            {
                Instantiate(gold, pos, Quaternion.identity);
            }
            Die();
        }
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fireball")
        {
            Debug.Log("123");
            E01Health -= attack.attackDamage * 2;
            Vector3 pos = new Vector3(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y, 0);
            GameObject points = Instantiate(hitPrint, transform.position, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + attack.attackDamage * 2;
            if (E01Health <= 0)
            {
                if (dropRate <= 10)
                {
                    Instantiate(potion, pos, Quaternion.identity);
                }
                GroundNum.bosskiller--;
                ani.SetTrigger("die");
                for (int i = 0; i < Random.Range(1, 5); i++)
                {
                    Instantiate(gold, pos, Quaternion.identity);
                }
                Die();
                return;
            }
        }

    }



    void Die()
    {
        Destroy(this.gameObject, 0.5f);
    }
    void Start()
    {
        sprPlayer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        Destroy(gameObject, 10);
        E01Health = 10;
        dropRate = Random.Range(0, 100);
    }

    void Update()
    {
        Move();
        attackent();
    }
}
