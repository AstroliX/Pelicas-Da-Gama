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

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {

                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    anim.Play("ANIM_Run");
                 
                }

                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {

                    transform.rotation = Quaternion.Euler(0, -90, 0);
                    anim.Play("ANIM_Run");

                }
            }

            

            
        }
        #endregion

        #region - PUBLIC_FUNCTIONS -




        #endregion

        #region - PRIVATE_FUNCTIONS -



        #endregion
    }
}


