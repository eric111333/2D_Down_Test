using UnityEngine;

public class gold : MonoBehaviour
{
    public Vector3 target;
    public static float count;
    private float speed = 30;
    private bool movebool;
    Rigidbody2D rb;
    //public GameObject player;

    void Start()
    {
        count = Random.Range(1,5);
        movebool = false;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 20);
        //firstSpeed = Vector3.Distance(transform.position, target) * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Player")
        {
            Destroy(gameObject, 0.5f);
            movebool = true;
        }

    }
    void Update()
    {
        if (movebool)
        {
            Find();
            Move();
        }
    }
    /*
    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed);
    }
    */
    void Find()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position-transform.up*0.5f;
    }
    void Move()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position - transform.up * 0.5f;
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        /*Debug.DrawLine(target, transform.position, Color.red);
        float eul = target.z - transform.position.z;
        transform.rotation = Quaternion.Euler(0f, 0f, eul);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target - transform.position), Time.deltaTime * 10);
        transform.position += transform.forward * speed* Time.deltaTime;
        */
    }
    
}
