using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_FadeManager : MonoBehaviour
{

    public GameObject FadeIn;
    public GameObject FadeOut;
    public GameObject FadeInOut;

    public void FadeInVoid(bool FadeInBool)
    {
        GameObject FadeInGO = GameObject.Instantiate(FadeIn, Vector3.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);

    }

    public void FadeOutVoid(bool FadeOutBool)
    {
        GameObject FadeOutGO = GameObject.Instantiate(FadeOut, Vector3.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
    }

    public void FadeInOutVoid(bool FadeInBool)
    {
        GameObject FadeInOutGO = GameObject.Instantiate(FadeInOut, Vector3.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);

    }

}
