using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace FoG.Scripts.UI
{
    public class FoodScrollViewer : MonoBehaviour, ISerializationCallbackReceiver
    {
        [SerializeField] ScrollRect _scrollRect;
        [SerializeField] GameObject _cellPrefab;

        readonly List<FoodCell> _cells = new List<FoodCell>();
        
        public void OnBeforeSerialize()
        {
            if (_cellPrefab != null && !(_cellPrefab.GetComponent<FoodCell>() is { }))
            {
                Debug.LogError("CellPrefab must have a FoodCell component attached the Object root.");
            }
        }

        public void OnAfterDeserialize()
        {
        }

        public void Refresh(List<Food> foods, Color bgColor)
        {
            if (foods == null)
            {
                gameObject.SetActive(false);
                return;
            }
            
            gameObject.SetActive(true);
            
            CreateCells(foods.Count - _cells.Count);

            for (var i = 0; i < _cells.Count; ++i)
            {
                _cells[i].Refresh(foods.ElementAtOrDefault(i), bgColor);
            }
        }

        void CreateCells(int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                GameObject instance = Instantiate(_cellPrefab, _scrollRect.content);
                var foodCell = instance.GetComponent<FoodCell>();

                if (foodCell is { })
                {
                    _cells.Add(foodCell);
                }
            }
        }
    }
}