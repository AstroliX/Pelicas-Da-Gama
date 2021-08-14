using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_HideAdvisorTeasingWhileLooting : MonoBehaviour
{

    private RectTransform MyRT;

    // Start is called before the first frame update
    private void Start()
    {
        MyRT = GetComponent<RectTransform>();
        MyRT.localScale = new Vector2(0, 0);
        StartCoroutine(Delay());
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(21);
        MyRT.localScale = new Vector2(1, 1);
    }
}
