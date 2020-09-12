using UnityEngine;

public class iceball : MonoBehaviour
{
    private SpriteRenderer sprPlayer;
    public float speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        sprPlayer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprPlayer.flipY == false)
            transform.Translate(0, speed * -1 * Time.deltaTime, 0);
        if (gameObject.transform.position.x >= 4)
            sprPlayer.flipY = true;
        if (sprPlayer.flipY == true)
            transform.Translate(0, speed * 1 * Time.deltaTime, 0);
        if (gameObject.transform.position.x <= -4)
            sprPlayer.flipY = false;
    }
}
