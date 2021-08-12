using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_TutoNpcAnim : MonoBehaviour
    {
        [SerializeField] GameObject npcGo;
        [SerializeField] bool isKing;

        public bool canIdle;
        public bool canTalk;

        SC_TutoNpcTrigger npc;
        Animation anim;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            npc = FindObjectOfType<SC_TutoNpcTrigger>();
            anim = GetComponent<Animation>();
        }
        private void Start()
        {
            canIdle = true;
            canTalk = true;
        }

        private void Update()
        {


            if (npcGo.GetComponent<SC_TutoNpcTrigger>().isTalking)
            {
                if (!isKing & canTalk)
                {
                    anim.Play("ANIM_Talk");
                }
                else if (canTalk)
                {
                    anim.Play("ANIM_KingTalk");
                }

            }

            if (!npcGo.GetComponent<SC_TutoNpcTrigger>().isTalking)
            {
                if (!isKing && canIdle)
                {
                    anim.Play("ANIM_Idle");
                }
                else if (canIdle)
                {
                    anim.Play("ANIM_KingIdle");
                }

            }
        }

        #endregion

        #region - PUBLIC_FUNCTIONS -



        public void PlayNPCAnimBye()
        {


            if (!isKing)
            {
                anim.Play("ANIM_Bye");
            }
            else
            {
                anim.Play("ANIM_KingThanks");
            }
        }

        public void PlayNPCAnimHappy()
        {

            if (!isKing)
            {
                anim.Play("ANIM_Happy");
            }
            else
            {
                anim.Play("ANIM_KingThanks");
            }
        }

        public void PlayNPCAnimSad()
        {

            if (!isKing)
            {
                anim.Play("ANIM_Sad");
            }
            else
            {
                anim.Play("ANIM_KingThanks");
            }
        }

        public void StopAnimIdle()
        {
            canIdle = false;
            anim.Stop("ANIM_Idle");
        }
        #endregion

        #region - PRIVATE_FUNCTIONS -
        #endregion

    }

}

