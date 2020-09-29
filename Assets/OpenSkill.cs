
using UnityEditor;
using UnityEngine;

public class OpenSkill : MonoBehaviour
{
    public GameObject skill;
    public GameObject team;
    public GameObject setUI;
    public GameObject fire;
    public GameObject potion;
    public GameObject joy;
    public GameObject help;
    public bool skillOpen;
    public bool teamOpen;
    public bool setUiOpen;
    public bool helpUI;
    public int righthand;
    void Start()
    {
        righthand = PlayerPrefs.GetInt("right");
        if (righthand==1) right();

    }
    public void left()
    {
        righthand = 0;
        joy.transform.position = new Vector3(-45,0,0);
        potion.transform.position = new Vector3(300, 90, 0);
        fire.transform.position =new Vector3(420, 180, 0);
    }
    public void right()
    {
        righthand = 1;
        joy.transform.position = new Vector3(220, 0, 0);
        potion.transform.position = new Vector3(70, 90, 0);
        fire.transform.position = new Vector3(180, 180, 0);
    }


    public void openUI()
    {
        setUiOpen = !setUiOpen;
        setUI.SetActive(setUiOpen);
        if (setUiOpen == true)
        {
            if (Time.timeScale == 1)
            {
                PauseGame();
            }
        }
        if (setUiOpen == false)
        {
            if (Time.timeScale == 0)
            {
                ResumeGame();
            }
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
        //AudioSource.Pause();
        //isPaused = true;
        //Canvas_HUD.enabled = false;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void openskill()
    {
        skillOpen = !skillOpen;
        skill.SetActive(skillOpen);
    }
    public void openteam()
    {
        teamOpen = !teamOpen;
        team.SetActive(teamOpen);
    }
    public void openHelpUI()
    {
        helpUI = !helpUI;
        help.SetActive(helpUI);
        
    }

    void Update()
    {
        PlayerPrefs.SetInt("right", righthand);
    }
}
