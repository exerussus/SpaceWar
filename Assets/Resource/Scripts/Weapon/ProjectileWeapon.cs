
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/ProjectileWeapon", fileName = "NewProjectileWeapon")]
public class ProjectileWeapon : Weapon
{
    [SerializeField] private ProjectileParameter ProjectileParameter;
    
    public override void Shoot()
    {
        
    }
}
