using UnityEngine;

namespace FoG.Scripts
{
    public abstract class Food : ScriptableObject
    {
        public string Name;
        public string Description;
        
        public Sprite Image;
    }
}