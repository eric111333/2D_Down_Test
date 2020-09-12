
using UnityEditor;
using UnityEngine;

public class OpenSkill : MonoBehaviour
{
    public GameObject skill;
    public GameObject team;
    public GameObject setUI;
    public bool skillOpen;
    public bool teamOpen;
    public bool setUiOpen;
    void Start()
    {
        
    }
  
    public void openUI()
    {
        setUiOpen = !setUiOpen;
        setUI.SetActive(setUiOpen);
        if(setUiOpen==true)
        {
            if(Time.timeScale==1)
            {
                PauseGame();
            }
        }
        if (setUiOpen == false)
        {
            if(Time.timeScale==0)
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

    public  void openskill()
    {
        skillOpen = !skillOpen;
        skill.SetActive(skillOpen);
    }
    public void openteam()
    {
        teamOpen = !teamOpen;
        team.SetActive(teamOpen);
    }

    void Update()
    {
        
    }
}
