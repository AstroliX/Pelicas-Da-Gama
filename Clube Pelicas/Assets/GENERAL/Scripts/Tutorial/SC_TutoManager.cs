using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pelicas
{
    public class SC_TutoManager : MonoBehaviour
    {
        public bool step_1;
        public bool step_2;
        public bool step_3;
        public bool step_4;
        public bool step_5;
        public bool step_6;

        [Space]
        [SerializeField] Transform advisor;
        [SerializeField] Transform player;

        [SerializeField] bool isSea;
        int secondTime;


        private void Awake()
        {
            secondTime = PlayerPrefs.GetInt("secondTime");
            if (!isSea && secondTime == 1)
            {
                step_4 = true;
                SetNewPos();
                Debug.Log("step 4");

            }

        }

        private void Start()
        {
            

            if (!isSea && secondTime == 0)
            {
                step_1 = true;
                PlayerPrefs.SetFloat("crew", 100f);
                Debug.Log("Step 1");
            }
            else if(isSea)
            {
                step_3 = true;
                Debug.Log("Step 3");
            }

            
        }

        void SetNewPos()
        {
            advisor.position = new Vector3(0, 0, 3);
            advisor.Rotate(0, -1, 0, Space.Self);

            player.position = new Vector3(0, 0, 1.9f);
            player.Rotate(0, -29, 0, Space.Self);
        }
    }
}
