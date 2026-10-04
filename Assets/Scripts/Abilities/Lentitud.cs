using UnityEngine;

public class Lentitud : BaseAbility
{
    public override string AbilityName { get;} = "Lentitud";

    public override void Execute()
    {
        Shoot(10, StatusEffect.Slow, 3f);
        PlayFeedback();
    }
}
