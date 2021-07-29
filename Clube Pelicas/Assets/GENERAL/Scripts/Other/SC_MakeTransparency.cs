using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_MakeTransparency : MonoBehaviour
    {
        [SerializeField] List<SC_BuildingTransparency> currentlyInTheWay;
        [SerializeField] List<SC_BuildingTransparency> alreadyTransparent;

        [SerializeField] Transform player;
        Transform camera;


        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            currentlyInTheWay = new List<SC_BuildingTransparency>();
            alreadyTransparent = new List<SC_BuildingTransparency>();

            camera = this.gameObject.transform;
        }

        private void Update()
        {
            GetAllObjectsInTheWay();

            MakeObjectsSolid();
            MakeObjectsTransparent();
        }

        #endregion


        #region - PUBLIC_FUNCTIONS -
        #endregion


        #region - PRIVATE_FUNCTIONS -

        void GetAllObjectsInTheWay()
        {
            currentlyInTheWay.Clear();

            float cameraPlayerDistance = Vector3.Magnitude(camera.position - player.position);

            Ray ray1_Forward = new Ray(camera.position, player.position - camera.position);
            Ray ray1_Backward = new Ray(player.position, camera.position - player.position);


            var hits1_Forward = Physics.RaycastAll(ray1_Forward, cameraPlayerDistance);
            var hits1_Backward = Physics.RaycastAll(ray1_Backward, cameraPlayerDistance);

            foreach (var hit in hits1_Backward)
            {
                if (hit.collider.gameObject.TryGetComponent(out SC_BuildingTransparency bTransparency))
                {
                    if (!currentlyInTheWay.Contains(bTransparency))
                    {
                        currentlyInTheWay.Add(bTransparency);
                    }
                }
            }

        }

        void MakeObjectsTransparent()
        {
            for (int i = 0; i < currentlyInTheWay.Count; i++)
            {
                SC_BuildingTransparency bTransparency = currentlyInTheWay[i];

                if (!alreadyTransparent.Contains(bTransparency))
                {
                    bTransparency.ShowTransparency();
                    alreadyTransparent.Add(bTransparency);
                }
            }
        }

        void MakeObjectsSolid()
        {
            for (int i = alreadyTransparent.Count - 1; i >= 0; i--)
            {
                SC_BuildingTransparency bWasTransparent = alreadyTransparent[i];

                if (!currentlyInTheWay.Contains(bWasTransparent))
                {
                    bWasTransparent.ShowSolid();
                    alreadyTransparent.Remove(bWasTransparent);
                }
            }
        }

        #endregion





    }
}

