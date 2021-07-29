using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBoundary
{
    public float miniY, maxiY;

    
}

public class IslandManager : MonoBehaviour
{
    [Header("References")]
    public EnemyBoundary eBoundary;
    [SerializeField] GameObject[] asteroids;
    //[SerializeField] GameObject enemy;

    [Space]
    [Header("Gap")]
    private float timer;
    public float Min = 1f;
    public float Max = 2f;


    void Start()
    {

        Invoke("Spawner", timer);


    }


    void Spawner()
    {
        float pos_Y = Random.Range(eBoundary.miniY, eBoundary.maxiY);
        Vector3 temp = transform.position;
        temp.y = pos_Y;

      // if (Random.Range(0, 2) > 0)
        //{
            Instantiate(asteroids[Random.Range(0, asteroids.Length)], temp, Quaternion.identity);
       // }
       

        Debug.Log(timer);

        Invoke("Spawner", timer);

        timer = Random.Range(Min, Max);

    
    }
}
