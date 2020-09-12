using UnityEngine;
using System.Collections;
public class attack : MonoBehaviour
{
    
    private Animator aniPlayer;
    private SpriteRenderer sprPlayer;
    public Transform attackpoint;
    private AudioSource aud;
    private float attackTime;
    public static float attackSpeed=1.5f;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public static int attackDamage;
    public AudioClip soundAttack;
    // Use this for initialization
    void Start()
    {
        aud = GetComponent<AudioSource>();
        sprPlayer = GetComponent<SpriteRenderer>();
        aniPlayer = GetComponent<Animator>();
        //attackSpeed = 1;
        
        attackSpeed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        attackTime += Time.deltaTime;
        //if (Input.GetKeyDown(KeyCode.F)|| Input.GetKeyDown(KeyCode.J))
        if(attackTime>= attackSpeed)
        {
            Attack();
            attackTime = 0;
        }
        //attackpoint.position = sprPlayer.transform.position + sprPlayer.transform.up * 0.12f;

    }

    private void Attack()
    {
        aniPlayer.SetTrigger("attack");
        aud.PlayOneShot(soundAttack); 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);



        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemy>().TakeDamage(attackDamage);
        }

    }
    private void OnDrawGizmosSelected()
    {
        //if (sprPlayer.flipX) attackpoint.position = new Vector3(0.12f, 0, 0);
        //if (sprPlayer.flipX == false) attackpoint.position = new Vector3(-0.12f, 0, 0);

        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}