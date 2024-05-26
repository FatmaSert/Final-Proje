using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.sripts
{
    public class GameManager : MonoBehaviour

    {
       
        public float totalTime = 50f; // Toplam süreyi 60 saniye olarak ayarlayın

        public TextMeshProUGUI TextTotalTime;

        public TextMeshProUGUI TextMatches;
        public TextMeshProUGUI TextAttempts;

        int matchesCount = 0;
        int attemptsCount = 0;

        bool gameOver = false;
        public bool GameOver
        { get { return gameOver; } 
        }

        void Start()
        {
            
            
                TextMatches.text = matchesCount.ToString();
                TextAttempts.text = attemptsCount.ToString();
            
        }

        private void Update()
        {

            
            if (!gameOver)
            {

                totalTime -= Time.deltaTime; // Zamanı azaltmak için Time.deltaTime kullanın
                TextTotalTime.text = ((int)totalTime).ToString();
                if (totalTime <= 0)
                {
                    Debug.Log("Süre bitti");
                    gameOver = true;
                }
            }

        }
        public void LevelCleared()
        {
            gameOver = true;
            matchesCount++;
            TextMatches.text = matchesCount.ToString();
            Debug.Log("LevelCleared fonksiyonu çağrıldı. Yeni eşleşme sayısı: " + matchesCount);
        }

        public void IncreaseAttempts()
        {
            attemptsCount++;
            TextAttempts.text = attemptsCount.ToString();
        }
        public void IncreaseMatchesCouunt()
        {
            matchesCount++;
            TextMatches.text = matchesCount.ToString();
        }
        //public void LevelCleared()
        //{
        //    gameOver = true ;
        //}



    }
}

