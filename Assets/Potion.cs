using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public static int potionNum;
    public Text potionText;
    public Text atkDamage;
    public Text HpPuls;
    public Text SkillPulstext;
    public Text mpPulstext;
    public static int atkDamageNum;
    public static int skillpuls;
    public static int mpPuls;
    public GameObject Fireball;
    public GameObject target;
    public GameObject printitem;
    public Text goldNum;
    public Text goldNum1;
    public Text goldskillNum;
    public Text goldmpNum;
    private Image fire;
    //private Image fire2;
    private float firetime;
    private float fireCDtime=2;
    Vector3 t0 = new Vector3(0, 0, 0);
    public static int HpPulsNum;


    void Start()
    {
        //potionNum = 3;
        //atkDamageNum = 10;
        //HpPulsNum = 10;
        //skillpuls = 1;
        fire = GameObject.Find("fire").GetComponent<Image>();
        //fire2 = GameObject.Find("fire2").GetComponent<Image>();
        //GameObject.Find("血條").GetComponent<Image>();
        skillpuls = PlayerPrefs.GetInt("skillpuls");
        HpPulsNum = PlayerPrefs.GetInt("HpPulsNum");
        atkDamageNum = PlayerPrefs.GetInt("atkDamageNum");
        potionNum = PlayerPrefs.GetInt("potionNum");
        mpPuls= PlayerPrefs.GetInt("mppuls");

    }
    public void skill()
    {

        if (fire.fillAmount >= 1 && Player.mp >= 2)
        {
            for (int i = 0; i < skillpuls; i++)
        {
        float x = target.GetComponent<Transform>().position.x+1.5f;
        float x1 = target.GetComponent<Transform>().position.x - 1.5f;
        float y = target.GetComponent<Transform>().position.y + Random.Range(-0.5f, 0.5f);
        Vector3 pos = new Vector3(x, y, 0);
        Vector3 pos1 = new Vector3(x1, y, 0);
            if (Player.front==true)
        Instantiate(Fireball, pos, Quaternion.identity);
            if(Player.front==false)
        Instantiate(Fireball, pos1, Quaternion.identity);
            
            //fire2.fillAmount = 0;
            
        }
            Player.mp -= 2;
            fire.fillAmount = 0;
        }

        if(Player.mp<=1)
            {
            GameObject points = Instantiate(printitem, t0, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "魔力不足";
        }

    }
    public void PulsSkill()
    {
        if(Player.goldNum >= skillpuls*1000)
        {
            
            Player.goldNum -= skillpuls * 1000;
            skillpuls++;
            GameObject points = Instantiate(printitem, t0, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "火球*" + skillpuls;
        }
        if (Player.goldNum < skillpuls * 1000)
        {
            GameObject points = Instantiate(printitem, t0, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "金錢不足";
        }
    }
    public void PulsMp()
    {
        if (Player.goldNum >= mpPuls * 200)
        {
            Player.goldNum -= mpPuls * 200;
            mpPuls++;
        Player.mpMax += 2;
        GameObject points = Instantiate(printitem, t0, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMesh>().text = "MPMAX+" + 2;
        }
            
        if (Player.goldNum < mpPuls * 200)
        {
            GameObject points = Instantiate(printitem, t0, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "金錢不足";
        }


    }

    public void PulsDamage()
    {
        
        if (Player.goldNum >= atkDamageNum * 10)
        {
            Player.goldNum -= atkDamageNum*10;
            atkDamageNum++;
            attack.attackDamage++;

            GameObject points = Instantiate(printitem, t0, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "攻擊力=" + atkDamageNum ;
        }
     if (Player.goldNum <= atkDamageNum * 10)
        {
        GameObject points = Instantiate(printitem, t0, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMesh>().text = "金錢不足";
        }
            
    }
    public void PulsHp()
    {
        if(Player.goldNum >= HpPulsNum * 10)
        {
            Player.goldNum -= HpPulsNum * 10;
            HpPulsNum++;
            Player.hpMax += 10;
            Player.hp += 10;

            GameObject points = Instantiate(printitem, t0, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "HPMAX+" + 10;
        }
        if (Player.goldNum <= HpPulsNum * 10)
        {
            GameObject points = Instantiate(printitem, t0, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "金錢不足";
        }
    }

    public void pot()
    {

        if (potionNum > 0 && Player.hp <=Player.hpMax-20)
        {
            potionNum--;
            Player.hp += 50;
        }
    }

    void Update()
    {
        potionText.text = "" + potionNum;
        firetime += Time.deltaTime;
        if(fire.fillAmount==0)
        { if (firetime >= fireCDtime) firetime = 0;}
            
        fire.fillAmount = firetime / fireCDtime;
        //fire2.fillAmount = firetime / fireCDtime;
        goldNum.text = "" + atkDamageNum * 10;
        atkDamage.text = "" + atkDamageNum;
        goldNum1.text = "" + HpPulsNum * 10;
        HpPuls.text = "" + HpPulsNum;
        SkillPulstext.text = "" + skillpuls;
        goldskillNum.text = "" + skillpuls * 1000;
        mpPulstext.text = "" + mpPuls;
        goldmpNum.text = "" + mpPuls * 200;
    }
}
