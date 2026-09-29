using UnityEngine;

public class Veneno : BaseAbility
{
    public override string AbilityName { get; set; } = "Veneno";

    public override void Execute()
    {
        Shoot(10, StatusEffect.Shock, 3f);
        PlayFeedback();
    }
}
