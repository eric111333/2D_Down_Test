
using UnityEngine;

public class background : MonoBehaviour
{
    Material mat;
    Vector2 mov;
    public Vector2 speed;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    private void Update()
    {
        mov += speed * Time.deltaTime;
        mat.mainTextureOffset = mov;
    }
}
