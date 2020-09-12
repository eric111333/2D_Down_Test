using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject audios;
    public GameObject playeraudios;

    public void StartGame()
    {
        SceneManager.LoadScene("選單");
    }
    void Start()
    {
        //Player.hpMax=PlayerPrefs.GetFloat("playerhpMax");
        Player.goldNum=PlayerPrefs.GetInt("goldNum");
        //attack.attackSpeed=PlayerPrefs.GetFloat("attackSpeed");
        attack.attackDamage=PlayerPrefs.GetInt("attackDamage");
        audios.GetComponent<AudioSource>().volume=PlayerPrefs.GetFloat("volume");
        playeraudios.GetComponent<AudioSource>().volume=PlayerPrefs.GetFloat("volume2");
        MenuManager.backGameNum = PlayerPrefs.GetInt("backgame");
        

     }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
   
}
