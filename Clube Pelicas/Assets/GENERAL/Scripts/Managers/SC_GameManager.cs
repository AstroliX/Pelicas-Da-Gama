using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pelicas
{
    public class SC_GameManager : MonoBehaviour
    {
        [Header("Menus")]
        [SerializeField] GameObject defeatMenu;
        [SerializeField] GameObject winMenu;

        [Space]
        [Header("Amount needed")]
        [SerializeField] int reputToWin;

        SC_PlayerController player;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            player = FindObjectOfType<SC_PlayerController>();
        }

        private void Start()
        {
            if(PlayerPrefs.GetFloat("crew") <= 0)
            {
                EndGame();
                defeatMenu.SetActive(true);
            }
            else if(PlayerPrefs.GetInt("reputPoint") >= reputToWin)
            {
                EndGame();
                winMenu.SetActive(true);
            }
        }

        #endregion

        #region - PUBLIC_FUNCTIONS -

        public void ContinueGame()
        {
            CloseMenu();
            player.canDisplay = true;
            player.canMove = true;
        }

        public void RestartGame(string scene)
        {
            PlayerPrefs.DeleteAll();
            player.canDisplay = true;
            player.canMove = true;
            SceneManager.LoadScene(scene);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        #endregion

        #region - PRIVATE_FUNCTIONS -

        void EndGame()
        {
            player.canDisplay = false;
            player.canMove = false;
        }

        void CloseMenu()
        {
            winMenu.SetActive(false);
            defeatMenu.SetActive(false);
        }

        #endregion
    }
}

