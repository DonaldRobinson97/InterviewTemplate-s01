using UnityEngine;
using SHS.Assessment.Rope;
using System.Collections.Generic;

namespace SHS.Assessment.Managers
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private List<PlayerArea> playerAreas;
        [SerializeField] private RopeController ropeController;

        #region Unity
        private void Update()
        {
            Vector2 totalForce = Vector2.zero;

            foreach (var area in playerAreas)
            {
                totalForce += area.TugForce;
            }

            ropeController.ApplyTugForce(totalForce);
        }
        #endregion
    }
}