using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SC_ScalePulls : MonoBehaviour
{
    TextMeshProUGUI myRT;

    public float animationLength = 3;

    public AnimationCurve Curve;
    public float Max = 20;
    public float Min = 0;

    private float size = 0;
    private float timer = 0;
    private float lerpRatio = 0;
    private float remap = 0;


    void Start()
    {
        myRT = gameObject.GetComponent<TextMeshProUGUI>();
        myRT.fontSize = size;
        remap = Max - Min;
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        lerpRatio = timer / animationLength;

        if (timer < animationLength)
        {
            size = Curve.Evaluate(lerpRatio);
            size = size * remap + Min;
            myRT.fontSize = size;
        }

        else
        {
            timer = 0;
        }
    }
}