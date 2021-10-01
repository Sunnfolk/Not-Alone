using UnityEngine;
using Random = UnityEngine.Random;

public class BossAudio : MonoBehaviour
{
    private AudioSource m_Audio;
    
    public AudioClip spikeAppear;

    public AudioClip bossFootstep;
    public AudioClip bite;
    public AudioClip slam;

    public AudioClip bossAppear;
    public AudioClip bossDeath;

    private void Start()
    {
        m_Audio = GetComponent<AudioSource>();
    }

    public void SpikeAppearSound()
    {
        m_Audio.pitch = Random.Range(0.5f, 1.5f);
        m_Audio.PlayOneShot(spikeAppear);
    }

    public void BossFootStepSound()
    {
        m_Audio.pitch = Random.Range(0.5f, 1.5f);
        m_Audio.PlayOneShot(bossFootstep);
    }

    public void BiteSound()
    {
        m_Audio.pitch = Random.Range(0.5f, 1.5f);
        m_Audio.PlayOneShot(bite);
    }

    public void SlamSound()
    {
        m_Audio.pitch = Random.Range(0.5f, 1.5f);
        m_Audio.PlayOneShot(slam);
    }

    public void BossAppearSound()
    {
        m_Audio.PlayOneShot(bossAppear);
    }
    public void BossDeathSound()
    {
        m_Audio.PlayOneShot(bossDeath);
    }
}
