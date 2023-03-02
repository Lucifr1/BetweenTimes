using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    private Transform camera;
    private Vector3 lastPos;
    public Vector2 multiplier;
    private float textureSize;

    private void Start()
    {
        camera = Camera.main.transform;
        lastPos = camera.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureSize = texture.width / sprite.pixelsPerUnit;
    }

    private void Update()
    {
        Vector3 deltaMovement = camera.position - lastPos;
        transform.position += new Vector3(deltaMovement.x * multiplier.x, deltaMovement.y * multiplier.y);
        lastPos = camera.position;

        if(Mathf.Abs(camera.position.x - transform.position.x) >= textureSize)
        {
            float offset = (camera.position.x - transform.position.x) % textureSize;
            transform.position = new Vector3(camera.position.x + offset, transform.position.y);
        }
    }
}
