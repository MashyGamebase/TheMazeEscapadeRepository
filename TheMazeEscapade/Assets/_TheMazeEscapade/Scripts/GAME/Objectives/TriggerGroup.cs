using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerGroup : MonoBehaviour
{
      public GameObject triggerObjects;
      public List<int> triggers;

      public UnityEvent OnAllTriggeredEvents = new UnityEvent();
}
