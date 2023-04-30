
using System;
using UnityEngine;

public class Tick : MonoBehaviour
{
    private float tickTime = 0.1f;
    private float tickTimer;
    
    public static Action OnFixedUpdate;
    public static Action OnTick;

    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
        tickTimer += Time.fixedDeltaTime;
        if (tickTime < tickTimer)
        {
            OnTick?.Invoke();
            tickTimer = 0f;
        }
    }
}
