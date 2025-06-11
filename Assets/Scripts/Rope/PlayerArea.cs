using SHS.Assessment.Observer;
using SHS.Assessment.Utilities;
using UnityEngine;

namespace SHS.Assessment.Rope
{
    public class PlayerArea : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer BgImage;

        [SerializeField] private KeyCode tapKey;

        [SerializeField] private Vector2 pullDirection;

        [SerializeField] private GameEvent triggerEvent;

        [SerializeField] private bool isWinState;

        private float tapPower = 0f;

        public float TapPower => tapPower;

        public Vector2 TugForce => pullDirection.normalized * tapPower;

        private bool lockControls = false;

        #region Unity

        private void OnEnable()
        {
            EventBus.Subscribe(GameEvent.GAME_ENDED, OnLevelEnded);
            EventBus.Subscribe(GameEvent.GAME_TIMEOUT, OnLevelEnded);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(GameEvent.GAME_ENDED, OnLevelEnded);
            EventBus.Unsubscribe(GameEvent.GAME_TIMEOUT, OnLevelEnded);
        }

        private void Update()
        {
            if (lockControls) return;

            if (Input.GetKeyDown(tapKey))
            {
                tapPower += Helper.powerPerTap;
            }

            tapPower = Mathf.Max(0f, tapPower - Helper.DecayRate * Time.deltaTime);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Hit");
            if (collision.CompareTag(Helper.RopeTag))
            {
                Debug.Log("Event to trigger ==>" + triggerEvent);
                EventBus.Publish(triggerEvent, isWinState);
            }
        }
        #endregion

        #region Callbacks
        private void OnLevelEnded(object Args)
        {
            lockControls = true;
        }
        #endregion
    }
}