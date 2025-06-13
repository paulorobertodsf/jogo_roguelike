using UnityEngine;

public abstract class WeaponBase : ScriptableObject
{
    public abstract void Use(Transform firePoint, GameObject owner);
}
