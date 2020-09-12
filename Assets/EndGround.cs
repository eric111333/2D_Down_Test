using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGround : MonoBehaviour
{
    Vector3 movement;
    public float speed = 1;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        movement.y = speed;
    }


    // Update is called once per frame
    void Update()
    {
        if (Enemy00.bossDie == true)
        {
            Debug.Log("456");
            GetComponent<Platform>().enabled=true;
            Destroy(this.gameObject, 5);
            Enemy00.bossDie = false;
        }
    }


    }
