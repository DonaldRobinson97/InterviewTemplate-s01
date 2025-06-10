using UnityEngine;

namespace SHS.Assessment.Observer
{
    public class EventToggler : MonoBehaviour
    {
        public GameEvent Event;

        public void ToggleEvent()
        {
            EventBus.Publish(Event);
        }
    }
}
