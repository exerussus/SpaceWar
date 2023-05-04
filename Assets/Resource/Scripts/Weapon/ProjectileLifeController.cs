
using UnityEngine;

[RequireComponent(typeof(ProjectileColliderObserver))]
public class ProjectileLifeController : MonoBehaviour
{
    [SerializeField] private float lifeTime = 10f;
    private float lifeTimer;
    private ProjectileColliderObserver _colliderObserver;
    private GameObject _projectile;

    private void OnValidate()
    {
        _colliderObserver = _colliderObserver == null ? GetComponent<ProjectileColliderObserver>() : _colliderObserver;
    }

    private void OnEnable()
    {
        lifeTimer = Time.deltaTime;
        _colliderObserver.OnTouch += DestroyProjectile;
        Tick.OnFixedUpdate += DestroyOnLifeTimeGone;
    }

    private void Start()
    {
        _projectile = GetComponent<GameObject>();
    }

    private void DestroyOnLifeTimeGone()
    {
        if (lifeTime > Time.deltaTime - lifeTimer) return;
        DestroyProjectile();
    }
    
    private void DestroyProjectile()
    {
        Tick.OnFixedUpdate -= DestroyOnLifeTimeGone;
        _colliderObserver.OnTouch -= DestroyProjectile;
        Destroy(_projectile);
    }
}
