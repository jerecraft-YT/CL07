using TMPro;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _abilityName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_player == null)
        {
            Debug.LogWarning("Referencia al jugador no encontrada");
        }

        if (_abilityName == null)
        {
            Debug.LogWarning("Referencia al texto de habilidad no encontrada");
        }
    }

    //podria ser mas optimo? obvio, con actions pero creo que no enseño eso .w.
    //encima permitiria poner efectos cuando se cambia de habilidad, pero bueno, es un ejemplo simple
    private void Update()
    {
        if (_player == null || _abilityName == null) return;
        
        //harcodear texto? bueno aun no se puede usar localization asi que pasa piola .-.
        _abilityName.text = "Habilidad actual: " + _player.CurrentAbility.AbilityName;
    }
}
