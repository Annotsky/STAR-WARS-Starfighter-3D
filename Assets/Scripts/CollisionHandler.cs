using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject destroyEffect;
    
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
