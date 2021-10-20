using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    public ParticleSystem nextPlatform;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //print("Player Entered TriggerBox");
            NextPlatformParticles();
        }
    }

    private void NextPlatformParticles()
    {
        nextPlatform.Play();
    }
}