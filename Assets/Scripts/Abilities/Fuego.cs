using UnityEngine;

public class Fuego : BaseAbility
{
    public override string AbilityName { get;} = "Fuego";

    public override void Execute()
    {
        Shoot(10, StatusEffect.Burn, 3f);
        PlayFeedback();
    }
}
