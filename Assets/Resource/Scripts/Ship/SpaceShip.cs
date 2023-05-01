
using UnityEngine;

[RequireComponent(typeof(ShipCharacteristics))]
[RequireComponent(typeof(ShipAmmoRestorer))]
[RequireComponent(typeof(ShipResource))]
public class SpaceShip : MonoBehaviour
{
    private ShipCharacteristics _shipCharacteristics;
    private ShipResource _shipResource;
    public ShipResource ShipResource => _shipResource;

    private void OnValidate()
    {
        _shipCharacteristics = _shipCharacteristics == null ? GetComponent<ShipCharacteristics>() : _shipCharacteristics;
        _shipResource = _shipResource == null ? GetComponent<ShipResource>() : _shipResource;
    }

    private void Start()
    {
        SetResource();
    }

    public void ChangeShipCharacteristics(ShipCharacteristics shipCharacteristics)
    {
        this._shipCharacteristics = shipCharacteristics;
        SetResource();
    }

    private void SetResource()
    {
        var parameter = _shipCharacteristics.Parameter;
        _shipResource.SetResource(parameter.Health, parameter.Armor, parameter.Ammo);
    }
}
