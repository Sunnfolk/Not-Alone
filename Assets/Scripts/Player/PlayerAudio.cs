using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerWalk))]
    [RequireComponent(typeof(PlayerColliders))]
    [RequireComponent(typeof(PlayerDash))]
    [RequireComponent(typeof(CoyoteTime))]
    public class PlayerAudio : MonoBehaviour
    {
        public AudioClip jump;
        public AudioClip walk;
        public AudioClip landing;
        public AudioClip dashing;
        public AudioClip attacking;
        public AudioClip hit;

        private AudioSource m_Audio;
        
        private void Awake()
        {
            m_Audio = GetComponent<AudioSource>();
        }

        public void LandingAudio()
        {
            m_Audio.pitch = Random.Range(0.5f, 1.5f);
            m_Audio.PlayOneShot(landing);
        }
        public void JumpAudio()
        {
            m_Audio.pitch = Random.Range(0.5f, 1.5f);
            m_Audio.PlayOneShot(jump);
        }
        
        public void WalkingAudio()
        {
            m_Audio.pitch = Random.Range(0.5f, 1.5f);
            m_Audio.PlayOneShot(walk);
        }
        

        public void DashingAudio()
        {
            m_Audio.pitch = Random.Range(0.5f, 1.5f);
            m_Audio.PlayOneShot(dashing);
        }

        public void AttackingAudio()
        {
            m_Audio.pitch = Random.Range(0.5f, 1.5f);
            m_Audio.PlayOneShot(attacking);
        }

        public void GettingHit()
        {
            m_Audio.pitch = Random.Range(0.5f, 1.5f);
            m_Audio.PlayOneShot(hit);
        }
    }
}
