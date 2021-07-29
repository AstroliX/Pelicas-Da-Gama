using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SC_RNG : MonoBehaviour
{
    public float RNG = 1;
    public Vector3 Vector;

    // Start is called before the first frame update
    void Start()
    {

        
        transform.eulerAngles = Vector;

    }

    // Update is called once per frame
    void Update()
    {



    }
}
