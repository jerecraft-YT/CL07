using UnityEngine;

public class Hielo : BaseAbility
{
    public override string AbilityName { get;} = "Hielo";

    public override void Execute()
    {
        Shoot(10, StatusEffect.Freeze, 3f);
        PlayFeedback();
    }
}
