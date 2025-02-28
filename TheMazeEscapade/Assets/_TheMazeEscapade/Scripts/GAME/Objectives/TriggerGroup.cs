using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerGroup : MonoBehaviour
{
      public GameObject[] triggerObjects;
      public bool[] triggerStates;

      public UnityEvent OnAllTriggeredEvents = new UnityEvent();

      private void Awake() {
            triggerStates = new bool[triggerObjects.Length];
      }

      public void CheckStates() {
            for (int x = 0; x < triggerStates.Length; x++) {
                  if (!triggerStates[x]) {
                        return;
                  }
            }
            OnAllTriggeredEvents.Invoke();
      }
}
