using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] Vector2 parallaxSpeed;

    Material material;

    Vector2 offset;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset = parallaxSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
