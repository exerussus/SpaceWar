
using UnityEngine;

[RequireComponent(typeof(ShipCharacteristics))]
[RequireComponent(typeof(ShipAmmoRestorer))]
public class SpaceShip : MonoBehaviour
{
    [SerializeField] private ShipCharacteristics shipCharacteristics;
    [SerializeField] private ShipResource shipResource;
    public ShipResource ShipResource => shipResource;

    private void Start()
    {
        shipCharacteristics = shipCharacteristics == null ? GetComponent<ShipCharacteristics>() : shipCharacteristics;
        shipResource = shipResource == null ? GetComponent<ShipResource>() : shipResource;
        SetResource();
    }

    public void ChangeShipCharacteristics(ShipCharacteristics shipCharacteristics)
    {
        this.shipCharacteristics = shipCharacteristics;
        SetResource();
    }

    private void SetResource()
    {
        var parameter = shipCharacteristics.Parameter;
        shipResource.SetResource(parameter.Health, parameter.Armor, parameter.Ammo);
    }
}
