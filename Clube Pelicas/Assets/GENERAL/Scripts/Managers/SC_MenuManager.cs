using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Pelicas
{
    public class SC_MenuManager : MonoBehaviour
    {
        [Header("Bools")]
        public bool enableMusic;
        public bool enableSFX;
        public bool isMainMenu;
        bool isPauseMenu;

        [Space]
        [Header("Menus")]
        [SerializeField] GameObject helpMenu;
        [SerializeField] GameObject pauseMenu;

        SC_CursorController cursor;
        SC_PlayerController player;

        #region - UNITY_FUNCTIONS -
        private void Awake()
        {
            cursor = FindObjectOfType<SC_CursorController>();
            player = FindObjectOfType<SC_PlayerController>();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                if (!isMainMenu && !isPauseMenu)
                {
                    
                    PauseGame();
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
            cursor.DeactivateCursor();
            pauseMenu.SetActive(false);
            //Time.timeScale = 1;
            isPauseMenu = false;
            player.canMove = true;
            player.canDisplay = true;
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        #endregion


        #region - PRIVATE_FUNCTIONS -

        void PauseGame()
        {
            player.canMove = false;
            player.canDisplay = false;
            pauseMenu.SetActive(true);
            //Time.timeScale = 0;
            isPauseMenu = true;
            cursor.ActivateCursor();
            Debug.Log("Pause");
        }

        #endregion



    }
}

