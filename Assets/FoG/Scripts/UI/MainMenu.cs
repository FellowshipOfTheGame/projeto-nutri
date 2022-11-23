using System;
using UnityEngine;
using UnityEngine.UI;

namespace FoG.Scripts.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] Button instructions;
        [SerializeField] Button play;
        [SerializeField] Button nutripedia;

        void Start()
        {
            play.onClick.AddListener(() => MenuController.Instance.LoadGameScene());
            instructions.onClick.AddListener(() => ChangeScreen(Screens.CharacterSelection));
            nutripedia.onClick.AddListener(() => ChangeScreen(Screens.Nutripedia));
        }

        void ChangeScreen(Screens screen)
        {
            MenuController.Instance.ChangeScreen(gameObject, screen);
        }
    }
}