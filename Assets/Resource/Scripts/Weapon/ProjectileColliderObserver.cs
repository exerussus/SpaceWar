
using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ProjectileColliderObserver : MonoBehaviour
{
    private Collider2D _collider;
    private static readonly int DestructibleLayer = LayerMask.NameToLayer("Destructible");

    public Action<SpaceShip> OnTouchDestructible;
    public Action OnTouch;
    
    private void OnValidate()
    {
        _collider = _collider == null ? GetComponent<Collider2D>() : _collider;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == DestructibleLayer)
        {
            _collider.enabled = false;
            var spaceShip = other.gameObject.GetComponent<SpaceShip>();
            OnTouchDestructible?.Invoke(spaceShip);
        }
        OnTouch?.Invoke();
    }
}
