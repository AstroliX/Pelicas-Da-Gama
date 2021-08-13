using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Fade : MonoBehaviour
{
    private bool FadeIn = false;
    private bool FadeOut = false;
    private Animation Anim;

    void Start()
    {
        FadeOut = false;
        Anim = GetComponent<Animation>();
    }

    public void FadeOutVoide(bool FadeOut)
    {
        Anim.Play("ANIM_FadeOUT");
        Debug.Log("FADEOUT");
    }
}
