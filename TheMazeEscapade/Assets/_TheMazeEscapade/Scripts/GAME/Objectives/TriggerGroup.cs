using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerGroup : MonoBehaviour
{
    public bool ifSequential;

    public GameObject[] triggerObjects;
    public bool[] triggerStates;

    public int currentIndex = 0; // Tracks the current correct plate index

    public UnityEvent OnAllTriggeredEvents = new UnityEvent();

    private void Awake()
    {
        triggerStates = new bool[triggerObjects.Length];
    }

    public void TriggerPlate(int index)
    {
        if (index < 0 || index >= triggerStates.Length) return; // Safety check

        if (ifSequential)
        {
            if (index == currentIndex) // Ensure the correct sequence
            {
                triggerStates[index] = true;
                currentIndex++;

                triggerObjects[index].GetComponent<PressurePlateMngr>().activated = true;

                if (currentIndex == triggerStates.Length) // All plates pressed in order
                {
                    OnAllTriggeredEvents.Invoke();
                }
            }
            else
            {
                ResetTriggers(); // Wrong order, reset everything
            }
        }
        else
        {
            triggerStates[index] = true;
            CheckStates();
        }
    }

    private void ResetTriggers()
    {
        for (int i = 0; i < triggerStates.Length; i++)
        {
            triggerStates[i] = false;
            triggerObjects[i].GetComponent<PressurePlateMngr>().TogglePlate(false);
        }
        currentIndex = 0;
    }

    public void CheckStates()
    {
        for (int x = 0; x < triggerStates.Length; x++)
        {
            if (!triggerStates[x])
            {
                return;
            }
        }
        OnAllTriggeredEvents.Invoke();
    }
}