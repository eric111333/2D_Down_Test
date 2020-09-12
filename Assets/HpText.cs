using UnityEngine.UI;
using UnityEngine;

public class HpText : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 offset = new Vector3(0, 20, 0);
    // Use this for initialization
    public float speed = 20;
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        //按A键，模拟Cube受伤
        // if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject temp = GameObject.Instantiate(prefab);
            //将游戏对象temp作为Canvas的子物体
            temp.transform.parent = GameObject.Find("Canvas").transform;
            //血量文本提示是UI控件，和Cube坐在的坐标系不是同一套，因此我们需要将血量产生点(Cube的位置)从世界坐标系转化成屏幕坐标系。为了上Cube的上方产生，我们可以在y周上给一个适量的偏移
            temp.transform.position = Camera.main.WorldToScreenPoint(transform.position) + offset;
            //假设当前的血量是Cube受攻击丢的血量
            temp.GetComponent<Text>().text = 40.ToString();
        }
    }
}

