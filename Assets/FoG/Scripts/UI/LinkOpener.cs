using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FoG.Scripts.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class LinkOpener : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] Camera _camera;
        TMP_Text _textMeshPro;

        void Awake()
        {
            _textMeshPro = GetComponent<TMP_Text>();
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            int linkIndex =
                TMP_TextUtilities.FindIntersectingLink(_textMeshPro, eventData.position, _camera);
            
            if (linkIndex != -1) { // was a link clicked?
                TMP_LinkInfo linkInfo = _textMeshPro.textInfo.linkInfo[linkIndex];
                Application.OpenURL(linkInfo.GetLinkID());
            }
        }
    }
}