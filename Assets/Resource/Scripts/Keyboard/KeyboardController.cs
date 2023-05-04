using UnityEngine;
using System;

public abstract class KeyboardController : MonoBehaviour
{
    private OrderTypes orderTypes;

    public Action OnMoveForward;
    public Action OnMoveBack;
    public Action OnMoveLeft;
    public Action OnMoveRight;
    public Action OnAttack;

    private struct OrderTypes
    {
        public bool Forward;
        public bool Back;
        public bool Left;
        public bool Right;
        public bool Attack;

        public void Zero()
        {
            Forward = false;
            Back = false;
            Left = false;
            Right = false;
            Attack  = false;
        }
    }

    private void Start()
    {
        orderTypes = new OrderTypes();
    }

    protected abstract bool IsPressRight();
    protected abstract bool IsPressLeft();
    protected abstract bool IsPressForward();
    protected abstract bool IsPressBack();
    protected abstract bool IsPressAttack();

    
    
    private void Update()
    {
        if (IsPressRight()) orderTypes.Right = true;
        if (IsPressLeft()) orderTypes.Left = true;
        if (IsPressForward()) orderTypes.Forward = true;
        if (IsPressBack()) orderTypes.Back = true;
        else if (IsPressAttack()) orderTypes.Attack = true;
    }

    private void FixedUpdate()
    {
        if (orderTypes.Right) OnMoveRight?.Invoke();
        if (orderTypes.Left) OnMoveLeft?.Invoke();
        if (orderTypes.Forward) OnMoveForward?.Invoke();
        if (orderTypes.Back) OnMoveBack?.Invoke();
        if (orderTypes.Attack) OnAttack?.Invoke();

        orderTypes.Zero();
    }
}
