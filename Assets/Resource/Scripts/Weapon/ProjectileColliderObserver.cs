
using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ProjectileColliderObserver : MonoBehaviour
{
    [SerializeField] private Collider2D collider;
    private static readonly int DestructibleLayer = LayerMask.NameToLayer("Destructible");
    private float _lifeTime = 10f;
    private float _lifeTimer;

    public Action<SpaceShip> OnTouchDestructible;
    
    private void Start()
    {
        collider = collider == null ? GetComponent<Collider2D>() : collider;
        if (collider == null) Debug.LogError("Collider not found.");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == DestructibleLayer)
        {
            var spaceShip = other.gameObject.GetComponent<SpaceShip>();
            OnTouchDestructible?.Invoke(spaceShip);
            DestroyProjectile();
        }
    }
    
    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
