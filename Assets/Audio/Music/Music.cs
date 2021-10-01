using UnityEngine;

namespace Audio.Music
{
    public class Music : MonoBehaviour
    {
        public AudioClip music;
        private AudioSource m_Audio;
    
        private void Start()
        {
            m_Audio = GetComponent<AudioSource>();
            m_Audio.PlayOneShot(music);
        }
    }
}
