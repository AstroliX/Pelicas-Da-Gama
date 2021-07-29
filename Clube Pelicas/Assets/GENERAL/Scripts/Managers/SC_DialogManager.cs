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
        

        public GameObject continueButton;


        SC_PlayerController playerScript;

        #region - UNITY_FUNCTIONS -

        private void Start()
        {
            StartCoroutine(Type());
            playerScript = FindObjectOfType<SC_PlayerController>();
            playerScript.canMove = false;

        }

        private void Update()
        {
            if (textDisplayDoorLocked.text == sentences[index])
            {
                continueButton.SetActive(true);

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
            }
        }

        #endregion

        #region - PRIVATE_FUNCTIONS -
        #endregion






    }
}

