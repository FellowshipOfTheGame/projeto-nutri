using UnityEngine;

namespace FoG.Scripts.UI
{
    [CreateAssetMenu(menuName = "Nutripedia/PostIt")]
    public class PostItDataSO : ScriptableObject
    {
        public Sprite ButtonImage;

        [TextArea] public string Description;
    }
}