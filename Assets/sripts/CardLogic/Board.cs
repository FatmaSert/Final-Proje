using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;

namespace Assets.sripts.CardLogic
{
    public class Board : MonoBehaviour
    {
        public GameManager GameManagerObj;
        public Sprite[] Icons;
        public int Row;
        public int Colum;
        public Card CardPrefab;

        public Vector2 Gap;
        public Transform StartPOS;
        Card[] cards;

        Card openCard1, openCard2;
        public float CardShowTime = 2;
        bool canPlayCards = true;


        int totalCrads;

        //bool card2Opened;

        void Start()
        {
            generateBoard();
            
        }

        void Update()
        {

        }



       

        void generateBoard()
        {
            float xPos = StartPOS.position.x;
            float yPos = StartPOS.position.y;
            int cardIndex = 0;
            totalCrads = Row * Colum;
            cards = new Card[totalCrads];

            for (int i = 0; i < Row; i++)
            {
                for (int y= 0; y < Colum; y++)
                {
                    Card card = Instantiate(CardPrefab);
                    card.transform.position = new Vector3(xPos, yPos, i);
                    xPos += CardPrefab.Width + Gap.x;
                    int iconIndex = cardIndex / 2;
                    card.Icon = Icons[iconIndex];

                    cards[cardIndex] = card;
                    cardIndex++;
                }
                yPos += CardPrefab.Height + Gap.y;
                xPos = StartPOS.position.x;
            }
            ramdomizeCards();
        }

        void ramdomizeCards()
        {
            for (int i = cards.Length - 1; i > 0; i--)
            {
                Card card = cards[i];
                int otherCardIndex = UnityEngine.Random.Range(0, i);
                Card otherCard = cards[otherCardIndex];
                Vector3 temPos = card.transform.position;
                card.transform.position = otherCard.transform.position;
                otherCard.transform.position = temPos;
            }
        }
        public void CardOpened(Card card)
        {
            if (openCard1 == null)

                openCard1 = card;

            else
            {
                openCard2 = card;
                //card2Opened = true;
                StartCoroutine(CheckForMatch());
            }
        }
        IEnumerator CheckForMatch()
        {
            Debug.Log("CheckForMatch fonksiyonu çağrıldı.");
            canPlayCards = false;
            yield return new WaitForSeconds(CardShowTime);
            canPlayCards = true;
            if (openCard1.Icon == openCard2.Icon)
            {
                totalCrads -= 2;
                Debug.Log("EŞLEŞME var");
                GameManagerObj.IncreaseMatchesCouunt();
                Destroy(openCard1.gameObject);
                Destroy(openCard2.gameObject);

                if (totalCrads == 0)
                    GameManagerObj.LevelCleared();
            }
            else
            {
                Debug.Log("EŞLEŞME YOK");
                GameManagerObj.IncreaseAttempts();
                openCard1.CloseCard();
                openCard2.CloseCard();
            }
            openCard1 = null;
            openCard2 = null;
        }
        // IEnumerator  CheckForMatch()
        //{
        //    canPlayCards = false;
        //    yield return new WaitForSeconds(CardShowTime);
        //    canPlayCards = true;
        //    if (openCard1.Icon == openCard2.Icon)
        //    {
        //        totalCrads -= 2;
        //        Debug.Log("EŞLEŞME var");
        //        Destroy(openCard1.gameObject);
        //        Destroy(openCard2.gameObject);

        //        if (totalCrads == 0)
        //            GameManagerObj.LevelCleared();
        //    }
        //    else
        //    {
        //        Debug.Log("EŞLEŞME YOK");
        //        openCard1.CloseCard();
        //        openCard2.CloseCard();
        //    }
        //    openCard1 = null;
        //    openCard2 = null;
        //}
        public bool CanCardOpen()
        {
            return canPlayCards && GameManagerObj.GameOver == false;
        }

    }
}
    

