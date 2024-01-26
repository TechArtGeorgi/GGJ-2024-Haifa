using System;
using System.Collections.Generic;
using UnityEngine;

public class PrankSequance : MonoBehaviour
{
    // Define the event triggered when the entire sequence is completed
    public event Action SequenceCompleted;

    // List to hold dynamic number of observers
    private List<Action> observers = new List<Action>();

    // Internal state to track the sequence
    private int sequenceIndex = 0;

    private void Start()
    {
        // Subscribe to the sequence completion event
        SequenceCompleted += OnSequenceCompleted;
    }

    // Subscribe an observer to the sequence
    public void AddObserver(Action observer)
    {
        observers.Add(() =>
        {
            if (sequenceIndex < observers.Count && observers[sequenceIndex] == observer)
            {
                Debug.Log($"Observer {sequenceIndex + 1} invoked!");
                sequenceIndex++;

                if (sequenceIndex == observers.Count)
                {
                    SequenceCompleted?.Invoke();
                }
            }
        });
    }

    // Event handler for the sequence completion event
    private void OnSequenceCompleted()
    {
        Debug.Log("Entire sequence completed! Returning true.");
        // Do something when the entire sequence is completed
        // For now, let's reset the sequence for the next run
        ResetSequence();
    }

    // Reset the sequence for the next run
    private void ResetSequence()
    {
        Debug.Log("Resetting sequence.");
        sequenceIndex = 0;
    }
}
