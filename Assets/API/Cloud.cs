using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
  /*  void OnCollisionEnter2D(Collider2D collision) //aaa為自定義碰撞事件
    {
        if (collision.tag == "Player") //如果aaa碰撞事件的物件標籤名稱是test
        {
            Destroy(collision.gameObject); //刪除碰撞到的物件(CubeA)
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") //如果aaa碰撞事件的物件標籤名稱是test
        {
            Destroy(gameObject,2.5f); //刪除碰撞到的物件(CubeA)
        }
    }
}
