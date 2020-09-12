using UnityEngine;

public class FanRun : MonoBehaviour
{
    Animator animator;
    public bool fanon;
    //public GameObject wind;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {     
            animator.Play("fan");
        transform.GetChild(0).gameObject.SetActive(true);
        }


    }
}
