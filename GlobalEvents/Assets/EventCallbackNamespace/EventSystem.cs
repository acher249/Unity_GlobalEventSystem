using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class EventSystem : MonoBehaviour
    {
        // the EventSystem is going to handel all of the callback events
        // anyone who does anything can jsut send an event through the EventSystem to let everyone know.
        // this is a "Centeralized Event Queue"

            // event system is ready to accept events and then broadcast them to all of the listeners

        void Start()
        {

        }

        // make handy way to get the eventListener
        static private EventSystem __Current;
        static public EventSystem Current
        {
            get
            {
                if(__Current == null)
                {
                    __Current = GameObject.FindObjectOfType<EventSystem>();
                }

                return __Current;
            }
        }

        // unity has it's own Event class, and we have our won, but since it is in our namespace it will defualt to ours..
        public delegate void EventListener(EventInfo ei);

        // dictionary with key as the event type but then have the value as a sublist of delegates
        // this is the master list of event listeners.. All event listeners
        Dictionary<EVENT_TYPE, List<EventListener>> eventListeners;

        // we need a registration and unregistration system
        // when you register for an event we will have to specify what event type we are listening for and 
        // provide a function that will be the event listener.
        public void RegisterListener(EVENT_TYPE eventType, EventListener listener)
        {
            // if there is no dictionary yet, create a dictionary to hold the EventListeners
            if (eventListeners == null)
            {
                eventListeners = new Dictionary<EVENT_TYPE, List<EventListener>>();
            }

            // if ther is no list of eventListeners for this specific type of event, we need
            // to make  a new list of eventListeners for this type of event..
            if (eventListeners.ContainsKey(eventType) == false || eventListeners[eventType] == null)
            {
                eventListeners[eventType] = new List<EventListener>();
            }

            // the in the listener that was requested in the argument above
            eventListeners[eventType].Add(listener);
        }

        public void UnregisterListener(EVENT_TYPE eventType, EventListener listener)
        {
            // To Do, unregister the event Listener
        }

        // this is what happens when some other piece of code decides to launch an event.
        // we will have to specify what the event type is and then we will hve to pass some type of event info
        // specific to that type of event.
        public void FireEvent(EVENT_TYPE eventType, EventInfo eventInfo)
        {
            // this means that no one is listening and we can return right away
            if (eventListeners == null || eventListeners[eventType] == null )
            {
                return;
            }

            // when an event gets fired we go through a list of everyone who is listening for that specific event.
            // we call that function el and pass it the eventInfo. ... ** not exactly sure what "function" that is calling?
            foreach (EventListener el in eventListeners[eventType])
            {
                el(eventInfo);
            }
        }

    }
}

