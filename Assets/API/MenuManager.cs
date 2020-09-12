using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //public GameObject audios;
    //public GameObject playeraudios;
    public static int backGameNum;
    public GameObject startbutton;
    public GameObject back;

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void BackGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartGame()
    {
        PlayerPrefs.SetFloat("volume", 0.7f);
        PlayerPrefs.SetFloat("playerhpMax", 300);
        PlayerPrefs.SetInt("goldNum", 100);
        PlayerPrefs.SetInt("potionNum", 3);
        //PlayerPrefs.SetFloat("attackSpeed", attack.attackSpeed);
        PlayerPrefs.SetInt("attackDamage", 10);
        PlayerPrefs.SetInt("atkDamageNum", 10);
        PlayerPrefs.SetInt("HpPulsNum", 10);
        PlayerPrefs.SetFloat("volume2", 0.7f);
        PlayerPrefs.SetInt("backgame", 1);
        PlayerPrefs.SetInt("skillpuls", 1);
        SceneManager.LoadScene("SampleScene");

    }
    private void Start()
    {
        Screen.SetResolution(480, 854, false);
        backGameNum = PlayerPrefs.GetInt("backgame");
    }
    private void Update()
    {
        if(backGameNum>0)
        {
            startbutton.SetActive(false);
            back.SetActive(true);
        }

    }


    /* public void Easy()
     {
         Player.hp = 10000;
         Player.hpMax = 10000;
     }

     public void Mid()
     {
         Player.hp = 1000;
         Player.hpMax = 1000;
     }
     public void Difficult()
     {
         Player.hp = 100;
         Player.hpMax = 100;
     }
    */
}
