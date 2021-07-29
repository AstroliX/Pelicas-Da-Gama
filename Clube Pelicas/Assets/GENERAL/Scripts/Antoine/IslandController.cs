using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandController : MonoBehaviour
{
    
    [Header("Enemy Attributes")]
    [SerializeField] float speed = 10f;
    [SerializeField] float rotateSpeed = 50f;
    public bool canRotate;
    private bool canMove = true;
    
    [Space]
    [Header("Enemy Stats")]
    public float bound_x = -200f;

    private Vector3 Rotation_Vector;
    private float Rotation_Amount;

    private Vector3 Scale_Vector;
    private float Scale_Amount;

    void Start()
    {


   

        Rotation_Amount = Random.Range(0, 360);
        Rotation_Vector.y = Rotation_Amount;
        transform.eulerAngles = Rotation_Vector;


        Scale_Amount = Random.Range(0.25f, 1f);
        Scale_Vector.x = Scale_Amount;
        Scale_Vector.y = Scale_Amount;
        Scale_Vector.z = Scale_Amount;
        transform.localScale = Scale_Vector;

       
    }

    private void Update()
    {
        MoveEnemy();
        RotateEnemy();
    }

    void MoveEnemy()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.x < bound_x)
                Destroy(gameObject, 1);
        }
    }

    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
        }





    }

    private void DestroyEnemy()
    {

        Destroy(gameObject, 0.1f);

    }
}
