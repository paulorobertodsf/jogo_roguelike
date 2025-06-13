using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Weapons/StaffObject")]
public class StaffWeapon : WeaponBase
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float cooldown = 0.3f;
    [System.NonSerialized]
    public float nextFireTime = 0f;

    public override void Use(Transform firePoint, GameObject owner)
    {
        float currentTime = Time.time;
        if (currentTime < nextFireTime) return;

        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0f;

        Vector2 direction = (mouseWorldPosition - firePoint.position).normalized;

        GameObject fireBall = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        fireBall.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileSpeed;

        Collider2D fireballCol = fireBall.GetComponent<Collider2D>();
        Collider2D playerCol = owner.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(fireballCol, playerCol);

        ProjectileController controller = fireBall.GetComponent<ProjectileController>();
        controller.direction = direction;

        nextFireTime = currentTime + cooldown;
    }
}
