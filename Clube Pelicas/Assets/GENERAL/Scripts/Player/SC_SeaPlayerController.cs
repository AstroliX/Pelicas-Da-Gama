using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_SeaPlayerController : MonoBehaviour
    {
      [Space]
        [SerializeField] float speed;
        private float inputHorizontal;
        public bool canMove;
        public bool isSeaTalking;
        Rigidbody rb;
        Animation anim;
        bool firstTimeOnSea;
        bool isMoving;
        [SerializeField] bool isTuto;
        public bool seaCanDisplay;
        public bool seaIsTalking;

        SC_KingSystem king;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            king = FindObjectOfType<SC_KingSystem>();
            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animation>();
        }

        public void Start()
        {
            

            if (isTuto)
            {
                canMove = false;
                seaCanDisplay = false;
            }
            else
            {
                canMove = true;
                seaCanDisplay = true;
                king.PlayerInSea();
            }
            
        }

        void Update()
        {


            if (isSeaTalking)
            {
                anim.Play("ANIM_Talk");
            }
          
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (canMove)
                {
                    anim.Play("ANIM_Run");
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    inputHorizontal = Input.GetAxisRaw("Horizontal");
                    rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
                }
                
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
            {
                if (canMove)
                {
                    anim.Play("ANIM_Run");
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                    inputHorizontal = Input.GetAxisRaw("Horizontal");
                    rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
                }
                
            }

            if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.LeftArrow) == false )
            {
                anim.Play("ANIM_Idle");
            }            
        }
        #endregion
    }
}