
using UnityEngine;

public class ShipCharacteristics : MonoBehaviour
{
    [SerializeField] private ShipParameter parameter;
    public ShipParameter Parameter => parameter;

    private void Start()
    {
        if (parameter == null) Debug.LogError("ShipParameter field not found.");
    }
}
