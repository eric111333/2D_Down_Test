using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;

public class Record : MonoBehaviour
{
    public GameObject audios;
    public GameObject playeraudios;
    void Start()
    {
        //PlayerPrefs.DeleteKey("goldNum");
        //PlayerPrefs.DeleteAll();
       /* PlayerPrefs.DeleteKey("playerhpMax");
        if (!PlayerPrefs.HasKey("playerhpMax"))
            PlayerPrefs.SetFloat("playerhpMax", 200);
        PlayerPrefs.SetFloat("playerhpMax", Player.hpMax);
        PlayerPrefs.DeleteKey("goldNum");
        if (!PlayerPrefs.HasKey("goldNum"))
            PlayerPrefs.SetInt("goldNum", 100);
        //PlayerPrefs.SetInt("goldNum", Player.goldNum);
        PlayerPrefs.SetInt("potionNum", Potion.potionNum);
        PlayerPrefs.SetFloat("attackSpeed", attack.attackSpeed);
        PlayerPrefs.SetInt("attackDamage", attack.attackDamage);
        PlayerPrefs.SetFloat("volume", audios.GetComponent<AudioSource>().volume);
        */
    }
    public void nextscene()
    {
        SceneManager.LoadScene("選單");
        SceneManager.LoadScene("SampleScene");
    }

    
    void Update()
    {
        PlayerPrefs.SetFloat("volume2", playeraudios.GetComponent<AudioSource>().volume);
        PlayerPrefs.SetFloat("playerhpMax", Player.hpMax);
        PlayerPrefs.SetInt("goldNum", Player.goldNum);
        PlayerPrefs.SetInt("potionNum", Potion.potionNum);
        //PlayerPrefs.SetFloat("attackSpeed", attack.attackSpeed);
        PlayerPrefs.SetInt("attackDamage", attack.attackDamage);
        PlayerPrefs.SetInt("atkDamageNum", Potion.atkDamageNum);
        PlayerPrefs.SetInt("HpPulsNum", Potion.HpPulsNum);
        PlayerPrefs.SetFloat("volume", audios.GetComponent<AudioSource>().volume);
        PlayerPrefs.SetInt("skillpuls", Potion.skillpuls);
    }
}
