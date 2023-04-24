
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private Resource health = new Resource(100f);
    [SerializeField] private Resource armor = new Resource(50f);
    [SerializeField] private Resource ammo = new Resource(100f);
    
}
