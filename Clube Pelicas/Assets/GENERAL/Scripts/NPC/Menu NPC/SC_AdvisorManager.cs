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


        [Space]
        [Header("States")]
        [SerializeField] GameObject state_1;
        [SerializeField] GameObject state_2;
        [SerializeField] GameObject state_3;
        [SerializeField] GameObject state_4;


        [Space]
        [Header("Updated TXT")]
        [SerializeField] TextMeshProUGUI goldTXT;
        [SerializeField] TextMeshProUGUI crewTXT;
        float crew;
        int gold;

        
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
            }
            
        }

        #endregion

        #region - PUBLIC_FUNCTIONS -

        public void GoToPreviewSea()
        {
            areYouSureUWantSea.SetActive(true);
        }

        public void YesGoToSea(string levelName)
        {
            
            SceneManager.LoadScene(levelName);
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
        }

        public void LeavePayMenu()
        {
            crew_buttons.SetActive(true);
            SetStateCrew();
            payCrewMenu.SetActive(false);
            moneyUHave.SetActive(false);
        }

        public void Pay15()
        {
            if (resource.gold >= 15)
            {
                resource.gold -= 15;
                resource.crew += 10;


                PlayerPrefs.SetInt("gold", resource.gold);
                PlayerPrefs.SetFloat("crew", resource.crew);
            }
        }

        public void Pay30()
        {
            if (resource.gold >= 30)
            {
                resource.gold -= 30;
                resource.crew += 20;


                PlayerPrefs.SetInt("gold", resource.gold);
                PlayerPrefs.SetFloat("crew", resource.crew);
            }
        }

        public void Pay50()
        { 
            if(resource.gold >= 50)
            {
                resource.gold -= 50;
                resource.crew += 30;


                PlayerPrefs.SetInt("gold", resource.gold);
                PlayerPrefs.SetFloat("crew", resource.crew);
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
                state_1.SetActive(true);
            }

            if (resource.crew > 25 && resource.crew < 50)
            {
                state_2.SetActive(true);
            }

            if (resource.crew > 50 && resource.crew < 75)
            {
                state_3.SetActive(true);
            }

            if (resource.crew > 75)
            {
                state_4.SetActive(true);
            }
        }

        #endregion
    }
}

