using System;
using CHARK.ScriptableEvents.Events;
using Cinemachine;
using UnityEngine;

namespace Utils
{
    public class WinCameraUtils : MonoBehaviour
    {
        public TransformScriptableEvent onPlayerBroadcast;
        public new CinemachineVirtualCamera camera;
        private void Awake()
        {
            onPlayerBroadcast.AddListener(OnPlayerBroadcast);
        }

        public void OnPlayerBroadcast(Transform player)
        {
            CinemachineBrain.SoloCamera = camera;
            camera.Priority = 100;
            camera.Follow = player;
            camera.LookAt = player;
        }
    }
}