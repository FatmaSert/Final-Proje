using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.sripts;
using Assets.sripts.CardLogic;
public class Card : MonoBehaviour
{
    public Sprite Icon;
    private bool isOpen;

    public CardFace CardBack;
    public CardFace CardFront;
    public GameObject CardIcon;

    public float Width;
   public float Height;

    Board BoardObj;
    public float AnimationTime = 1;
    public bool IsOpen


    {
        get { return isOpen; }

    }

    // Start is called before the first frame update
    void Start()
    {

        

        SpriteRenderer spriteRendererObj = CardIcon.GetComponent<SpriteRenderer>();
        spriteRendererObj.sprite = Icon;
        BoardObj = FindObjectOfType<Board>();


    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        OpenCard();

    }
    public void OpenCard()
    {

        if (!BoardObj.CanCardOpen())
        {
            isOpen = true;
            return;
        }

        //CardBack.SetActive(false);
        //CardFront.SetActive(true);
        //BoardObj.CardOpened(this);

        //kartýn açýlma animasyonunu saðlar.
        CardBack.Rotate(90, AnimationTime, cardBackRotated_opening);
    }
    void cardBackRotated_opening()
    {
        CardFront.Rotate(-90, AnimationTime,cardFrontRotated_opening );
    }
    public void cardFrontRotated_opening()
    {
        BoardObj.CardOpened(this);

    }
    public void CloseCard()
    {
        
        CardFront.Rotate(90, AnimationTime, cardFrontRotated_closing);
    }
    private void cardFrontRotated_closing()
    {
        CardBack.Rotate(-90, AnimationTime, cardBackRotated_closing);
    }
    private void cardBackRotated_closing()
    {
        isOpen = false;
    }
    
    

}

