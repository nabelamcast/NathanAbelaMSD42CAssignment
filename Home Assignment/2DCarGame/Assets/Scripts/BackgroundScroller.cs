using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // Speed of the scrolling background
    [SerializeField] float backgroundScrollSpeed = 1f;

    // Material from the texture
    Material myMaterial;

    // Off Set Movement
    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        // Gets material of the background from the Renderer component
        myMaterial = GetComponent<Renderer>().material;

        // Scrolls in the y-axis at the given speed
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the texture of the material by offSet every frame
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
