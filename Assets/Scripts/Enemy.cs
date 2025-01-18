using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private int hitPoints = 3;
    [SerializeField] private int score = 100;
    
    private Scoreboard _scoreboard;

    private void Awake()
    {
        _scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints > 0) return;
        _scoreboard.IncreaseScore(score);
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
