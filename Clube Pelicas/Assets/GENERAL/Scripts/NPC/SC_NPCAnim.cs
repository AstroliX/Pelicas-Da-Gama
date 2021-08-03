using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_NPCAnim : MonoBehaviour
    {
        [SerializeField] GameObject npcGo;
        [SerializeField] bool isKing;

        SC_NPCController npc;
        Animation anim;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            npc = FindObjectOfType<SC_NPCController>();
            anim = GetComponent<Animation>();
        }

        private void Update()
        {
            

            if (npcGo.GetComponent<SC_NPCController>().isTalking)
            {
                if (!isKing)
                {
                    anim.Play("ANIM_Talk");
                }
                else
                {
                    anim.Play("ANIM_KingTalk");
                }
                
            }

            if (!npcGo.GetComponent<SC_NPCController>().isTalking)
            {
                if (!isKing)
                {
                    anim.Play("ANIM_Idle");
                }
                else
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
        #endregion

        #region - PRIVATE_FUNCTIONS -
        #endregion

    }
}

