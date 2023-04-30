
using UnityEngine;

[RequireComponent(typeof(ShipCharacteristics))]
public class SpaceShip : MonoBehaviour
{
    [SerializeField] private ShipCharacteristics shipCharacteristics;
    public ShipResource ShipResource { get; private set; }

    private void Start()
    {
        shipCharacteristics = shipCharacteristics == null ? GetComponent<ShipCharacteristics>() : shipCharacteristics;
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
        ShipResource = gameObject.AddComponent<ShipResource>();
        ShipResource.SetResource(parameter.Health, parameter.Armor, parameter.Ammo);
    }
}
