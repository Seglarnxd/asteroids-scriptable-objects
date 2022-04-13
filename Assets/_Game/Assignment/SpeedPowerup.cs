using DefaultNamespace.ScriptableEvents;
using UnityEngine;
using Variables;

public class SpeedPowerup : MonoBehaviour
{
    [SerializeField] ScriptableEventFloat speedEvent;
    [SerializeField] private FloatVariable speedMultiplier;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            speedEvent.Raise(speedMultiplier.Value);
            Destroy(gameObject);
        }
    }
}
