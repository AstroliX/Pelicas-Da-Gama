using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_IntroAnimTransition : MonoBehaviour
{

    Animator MyAnimator;

    private bool Next = false;

    void Start()
    {

        MyAnimator = gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Next = true;
        }

        if (Time.time < 10)
        {
            Next = false;
        }

        if (Next == true)
        {
            MyAnimator.SetBool("Input", true);
            Debug.Log("Click!!");
        }
    }
}