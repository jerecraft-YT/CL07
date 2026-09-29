using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public StatusEffect effect;
    public float duration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Destroy(gameObject,duration);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy == null) return;

        enemy.ApplyStatus(effect);
    }
}
