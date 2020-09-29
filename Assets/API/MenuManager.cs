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
    public GameObject panel;

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
        PlayerPrefs.SetFloat("playermpMax", 10);
        PlayerPrefs.SetInt("goldNum", 100);
        PlayerPrefs.SetInt("potionNum", 3);
        //PlayerPrefs.SetFloat("attackSpeed", attack.attackSpeed);
        PlayerPrefs.SetInt("attackDamage", 10);
        PlayerPrefs.SetInt("atkDamageNum", 10);
        PlayerPrefs.SetInt("HpPulsNum", 10);
        PlayerPrefs.SetFloat("volume2", 0.7f);
        PlayerPrefs.SetInt("backgame", 1);
        PlayerPrefs.SetInt("skillpuls", 1);
        PlayerPrefs.SetInt("mppuls", 1);

        StartCoroutine(Loading());

    }
    private void Start()
    {
        Screen.SetResolution(480, 854, false);
        backGameNum = PlayerPrefs.GetInt("backgame");
    }
    private void Update()
    {
        if (backGameNum > 0)
        {
            //startbutton.SetActive(false);
            back.SetActive(true);
        }

    }
    private IEnumerator Loading()
    {
        panel.SetActive(true);                                      //啟動設定(BOOL)  -  True 顯示. false 隱藏
        AsyncOperation ao = SceneManager.LoadSceneAsync("SampleScene");//非同步載入資訊 = 場景管理器.非同步載入("場景名稱")
        ao.allowSceneActivation = false;                           //載入資訊.允許自動載入 = 否 不允許自動載入

        //當載入訊息.完成 為false -  尚未載入完程時執行
        while (!ao.isDone)                                          //(ao.isDone == false)
        {
            //progress 載入場景的進度為0-1.如果設定allow為false會卡在0.9
            //ToString("F小數點位數"):小數點2位F2 .小數點0位F0 
            //textLoading.text = "載入進度" + (ao.progress / 0.9f * 100).ToString("F1") + "％";//載入文字 = "載入進度" + ao.進度*100 + "％"
            //imgLoading.fillAmount = ao.progress / 0.9f;
            yield return null;

            if (ao.progress == 0.9f)         //如果 ao.進度=0.9                   
            {
                //textTip.enabled = true;      //提是文字.啟動 = 是 - 顯示提是文字
                if (Input.anyKeyDown)
                    ao.allowSceneActivation = true; //如果按下任意鍵 允許進入

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
}
