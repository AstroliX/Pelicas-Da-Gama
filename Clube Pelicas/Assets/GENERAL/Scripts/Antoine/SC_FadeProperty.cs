using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_FadeProperty : MonoBehaviour
{
    private Image myImage;

    public Material instanceOfMat;
    public Shader shader;
    public float Size;
    public Vector2 Position;

    // Use this for initialization
    void Awake()
    {
        myImage = GetComponent<Image>();
        instanceOfMat = new Material(shader);

        instanceOfMat.SetFloat("Flashing White", Size);
        instanceOfMat.SetVector("_Pos", Position);
    }

    // Update is called once per frame
    void Update()
    {
        instanceOfMat.SetFloat("_MainSize", Size);
        myImage.material = instanceOfMat;
    }
}