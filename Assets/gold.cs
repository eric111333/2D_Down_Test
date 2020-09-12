using UnityEngine;

public class gold : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 20);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") Destroy(gameObject);

    }
    void Update()
    {
        
    }
    
}
