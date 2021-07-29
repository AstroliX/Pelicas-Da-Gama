using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pelicas
{
    public class SC_MiniGameTest : MonoBehaviour
    {
        int points;
        [SerializeField] int amountNeeded;

        [SerializeField] GameObject pointButton;
        [SerializeField] GameObject youWonButton;


        SC_MiniGameManager miniGameManagerScript;

        private void Awake()
        {
            miniGameManagerScript = FindObjectOfType<SC_MiniGameManager>();
        }

        private void Update()
        {
            if(points == amountNeeded)
            {
                pointButton.SetActive(false);
                youWonButton.SetActive(true);
                miniGameManagerScript.HeWon();
            }
        }

        public void AddPoint()
        {
            points++;
        }

        public void ReturnToCity(string levelName)
        {
            
            SceneManager.LoadScene(levelName);
        }

        
    }

}
