using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Pelicas
{
    public class SC_DialogManager : MonoBehaviour
    {
        public TextMeshProUGUI textDisplayDoorLocked;
        public string[] sentences;
        private int index;
        public float typingSpeed;
        [SerializeField] GameObject continueButton;
        [SerializeField] GameObject menu;
        [SerializeField] bool isSea;

        SC_TutoPlayerController tutoPlayer;
        SC_CursorController cursor;
        SC_TutoNpcTrigger setup;
        SC_TutoManager tuto;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            tutoPlayer = FindObjectOfType<SC_TutoPlayerController>();
            cursor = FindObjectOfType<SC_CursorController>();
            setup = FindObjectOfType<SC_TutoNpcTrigger>();
            tuto = FindObjectOfType<SC_TutoManager>();
        }

        private void Start()
        {
            StartCoroutine(Type());

            //tutoPlayer.canMove = false;


        }

        private void Update()
        {
            if (textDisplayDoorLocked.text == sentences[index])
            {
                continueButton.SetActive(true);
                cursor.ActivateCursor();
                
                

            }
        }

        IEnumerator Type()
        {

            foreach (char letter in sentences[index].ToCharArray())
            {
                textDisplayDoorLocked.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

        }

        #endregion

        #region - PUBLIC_FUNCTIONS -

        public void NextSentence()
        {
            continueButton.SetActive(false);




            if (index < sentences.Length - 1)
            {
                index++;
                textDisplayDoorLocked.text = "";
                StartCoroutine(Type());
            }
            else
            {
                textDisplayDoorLocked.text = "";


                cursor.DeactivateCursor();
                
                
                Destroy(menu);
                setup.LeaveTalk();

                

            }
        }

        #endregion

        #region - PRIVATE_FUNCTIONS -
        #endregion







    }
}
