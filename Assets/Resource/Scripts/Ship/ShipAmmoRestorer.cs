
using UnityEngine;

[RequireComponent(typeof(ShipResource))]
public class ShipAmmoRestorer : MonoBehaviour
{
    [SerializeField] private ShipResource shipResource;
    private float _stopRestoreTime = 0.4f;
    private float _stopRestoreTimer;
    private float _ammoDenominator;

    private void Start()
    {
        shipResource = shipResource == null ? GetComponent<ShipResource>() : shipResource;
    }

    private void OnEnable()
    {
        shipResource.OnSpendAmmo += StopToRestore;
        Tick.OnTick += RestoreAmmo;
    }
    private void OnDisable()
    {
        shipResource.OnSpendAmmo -= StopToRestore;
        Tick.OnTick -= RestoreAmmo;
    }

    private void StopToRestore()
    {
        _stopRestoreTimer = 0f;
    }

    private void RestoreAmmo()
    {
        _stopRestoreTimer += Tick.TickTime;
        if (_stopRestoreTime > _stopRestoreTimer) return;
        shipResource.RestoreAmmo(shipResource.MaxAmmo / _ammoDenominator);
    }
}
