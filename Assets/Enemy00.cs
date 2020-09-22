using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy00 : enemy
{

    public static int Hp = 500;
    public static int HpMax = 500;
    private Animator ani;
    public static int bossDieNum = 0;
    public static bool bossDie;
    private Image hpBar;
    //public Vector3 target;
    void Start()
    {
        Hp = 500 + 100 * bossDieNum;
        HpMax = 500 + 100 * bossDieNum;
        ani = GetComponent<Animator>();
        dropRate = Random.Range(0, 100);
        bossDie = false;
        Hp = HpMax;
        hpBar = GameObject.Find("BOSS血").GetComponent<Image>();
    }
    public override void TakeDamage(int damage)
    {
        Hp -= damage;
        Vector3 pos = new Vector3(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y, 0);
        ani.SetTrigger("hit");
        GameObject points = Instantiate(hitPrint, transform.position, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + damage;
        hpBar.fillAmount = Hp / maxHealth;
        if (Hp <= 0)
        {
            if (dropRate <= 10)
            {
                Instantiate(potion, pos, Quaternion.identity);
            }
            GroundNum.bosskiller--;
            ani.SetTrigger("die");
            for (int i = 0; i < Random.Range(10, 50); i++)
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
            Hp -= attack.attackDamage * 2;
            Vector3 pos = new Vector3(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y, 0);
            GameObject points = Instantiate(hitPrint, transform.position, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + attack.attackDamage * 2;
            hpBar.fillAmount = Hp / maxHealth;
            if (Hp <= 0)
            {
                if (dropRate <= 10)
                {
                    Instantiate(potion, pos, Quaternion.identity);
                }
                GroundNum.bosskiller--;
                ani.SetTrigger("die");
                for (int i = 0; i < Random.Range(10, 50); i++)
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
        bossDie = true;
        Destroy(this.gameObject, 0.5f);
        //HpMax += bossDieNum * 10;
        Debug.Log("999");
        //GroundNum.bosskiller += 20 + bossDieNum;
        //GroundNum.bossNum++;
        Invoke("Bossdie", 1);

    }
    void Update()
    {
        //hpBar.fillAmount = Hp / HpMax;
        //Move();
    }
    void Bossdie()
    {
        bossDie = false;
    }
    
}
