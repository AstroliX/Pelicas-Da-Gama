using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_SeaPlayerController : MonoBehaviour
    {
        [SerializeField] float speed;
        private float inputHorizontal;
        public bool canMove;
        Rigidbody rb;
        Animation anim;
        bool firstTimeOnSea;
        bool isMoving;

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
            king.PlayerInSea();
            
        }

        void Update()
        {
            anim.Play("ANIM_Idle");
            if (canMove)
            {
                inputHorizontal = Input.GetAxisRaw("Horizontal");
                rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {

                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    isMoving = true;
                 
                }

                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {

                    transform.rotation = Quaternion.Euler(0, -90, 0);
                    isMoving = true;

                }

                
            }


            if (isMoving)
            {
                PlayRunAnim();
            }
            

            
        }
        #endregion

        #region - PUBLIC_FUNCTIONS -




        #endregion

        #region - PRIVATE_FUNCTIONS -

        void PlayRunAnim()
        {
            anim.Stop("ANIM_Idle");
            anim.Play("ANIM_Run");
        }

        #endregion
    }
}


