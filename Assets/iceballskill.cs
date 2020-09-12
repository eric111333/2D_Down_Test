using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceballskill : MonoBehaviour
{ 
 //  敵人衝向的目標
 //public GameObject target;
public Vector3 target;
//  敵人移動速度
public int moveSpeed = 10;
//  敵人旋轉速度
public float rotationSpeed = 10;
//  敵人和玩家之間的最大距離
public int maxDistance;
// ???  看下面解釋
private Transform myTransform;
// ???
Rigidbody2D rb;
void Awake()
{
    myTransform = transform;
}

void Start()
{
        
    rb = GetComponent<Rigidbody2D>();
    //  通過標籤去查詢遊戲物件
    //GameObject go = GameObject.FindGameObjectWithTag("敵人");
    target = GameObject.FindWithTag("Player").transform.position;
    //  將它的transform指定給target
    //target = go.transform;
    maxDistance = 0;
    Destroy(gameObject, 8);

}
private void OnTriggerEnter2D(Collider2D collision)
{
    Destroy(gameObject);
}

void Update()
{
        //gameObject.transform.Rotate(new Vector3(0f, 0f, 90f));
        //  在敵人和玩家之間畫一條線
    Debug.DrawLine(target, myTransform.position, Color.red);
    //  看著目標
    float eul = target.z - myTransform.position.z;
    myTransform.rotation = Quaternion.Euler(0f, 0f, eul);
    if (transform.position.x < target.x || transform.position.y < target.y)
    {
        rb.velocity = new Vector2(moveSpeed, moveSpeed);
        transform.localScale = new Vector3(1, 1, 1);
    }
    else
    {
        rb.velocity = new Vector2(-moveSpeed, moveSpeed);
        transform.localScale = new Vector3(-1, 1, 1);
    }
    //myTransform.rotation =Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target - myTransform.position),Time.deltaTime*rotationSpeed);
    //  判斷敵人和玩家之間的距離是否大於最大距離
    if (Vector3.Distance(target, myTransform.position) > maxDistance)
    {
        //  移向目標
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
    }
}
}
