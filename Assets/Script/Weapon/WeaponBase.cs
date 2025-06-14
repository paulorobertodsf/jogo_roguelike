using UnityEngine;

public abstract class WeaponBase : ScriptableObject
{
    public float cooldown;
    public abstract void Use(Transform firePoint, GameObject owner);
}
