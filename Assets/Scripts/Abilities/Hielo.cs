using UnityEngine;

public class Hielo : BaseAbility
{
    public override string AbilityName { get; set; } = "Fuego";

    public override void Execute()
    {
        Shoot(10, StatusEffect.Freeze, 3f);
        PlayFeedback();
    }
}
