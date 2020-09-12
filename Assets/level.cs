using UnityEngine;
using UnityEngine.UI;

public class level : MonoBehaviour
{
    public Text atkDamage;
    public static int atkDamageNum;
    void Start()
    {

    }
    private void OnMouseDown()
    {
        if (Player.goldNum >= 100)
        {
            atkDamageNum++;
            attack.attackDamage++;
            Player.goldNum -= 100;
            atkDamage.text = "" + atkDamageNum;
        }


    }

    void Update()
    {

    }
}
