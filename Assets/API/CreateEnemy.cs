using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    [Header("要生成的敵人")]
    public GameObject enemy01;
    [Header("生成頻率"), Range(0.1f,5f)]
    public float interval = 1;
    [Header("x 軸最小值")]
    public float xMin=-3;
    [Header("x 軸最大值")]
    public float xMax=3;
    public GameObject Target;

    private void CreateEnemy01()
    {
        float x = Random.Range(xMax, xMin);
        //float y = Random.Range(yMax, yMin);
        float y = Target.GetComponent<Transform>().position.y + Random.Range(-5, 5);
        Vector3 pos = new Vector3(x, y, 0);
        Instantiate(enemy01, pos, Quaternion.identity);
    }
    void Start()
    {
        float r = Random.Range(0f, 2f);
        InvokeRepeating("CreateEnemy01", r, interval);
    }
    void Update()
    {
        
    }
}
