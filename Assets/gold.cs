using UnityEngine;

public class gold : MonoBehaviour
{
   // public Vector3 target;
    //public GameObject player;

    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform.position;
        Destroy(gameObject, 20);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        
        if (collision.tag == "Player") Destroy(gameObject);

    }
    void Update()
    {

    }
    /*
    void Move()
    {
        Debug.DrawLine(target, transform.position, Color.red);
        float eul = target.z - transform.position.z;
        transform.rotation = Quaternion.Euler(0f, 0f, eul);
        transform.position += transform.forward * 2 * Time.deltaTime;
    }
    */
}
