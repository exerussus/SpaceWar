
using System;
using UnityEngine;

[Serializable]
public class ProjectileParameter
{
    [SerializeField] private float speed;
    [SerializeField] private float blowArea;
    [SerializeField] private GameObject prefab;
    
    public float Speed => speed;
    public float BlowArea => blowArea;
    public GameObject Prefab => prefab;
}
