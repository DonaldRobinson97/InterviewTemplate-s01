using UnityEngine;

namespace SHS.Assessment.Rope
{
    public class RopeController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D ropeRb;
        [SerializeField] private float forceMultiplier = 10f;

        #region Public
        public void ApplyTugForce(Vector2 totalForce)
        {
            ropeRb.AddForce(totalForce * forceMultiplier, ForceMode2D.Force);
        }
        #endregion

    }
}
