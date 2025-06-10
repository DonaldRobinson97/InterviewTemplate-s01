using System.Collections.Generic;

namespace SHS.Assessment.Observer
{
    public delegate void Callback(object arg);

    public static class EventBus
    {
        private static readonly Dictionary<GameEvent, List<Callback>> eventTable = new();

        public static void Subscribe(GameEvent eventType, Callback handler)
        {
            if (!eventTable.ContainsKey(eventType))
            {
                eventTable[eventType] = new List<Callback>();
            }

            var handlers = eventTable[eventType];
            if (!handlers.Contains(handler))
            {
                handlers.Add(handler);
            }
        }

        public static void Unsubscribe(GameEvent eventType, Callback handler)
        {
            if (eventTable.ContainsKey(eventType))
            {
                var handlers = eventTable[eventType];
                handlers.Remove(handler);
                if (handlers.Count == 0)
                {
                    eventTable.Remove(eventType);
                }
            }
        }

        public static void Publish(GameEvent eventType, object arg = null)
        {
            if (eventTable.ContainsKey(eventType))
            {
                var handlersCopy = new List<Callback>(eventTable[eventType]);
                foreach (var handler in handlersCopy)
                {
                    handler?.Invoke(arg);
                }
            }
        }
    }
}