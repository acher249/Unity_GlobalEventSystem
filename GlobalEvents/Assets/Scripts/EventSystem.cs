using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This last way is to use No Event Type Enums and just let the class of the event BE the event type itself, to simplify the System.
// the class you specify is also ouur filter for listening
namespace ModusEvents
{
    public class EventSystem : MonoBehaviour
    {
        // the EventSystem is going to handel all of the callback events
        // anyone who does anything can jsut send an event through the EventSystem to let everyone know.
        // this is a "Centeralized Event Queue"

            // event system is ready to accept events and then broadcast them to all of the listeners

        void OnEnable()
        {
            __Current = this;
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


        delegate void EventListener(EventInfo ei);

        // dictionary with key as the event type but then have the value as a sublist of delegates
        // this is the master list of event listeners.. All event listeners
        Dictionary<System.Type, List<EventListener>> eventListeners;

        // we need a registration and unregistration system
        // use EventInfo as subclass
        // this is handeling all of the neccessary type casting..
        public void RegisterListener<T>(System.Action<T> listener) where T : EventInfo
        {
            System.Type eventType = typeof(T);

            // if there is no dictionary yet, create a dictionary to hold the EventListeners
            if (eventListeners == null)
            {
                eventListeners = new Dictionary<System.Type, List<EventListener>>();
            }

            // if ther is no list of eventListeners for this specific type of event, we need
            // to make  a new list of eventListeners for this type of event..
            if (eventListeners.ContainsKey(eventType) == false || eventListeners[eventType] == null)
            {
                eventListeners[eventType] = new List<EventListener>();
            }

            // this is where we are doing our type casting
            // wrapping a type conversion around the event listener
            EventListener wrapper = (ei) => { listener((T)ei); };

            // Add the EventListener to the List
            eventListeners[eventType].Add(wrapper);
        }

        public void UnregisterListener<T>(System.Action<T> listener) where T : EventInfo
        {
            // To Do, unregister the event Listener
        }

        // this is what happens when some other piece of code decides to launch an event.
        // we will have pass in the eventInfo, which is ALSO ACTING AS THE EVENT TYPE..
        public void FireEvent(EventInfo eventInfo)
        {
            System.Type trueEventInfoClass = eventInfo.GetType();

            // this means that no one is listening and we can return right away
            if (eventListeners == null || eventListeners[trueEventInfoClass] == null )
            {
                return;
            }

            // when an event gets fired we go through a list of everyone who is listening for that specific event.
            // we call that function el and pass it the eventInfo. ... ** not exactly sure what "function" that is calling?
            foreach (EventListener el in eventListeners[trueEventInfoClass])
            {
                el( eventInfo );
            }
        }

    }
}

