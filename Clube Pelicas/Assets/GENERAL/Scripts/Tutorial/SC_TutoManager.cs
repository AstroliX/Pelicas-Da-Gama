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

        [SerializeField] bool isSea;

        private void Start()
        {
            if (!isSea)
            {
                step_1 = true;
            }
            else
            {
                step_3 = true;
            }
            
        }
    }
}
