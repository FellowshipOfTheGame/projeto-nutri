using System;
using System.Collections.Generic;
using UnityEngine;

namespace FoG.Scripts.UI
{
    [CreateAssetMenu(menuName = "Nutripedia/Page")]
    public class PageData : ScriptableObject
    {
        [Header("Left side")]
        public string Title;
        [TextArea] public string LeftText;
        public PostItData PostIt;
        
        [Header("Right side")] 
        public List<Food> FoodList;
        public Color FoodBackgroundColor;
        [TextArea] public string RightText;
    }
    
    [Serializable]
    public class PostItData
    {
        public Sprite ButtonImage;

        [TextArea] public string Description;
    }
}