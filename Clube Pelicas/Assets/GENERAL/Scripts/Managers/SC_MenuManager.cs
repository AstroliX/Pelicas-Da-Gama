using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Pelicas
{
    public class SC_MenuManager : MonoBehaviour
    {

        public bool enableMusic;
        public bool enableSFX;
        public bool isMainMenu;
        bool isPauseMenu;

        [SerializeField] GameObject helpMenu;
        [SerializeField] GameObject pauseMenu;

        #region - UNITY_FUNCTIONS -

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isMainMenu && !isPauseMenu)
                {
                    PauseGame();
                }

                if(!isMainMenu && isPauseMenu)
                {
                    ResumeGame();
                }
            }
        }

        #endregion


        #region - PUBLIC_FUNCTIONS -

        public void LaunchGame(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void OpenHelpMenu()
        {
            helpMenu.SetActive(true);
        }

        public void CloseHelpMenu()
        {
            helpMenu.SetActive(false);
        }

        public void ResumeGame()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            isPauseMenu = false;
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        #endregion


        #region - PRIVATE_FUNCTIONS -

        void PauseGame()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPauseMenu = true;
        }

        #endregion



    }
}

