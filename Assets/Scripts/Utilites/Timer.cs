using UnityEngine;

public struct Timer
{

    private float totalTime;
    private float timer;
    private bool isTimerActivated;

    public float GetCurrentTime()
    {
        return totalTime - timer;
    }

    public Timer(float totalTime = 1.0f)
    {
        this.totalTime = totalTime;
        timer = totalTime;
        isTimerActivated = false;
    }

    public void SubtractTimerByValue(float amount)
    {
        if (IsTimerEnded()) return;
        timer -= amount;
    }

    public bool IsTimerEnded()
    {
        if (!isTimerActivated) return false;
        if (timer <= 0f)
        {
            isTimerActivated = false;
            return true;
        }
        return false;
    }

    public bool IsTimerActive()
    {
        if (isTimerActivated && timer > 0f) return true;
        return false;
    }

    public void ActivateTimer()
    {
        isTimerActivated = true;
        timer = totalTime;
    }
    public void SetTimerTime(float newTime)
    {
        this.totalTime = newTime;
    }
}

