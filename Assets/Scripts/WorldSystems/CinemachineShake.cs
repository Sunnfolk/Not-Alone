using System;
using Cinemachine;
using Player;
using UnityEngine;

namespace WorldSystems
{
    public class CinemachineShake : MonoBehaviour
    {
        public static CinemachineShake Instance { get; private set; }
        private CinemachineVirtualCamera m_Cinemachine;
        private CoyoteTime m_Coyote;
        private float m_ShakeTimer;
        

        private void Awake()
        {
            Instance = this;
            m_Cinemachine = GetComponent<CinemachineVirtualCamera>();
        }

        public void CameraShake(float intensity, float timer)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                m_Cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
            m_ShakeTimer = timer;
        }

        private void Update()
        {
            m_ShakeTimer -= Time.deltaTime;
            if (m_ShakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    m_Cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
