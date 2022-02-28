/*
 *  BackgroundScroller
 *  makes the background "move", scroll the background picture and create a flying like effect for the game
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // Config params
    [SerializeField] float backgroundScrollSpeed = 0.5f;

    // Cached component references
    Material myMaterial;
    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // makes the background scroll according to the off set speed
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
