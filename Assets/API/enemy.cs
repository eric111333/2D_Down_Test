using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public int maxHealth = 20;
    int currentHealth;
    private Animator ani;
    public GameObject gold;//生錢
    public GameObject potion;
    public GameObject hitPrint;
    public float dropRate;
    public static int killer;

    
    void Start()
    {
        currentHealth = maxHealth;
        ani = GetComponent<Animator>();
        dropRate = Random.Range(0, 100);

    }
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Vector3 pos = new Vector3(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y, 0);
        GameObject points = Instantiate(hitPrint, transform.position, Quaternion.identity)as GameObject ;
        points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + damage;
        if (currentHealth<=0)
        {
            if(dropRate<=30)
            {
                Instantiate(potion, pos, Quaternion.identity);
            }
            GroundNum.bosskiller--;
            ani.SetTrigger("die");
            for (int i = 0; i < Random.Range(1,5); i++)
            {
            Instantiate(gold, pos, Quaternion.identity);
            }
            
            Die();
            return;
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "fireball")
        {
            //.SetTrigger("die");
            //Die();
            
            currentHealth -= attack.attackDamage*2;
            Vector3 pos = new Vector3(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y, 0);
            GameObject points = Instantiate(hitPrint, transform.position, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + attack.attackDamage * 2;
            if (currentHealth <= 0)
            {
                if (dropRate <= 30)
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
        Destroy(this.gameObject,0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
