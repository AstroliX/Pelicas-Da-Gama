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

        private void Start()
        {
            canMove = true;
            seaCanDisplay = true;
            king.PlayerInSea();
            
        }

        void Update()
        {


            if (isSeaTalking)
            {
                anim.Play("ANIM_Talk");
            }

            anim.Play("ANIM_Idle");
            if (canMove)
            {
               

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {

                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    Move();

                }

                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {

                    transform.rotation = Quaternion.Euler(0, -90, 0);
                    Move();

                }

                
            }


            
        }
        #endregion

        #region - PUBLIC_FUNCTIONS -




        #endregion

        #region - PRIVATE_FUNCTIONS -

        void Move()
        {
            anim.Stop("ANIM_Idle");
            inputHorizontal = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
            anim.Play("ANIM_Run");
        }



        #endregion
    }
}


