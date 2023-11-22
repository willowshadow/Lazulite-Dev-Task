using System;
using CHARK.ScriptableEvents.Events;
using Player.Abilities;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public Canvas resultCanvas;
        public TextMeshProUGUI winnerText;
        public TransformScriptableEvent onResult;

        
        private void Awake()
        {
            onResult.AddListener(ShowResult);
        }

        private void ShowResult(Transform winner)
        {
            resultCanvas.enabled = true;
            winnerText.text = $"{winner.name} Wins!";
        }
    }
}