using UnityEngine;

public class Rayo : BaseAbility
{
    public override string AbilityName { get;} = "Rayo";

    public override void Execute()
    {
        Shoot(10, StatusEffect.Shock, 3f);
        PlayFeedback();
    }
}
