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
        public bool isTuto;
        bool isPauseMenu;
        [SerializeField] bool isSea;

        [Space]
        [Header("Menus")]
        [SerializeField] GameObject helpMenu;
        [SerializeField] GameObject pauseMenu;

        

        

        SC_CursorController cursor;
        SC_PlayerController player;
        SC_SeaPlayerController seaPlayer;
        SC_TutoPlayerController tutoPlayer;


        #region - UNITY_FUNCTIONS -
        private void Awake()
        {
            cursor = FindObjectOfType<SC_CursorController>();
            player = FindObjectOfType<SC_PlayerController>();
            seaPlayer = FindObjectOfType<SC_SeaPlayerController>();
            tutoPlayer = FindObjectOfType<SC_TutoPlayerController>();
            Cursor.lockState = CursorLockMode.None;

        }



        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                if (!isMainMenu && !isPauseMenu && !isSea)
                {
                    if (player.canDisplay && !isTuto)
                    {
                        PauseGame();
                    }
                    else if (isTuto && tutoPlayer.canDisplay)
                    {
                        PauseGame();
                    }
                    
                }
                else if(!isMainMenu && !isPauseMenu && isSea)
                {
                    if (seaPlayer.seaCanDisplay)
                    {
                        PauseGame();
                    }
                    
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
            //Time.timeScale = 1;
            isPauseMenu = false;
           
            if (!isSea)
            {
                cursor.DeactivateCursor();
                player.canMove = true;
                player.canDisplay = true;
            }
            else
            {
                Time.timeScale = 1;
                seaPlayer.canMove = true;
                seaPlayer.seaCanDisplay = true;
            }
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        #endregion


        #region - PRIVATE_FUNCTIONS -

        void PauseGame()
        {
            if (!isSea)
            {
                player.canMove = false;
                player.canDisplay = false;
                cursor.ActivateCursor();
            }
            else
            {
                seaPlayer.canMove = false;
                seaPlayer.seaCanDisplay = false;
                Time.timeScale = 0;
            }
            
            pauseMenu.SetActive(true);
            isPauseMenu = true;
            
            Debug.Log("Pause");
        }

        #endregion



    }
}

