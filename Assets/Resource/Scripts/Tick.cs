
using System;
using UnityEngine;

public class Tick : MonoBehaviour
{
    private static Tick instance = null;
    private static float _tickTime = 0.1f;
    private static float _tickTimer;

    public static float TickTime => _tickTime;
    public static Action OnFixedUpdate;
    public static Action OnTick;

    private void Start()
    {
        if (instance == null) instance = this;
        else if (instance == this) Destroy(gameObject);
    }
    
    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
        _tickTimer += Time.fixedDeltaTime;
        if (_tickTime < _tickTimer)
        {
            OnTick?.Invoke();
            _tickTimer = 0f;
        }
    }
}
