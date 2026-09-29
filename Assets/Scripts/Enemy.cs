using UnityEngine;

public class Enemy : MonoBehaviour
{
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
    }

    public void ApplyStatus(StatusEffect effect, float duration)
    {
        Debug.Log("enemigo recibe: " + effect + " por: " + duration + " segundos");
    }
}
