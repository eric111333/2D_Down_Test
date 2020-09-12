using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator aniPlayer;
    //private SpriteRenderer sprPlayer;
    Rigidbody2D playerRigidbody2D;
    private AudioSource aud;
    //[Header("目前的水平速度")]
    //public float speedX;
    public GameObject hitPrint;
    public Joystick joy;


    [Header("水平推力")]
    [Range(0, 150)]
    public float speed;
    //[Header("最大水平速度")]
    //public float maxSpeedX;
    [Header("垂直向上推力")]
    public float yForce;

    [Header("偵測地板的射線起點")]
    public Transform groundCheck;
    [Header("地面圖層")]
    public LayerMask groundLayer;
    public bool grounded, isjump;
    bool jumpPressed;
    int jumpCount;


    public bool dead;
    [Header("血量"), Range(0, 10000)]
    public static float hp;
    public static float hpMax;
    private Image hpBar;
    [Header("血顯示數字")]
    public Text textHp;
    public Text textHpmax;
    public static float mp = 10;
    public static float mpMax = 10;
    private Image mpBar;
    private float mpTime;
    private float mpCd=5;

    public static int goldNum;
    public Text goldtext;
    [Header("結束畫面")]
    public GameObject final;
    public AudioClip soundHit;
    public AudioClip soundJump;

    public static bool front;


    


    /*public void ControlSpeed()
    {
        speedX = playerRigidbody2D.velocity.x;
        speedY = playerRigidbody2D.velocity.y;
        float newSpeedX = Mathf.Clamp(speedX, -maxSpeedX, maxSpeedX);
        playerRigidbody2D.velocity = new Vector2(newSpeedX, speedY);


    }

    public bool JumpKey
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        }
    }

    void TryJump()
    {
        if (IsGround && JumpKey)
        {
            playerRigidbody2D.AddForce(Vector2.up * yForce);
            aniPlayer.SetBool("jumping", true);
        }
    }

    //在玩家的底部射一條很短的射線 如果射線有打到地板圖層的話 代表正在踩著地板
    bool IsGround
    {
        get
        {
            Vector2 start = groundCheck.position;
            Vector2 end = new Vector2(start.x, start.y - distance);

            Debug.DrawLine(start, end, Color.blue);
            grounded = Physics2D.Linecast(start, end, groundLayer);
            aniPlayer.SetBool("jumping", false);
            return grounded;
        }
    }
    */
    void Start()
    {
        hpMax = PlayerPrefs.GetFloat("playerhpMax");
        hp = hpMax;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        //sprPlayer = GetComponent<SpriteRenderer>();
        aniPlayer = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        hpBar = GameObject.Find("血條").GetComponent<Image>();
        mpBar = GameObject.Find("魔力條").GetComponent<Image>();
       // hp = hpMax;
        
        
        //goldNum = 1000;

    }

    /// <summary>水平移動</summary>
   /* void MovementX()
    {
        horizontalDirection = Input.GetAxis(HORIZONTAL);
        playerRigidbody2D.AddForce(new Vector2(xForce * horizontalDirection, 0));
        aniPlayer.SetFloat("speed", Mathf.Abs(horizontalDirection));

        if (Input.GetKeyDown(KeyCode.A))
        {
            sprPlayer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            sprPlayer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sprPlayer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            sprPlayer.flipX = false;
        }
    }*/

    void Update()
    {
        if (dead) return;
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }
        hpBar.fillAmount = hp / hpMax;
        goldtext.text = "" + goldNum;
        mpBar.fillAmount = mp / mpMax;

        if (mp < mpMax)
        {

            mpTime += Time.deltaTime;
            if (mpTime >= mpCd) { mp++; mpTime = 0; }        
        }

        //MovementX();
        //ControlSpeed();
        //TryJump();
        //speedX = playerRigidbody2D.velocity.x;
    }
    private void FixedUpdate()
    {
        if (dead) return;
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.05f, groundLayer);
        textHp.text = "" + hp;
        textHpmax.text = "/    " + hpMax;
        GroundMove();
        Jump();
        SwitchAnim();
    }

    void GroundMove()
    {
        float horizontalMove = joy.Horizontal;//Input.GetAxisRaw("Horizontal");
        playerRigidbody2D.velocity =
           new Vector2(horizontalMove * speed, playerRigidbody2D.velocity.y);
        if (horizontalMove >= 0.01f)
        {
            transform.localScale = new Vector3(1 * 0.12f, 0.12f, 0.12f);
        }
        if (horizontalMove <= -0.01f)
        {
            transform.localScale = new Vector3(-1 * 0.12f, 0.12f, 0.12f);
        }
        if (horizontalMove > 0) front = true;
        if (horizontalMove < 0) front = false;
    }
    void Jump()
    {
        if (grounded)
        {
            jumpCount = 2;
            isjump = false;
        }
        if (joy.Vertical>0.3f && grounded)
        {
            isjump = true;
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, yForce);
            jumpCount--;
            aud.PlayOneShot(soundJump, 05f);
            jumpPressed = false;
        }
        else if (joy.Vertical > 0.9f && jumpCount > 0 && isjump)
        {
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, yForce);
            jumpCount--;
            aud.PlayOneShot(soundJump, 05f);
            jumpPressed = false;
        }
    }
    void SwitchAnim()
    {
        aniPlayer.SetFloat("speed", Mathf.Abs(playerRigidbody2D.velocity.x));
        if (grounded)
        {
            // aniPlayer.SetBool("fall", false);
        }
        else if (!grounded && playerRigidbody2D.velocity.y > 0)
        {
            aniPlayer.SetBool("jumping", true);
        }
        else if (playerRigidbody2D.velocity.y < 0)
        {
            aniPlayer.SetBool("jumping", false);
            //aniPlayer.SetBool("fall", true);
        }
    }

    void DamageText(int ten)
    {
        Vector3 pos = new Vector3(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y, 0);
        GameObject points = Instantiate(hitPrint, transform.position, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + ten;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dead) return;

        if (collision.tag == "陷阱")
        {
            hp -= 10;
            aud.PlayOneShot(soundHit);
            hpBar.fillAmount = hp / hpMax;
            aniPlayer.SetTrigger("hurt");
            DamageText(10);
            if (hp <= 0) Dead();
        }
        if (collision.tag == "iceball")
        {
            hp -= 30;
            aud.PlayOneShot(soundHit);
            hpBar.fillAmount = hp / hpMax;
            aniPlayer.SetTrigger("hurt");
            DamageText(30);
            if (hp <= 0) Dead();
        }
        if (collision.tag == "Gold")
        {
            goldNum++;

        }
        if (collision.tag == "potion")
        {
            Potion.potionNum++;
        }
        if (collision.tag == "敵人")
        {
            hp -= 10;
            aud.PlayOneShot(soundHit);
            hpBar.fillAmount = hp / hpMax;
            aniPlayer.SetTrigger("hurt");
            DamageText(10);
            if (hp <= 0) Dead();
        }
        if (collision.tag == "洞")
        {
            hp -= 100;
            hpBar.fillAmount = hp / hpMax;
            aniPlayer.SetTrigger("hurt");
            DamageText(100);
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x,yForce*3);
            if (hp <= 0) Dead();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fan"))
        {
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, yForce - 1f);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    public void Dead()
    {
        aniPlayer.SetTrigger("die");
        final.SetActive(true);
        //gm.GameOver();
        dead = true;
        

    }
}
