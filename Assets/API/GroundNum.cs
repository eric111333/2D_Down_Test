using UnityEngine;
using UnityEngine.UI;

public class GroundNum : MonoBehaviour
{
    public float gameTime;
    public Text gametext;
    public GameObject boss;
    public static int bossNum=1;
    public GameObject endground;
    public static int bosskiller;
    public Text bossdie;
    //public Transform startline;
    void Boss()
    {

        Vector3 poss = new Vector3(0, -3, 0);
        if (bosskiller <= 0 &&bossNum>0)
        {
            bossNum--;
            Vector3 pos = new Vector3(0, -5.1f, 0);
            Instantiate(endground, pos, Quaternion.identity);
            //endground.SetActive(true);
            Instantiate(boss, poss, Quaternion.identity);
            Spawner.spawnTime = 3f;
        }
        if(bosskiller<=0)
            bosskiller = 0;
        if (Enemy00.bossDie)
        {
            Debug.Log("111");
            Enemy00.bossDieNum++;
            Spawner.spawnTime = 1.2f;
            bosskiller += 10+Enemy00.bossDieNum;
            bossNum++;
            bossdie.text = "" + Enemy00.bossDieNum;
            //Enemy00.bossDie = false;
        }
    }
    private void Update()
    {
        //gameTime -= Time.deltaTime;
        gametext.text = "BOSS出擊" + bosskiller + "隻";
        Boss();
    }
    private void Start()
    {
         bosskiller = 10;
        bossNum = 1;
    }

    /*    public Text displayCountFloor;
        private int point;
        void Start()
        {

        }
        void DisplayCountFloor()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(4, 0), -transform.right * 8f);


            displayCountFloor.text = "第" + point.ToString("000") + "層";
        }
        void Update()
        {
            DisplayCountFloor();
        }
        private void OnDrawGizmos()
        {
            //Gizmos.DrawRay(groundcheck.position + new Vector3(4, 0), -transform.right * 8f);
            //Gizmos.DrawRay(groundcheck.position + new Vector3(0, 0), transform.right * 4f);
        }*/
}
