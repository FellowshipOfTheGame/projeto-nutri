using System;
using UnityEngine;
using UnityEngine.UI;

namespace FoG.Scripts.UI
{
    public class ConfirmationPopup : MonoBehaviour
    {
        [SerializeField] Button _confirmButton;
        [SerializeField] Button _cancelButton;

        Action<bool> _callback;

        void Awake()
        {
            _confirmButton.onClick.AddListener(() => OnButtonClick(true));
            _cancelButton.onClick.AddListener(() => OnButtonClick(false));
        }

        public void Open(Action<bool> callback)
        {
            _callback = callback;
            gameObject.SetActive(true);
        }

        void OnButtonClick(bool confirmation)
        {
            gameObject.SetActive(false);
            
            _callback?.Invoke(confirmation);
            _callback = null;
        }
    }
}