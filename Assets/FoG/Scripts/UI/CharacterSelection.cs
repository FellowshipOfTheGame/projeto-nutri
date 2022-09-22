using UnityEngine;
using UnityEngine.UI;

namespace FoG.Scripts.UI
{
    public class CharacterSelection : MonoBehaviour
    {
        const string PLAYER_SELECTED_KEY = "PlayerSelect";

        [SerializeField] Button player1;
        [SerializeField] Button player2;
        [SerializeField] MenuController menuController;
        
        void Awake()
        {
            player1.onClick.AddListener(() => PlayerSelected(0));
            player2.onClick.AddListener(() => PlayerSelected(1));
        }

        void PlayerSelected(int player)
        {
            SavePlayerSelected(player);
            menuController.ChangeScreen(gameObject, Screens.Main);
        }

        void SavePlayerSelected(int player)
        {
            PlayerPrefs.SetInt(PLAYER_SELECTED_KEY, player);
        }

        public static int GetPlayerSelected()
        {
            return PlayerPrefs.GetInt(PLAYER_SELECTED_KEY, -1);
        }

        public static bool IsPlayerSelected()
        {
            var player = GetPlayerSelected();
            return player >= 0;
        }
    }
}