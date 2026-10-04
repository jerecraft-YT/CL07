using MoreMountains.Feedbacks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private MMF_Player _burnFeedback;
    [SerializeField] private MMF_Player _freezeFeedback;
    [SerializeField] private MMF_Player _PoisonFeedback;
    [SerializeField] private MMF_Player _shockFeedback;
    [SerializeField] private MMF_Player _slowFeedback;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyStatus(StatusEffect effect)
    {
        Debug.Log("enemigo recibe: " + effect);

        PlayFeedback(effect);
    }

    public void ApplyStatus(StatusEffect effect, float duration)
    {
        Debug.Log("enemigo recibe: " + effect + " por: " + duration + " segundos");

        PlayFeedback(effect);
    }

    private void PlayFeedback(StatusEffect effect)
    {
        switch (effect)
        {
            case StatusEffect.Burn:
                _burnFeedback?.PlayFeedbacks();
                break;
            case StatusEffect.Freeze:
                _freezeFeedback?.PlayFeedbacks();
                break;
            case StatusEffect.Poison:
                _PoisonFeedback?.PlayFeedbacks();
                break;
            case StatusEffect.Shock:
                _shockFeedback?.PlayFeedbacks();
                break;
            case StatusEffect.Slow:
                _slowFeedback?.PlayFeedbacks();
                break;
            default:
                Debug.LogWarning("Efecto de estado no reconocido: " + effect);
                break;
        }
    }
}
