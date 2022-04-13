using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FinishLineZoneScript : MonoBehaviour
{
    [SerializeField] Sprite closedHoodSprite;
    [SerializeField] Sprite openedHoodSprite;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log("Sprite renderer variable: " + spriteRenderer);
        CloseHood();
    }

    public void CloseHood()
    {
        spriteRenderer.sprite = closedHoodSprite;
    }

    public void OpenHood()
    {
        spriteRenderer.sprite = openedHoodSprite;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        /*if (other.gameObject.tag == "Player")
        {
            Debug.Log("OK - Player + Finish Zone");
            gpKart = goPlayer.GetComponent<playerStats>().hasKart;
            kartLevel = goPlayer.GetComponent<playerStats>().GetKartLevel();
            if (gpKart == true &&  kartLevel >= 4)
            {
                goPlayer.GetComponent<playerStats>().hasKart = false;
                goPlayer.GetComponent<playerStats>().SetKartLevel(0);
            }
        }*/
    }


}
