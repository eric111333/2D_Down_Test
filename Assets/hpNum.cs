using UnityEngine.UI;
using UnityEngine;

public class hpNum : enemy
{
    public Text hpText;
    public float speed = 20;
    
    void Start()
    {
        Destroy(gameObject, 1f);
    }
    public override void TakeDamage(int damage)
    {
        //Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        hpText.text = "" + damage;
    }
}
