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
    

        private AudioSource m_Audio;
        private PlayerInput m_Input;
        //private PlayerWalk m_Walk;
        private PlayerColliders m_Colliders;
        private PlayerDash m_Dash;
        private CoyoteTime m_CoyoteTime;

        private bool m_CanLand;
        void Start()
        {
            m_Input = GetComponent<PlayerInput>();
            //m_Walk = GetComponent<PlayerWalk>();
            m_Colliders = GetComponent<PlayerColliders>();
            m_Dash = GetComponent<PlayerDash>();
            m_Audio = GetComponent<AudioSource>();
            m_CoyoteTime = GetComponent<CoyoteTime>();
        }

        
        void Update()
        {
            JumpAudio(); 
            LandingAudio();
            DashingAudio();
        }

        private void LandingAudio()
        {
            if (m_Colliders.IsGrounded() && m_CanLand)
            {
                m_Audio.pitch = Random.Range(0.5f, 1.5f);
                m_Audio.PlayOneShot(landing);
                m_CanLand = false;
            }
            else if (!m_Colliders.IsGrounded())
            {
                m_CanLand = true;
            }
        }
        private void JumpAudio()
        {
            if (m_Input.jump && (m_CoyoteTime.canCoyote || m_Colliders.IsGrounded()))
            {
                m_Audio.volume = 0.5f;
                m_Audio.pitch = Random.Range(0.5f, 1.5f);
                m_Audio.PlayOneShot(jump);
            
                print("jumping");
            }
        }
        /*
        private void WalkingAudio()
        {
            m_Audio.volume = 0.5f;
            m_Audio.pitch = Random.Range(0.5f, 1.5f);
            m_Audio.PlayOneShot(walk);
        }
        */

        private void DashingAudio()
        {
            if (m_Input.dash && (!m_Dash.isDashing || !m_CoyoteTime.canCoyote))
            {
                if (m_Input.moveVector == Vector2.zero) return;
                m_Audio.volume = 0.5f;
                m_Audio.pitch = Random.Range(0.5f, 1.5f);
                m_Audio.PlayOneShot(dashing);
            } 
        }
    }
}
