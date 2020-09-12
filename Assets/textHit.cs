using UnityEngine;

public class textHit : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 1f);
        transform.localPosition += new Vector3(0, 0.5f, 0);
    }


    void Update()
    {
        
    }
}
