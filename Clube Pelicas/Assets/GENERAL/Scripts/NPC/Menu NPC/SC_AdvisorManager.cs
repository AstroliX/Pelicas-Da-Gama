using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


namespace Pelicas
{
    public class SC_AdvisorManager : MonoBehaviour
    {

        [Header("MENUs")]
        [SerializeField] GameObject mainMenu;
        [SerializeField] GameObject crewMenu;
        [SerializeField] GameObject payCrewMenu;

        [SerializeField] GameObject areYouSureUWantSea;

        
        

        [Space]
        [Header("Crew Menu")]
        [SerializeField] GameObject moneyUHave;
        [SerializeField] GameObject crew_buttons;
        [SerializeField] GameObject statesGroup;
        [SerializeField] GameObject fb_YouDontHaveEnoughGold;


        [Space]
        [Header("States")]
        [SerializeField] GameObject state_1;
        [SerializeField] GameObject state_2;
        [SerializeField] GameObject state_3;
        [SerializeField] GameObject state_4;
        [SerializeField] GameObject state_logo;
        [SerializeField] Sprite s_state_1;
        [SerializeField] Sprite s_state_2;
        [SerializeField] Sprite s_state_3;
        [SerializeField] Sprite s_state_4;




        [Space]
        [Header("Updated TXT")]
        [SerializeField] TextMeshProUGUI goldTXT;
        [SerializeField] TextMeshProUGUI crewTXT;


        [Space]
        [SerializeField] GameObject npcAnim;

        float crew;
        int gold;

        bool isHappy;
        bool isSad;
        bool isCrewMenu;

        SC_ResourcesManager resource;
        SC_KingSystem king;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            resource = FindObjectOfType<SC_ResourcesManager>();
        }

        private void Update()
        {
            if (isCrewMenu)
            {
                crew = resource.crew;
                gold = resource.gold;

                goldTXT.text = gold + "";
                crewTXT.text = crew + "/100";

                SetStateCrew();
            }

            if (isHappy)
            {
                npcAnim.GetComponent<SC_NPCAnim>().PlayNPCAnimHappy();
            }

            if (isSad)
            {
                npcAnim.GetComponent<SC_NPCAnim>().PlayNPCAnimSad();
            }
            
        }

        IEnumerator YouDontHaveEnoughGold()
        {
            fb_YouDontHaveEnoughGold.SetActive(true);
            npcAnim.GetComponent<SC_NPCAnim>().canTalk = false;
            isSad = true;
            yield return new WaitForSeconds(2);
            isSad = false;
            npcAnim.GetComponent<SC_NPCAnim>().canTalk = true;
            fb_YouDontHaveEnoughGold.SetActive(false);
        }

        IEnumerator Happy()
        {
            npcAnim.GetComponent<SC_NPCAnim>().canTalk = false;
            isHappy = true;
            yield return new WaitForSeconds(1.4f);
            isHappy = false;

            npcAnim.GetComponent<SC_NPCAnim>().canTalk = true;
        }

        #endregion

        #region - PUBLIC_FUNCTIONS -

        public void GoToPreviewSea()
        {
            areYouSureUWantSea.SetActive(true);
        }

        public void YesGoToSea(string levelName)
        {

            StartCoroutine(StartDelay());

            IEnumerator StartDelay()

            {

                yield return new WaitForSeconds(2);

                SceneManager.LoadScene(levelName);

            }

        }

        public void NoToSea()
        {
            areYouSureUWantSea.SetActive(false);
        }


        public void GoToCrewMenu()
        {
            mainMenu.SetActive(false);
            crewMenu.SetActive(true);
            isCrewMenu = true;
            SetStateCrew();

        }

        public void WasCrewNowMain()
        {
            DeactivateAllStates();
            crewMenu.SetActive(false);
            mainMenu.SetActive(true);
            isCrewMenu = false;
        }

        public void GoToPayMenu()
        {
            crew_buttons.SetActive(false);
            DeactivateAllStates();
            payCrewMenu.SetActive(true);
            moneyUHave.SetActive(true);
            statesGroup.SetActive(false);
        }

        public void LeavePayMenu()
        {
            crew_buttons.SetActive(true);
            SetStateCrew();
            payCrewMenu.SetActive(false);
            moneyUHave.SetActive(false);
            statesGroup.SetActive(true);
        }

        public void Pay15()
        {
            if (resource.gold >= 15)
            {
                resource.gold -= 15;
                resource.crew += 10;

                StartCoroutine(Happy());

                PlayerPrefs.SetInt("gold", resource.gold);
                PlayerPrefs.SetFloat("crew", resource.crew);
            }
            else if(resource.gold < 15)
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }
        }

        public void Pay30()
        {
            if (resource.gold >= 30)
            {
                resource.gold -= 30;
                resource.crew += 20;

                StartCoroutine(Happy());

                PlayerPrefs.SetInt("gold", resource.gold);
                PlayerPrefs.SetFloat("crew", resource.crew);
            }
            else if (resource.gold < 30)
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }
        }

        public void Pay50()
        { 
            if(resource.gold >= 50)
            {
                resource.gold -= 50;
                resource.crew += 30;

                StartCoroutine(Happy());

                PlayerPrefs.SetInt("gold", resource.gold);
                PlayerPrefs.SetFloat("crew", resource.crew);
            }
            else if (resource.gold < 50)
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }

        }

        #endregion

        #region - PRIVATE_FUNCTIONS -

        void DeactivateAllStates()
        {
            state_1.SetActive(false);
            state_2.SetActive(false);
            state_3.SetActive(false);
            state_4.SetActive(false);
        }

        void SetStateCrew()
        {
            if (resource.crew < 25)
            {
                state_logo.GetComponent<Image>().sprite = s_state_4;
                state_4.SetActive(true);
            }

            if (resource.crew > 25 && resource.crew < 50)
            {
                state_logo.GetComponent<Image>().sprite = s_state_3;
                state_3.SetActive(true);
            }

            if (resource.crew > 50 && resource.crew < 75)
            {
                state_logo.GetComponent<Image>().sprite = s_state_2;
                state_2.SetActive(true);
            }

            if (resource.crew > 75)
            {
                state_logo.GetComponent<Image>().sprite = s_state_1;
                state_1.SetActive(true);
            }
        }

        #endregion
    }
}

