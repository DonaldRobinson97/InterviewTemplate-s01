using SHS.Assessment.Utilities;
using UnityEngine;

namespace SHS.Assessment.Rope
{
    public class PlayerArea : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer BgImage;

        [SerializeField] private KeyCode tapKey;

        [SerializeField] private Vector2 pullDirection;

        private float tapPower = 0f;

        public float TapPower => tapPower;

        public Vector2 TugForce => pullDirection.normalized * tapPower;

        #region Unity
        private void Update()
        {
            if (Input.GetKeyDown(tapKey))
            {
                tapPower += Helper.powerPerTap;
            }

            tapPower = Mathf.Max(0f, tapPower - Helper.DecayRate * Time.deltaTime);
        }
        #endregion
    }
}