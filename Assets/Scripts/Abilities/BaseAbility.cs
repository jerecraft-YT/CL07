using MoreMountains.Feedbacks;
using UnityEngine;

public abstract class BaseAbility : MonoBehaviour
{
    public Projectile proyectilePrefab;
    public Transform firePoint;
    public MMF_Player castFeedback;

    public abstract string AbilityName { get; set; }
    public abstract void Execute();
    protected virtual void PlayFeedback()
    {
        if (castFeedback == null)
        {
            Debug.LogWarning("referencia de feedback no encontrado");
            return;
        }

        castFeedback.PlayFeedbacks();
    }

    protected void Shoot(float speed, StatusEffect effect, float duration)
    {
        if (proyectilePrefab == null)
        {
            Debug.LogWarning("prefab de proyectil no asignado");
            return;
        }

        Projectile projectile = Instantiate(proyectilePrefab, firePoint.position, Quaternion.identity);

        projectile.speed = speed;
        projectile.duration = duration;
        projectile.effect = effect;
    }
}
