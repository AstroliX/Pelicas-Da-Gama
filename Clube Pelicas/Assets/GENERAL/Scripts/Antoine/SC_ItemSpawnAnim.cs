using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_ItemSpawnAnim : MonoBehaviour
{
    RectTransform myRT;

    public float animationLength = 3;

    public AnimationCurve Curve;

    private float size = 0;
    private float timer = 0;
    private float lerpRatio = 0;

    void Start()
    {
        myRT = gameObject.GetComponent<RectTransform>();
        myRT.localScale = new Vector2 (size,size);        
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        lerpRatio = timer / animationLength;

        if (timer < animationLength)
        {
            size = Curve.Evaluate(lerpRatio);
            myRT.localScale = new Vector2(size, size);
        }

        else if (timer > 3)
        {
            timer = 0;
        }
    }
}
