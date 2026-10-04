using MoreMountains.Feedbacks;
using UnityEngine;

public abstract class BaseAbility : MonoBehaviour
{
    [SerializeField] private Projectile proyectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private MMF_Player castFeedback;

    public abstract string AbilityName { get;}
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
        projectile.transform.up = firePoint.up;
    }
}
