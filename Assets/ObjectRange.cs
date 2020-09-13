using UnityEngine;

public class ObjectRange : MonoBehaviour
{
    public GameObject gold;
    public GameObject potion;
    float speed = 5f;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 pos = new Vector3(0, 0, 0);
        if(other.tag == "Gold")
        {
            
            gold.transform.Translate(pos* speed * Time.deltaTime, 0);
        }
        if(other.tag == "potion")
        {
            potion.transform.Translate(pos* speed * Time.deltaTime, 0);
        }
    }


}
