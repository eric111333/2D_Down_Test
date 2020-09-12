using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private bool move;

    public float speed = 0.01f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = true;

            InvokeRepeating("SpeedUp", 0, 0.5f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
            transform.Translate(0, speed, 0);
    }
    private void SpeedUp()
    {
        speed += 0.01f;
    }
}
