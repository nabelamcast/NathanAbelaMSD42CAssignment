using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // Speed of the scrolling
    [SerializeField] float backgroundScrollSpeed = 1.5f;

    // Material from the texture
    Material myMaterial;

    // offSet Movement
    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        // Get material of the background from the Renderer component
        myMaterial = GetComponent<Renderer>().material;

        // Scroll in the y-axis at the speed
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the texture of the material by offSet every frame
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
