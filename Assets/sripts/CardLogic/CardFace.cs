using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.sripts.CardLogic
{
    public class CardFace : MonoBehaviour

    {
        
        float rotAngle;
        float animationTime;
        bool rotating;
        float elapsedTime;
        float originalAngle;
        Action cardRotated;
        public void Rotate(float angle, float animationTime, Action rotated )
        {
            cardRotated = rotated;
            originalAngle= transform.rotation.eulerAngles.y;
            rotAngle = angle;
            this.animationTime = animationTime;
            rotating = true;
            elapsedTime = 0;
        }
         void Update()
        {
            if (rotating)
            {
                elapsedTime += Time.deltaTime;
                float timePercentage = elapsedTime / animationTime;
                if (timePercentage >= 1 )
                    timePercentage = 1;

                float targetAngle = rotAngle * timePercentage+ originalAngle;
                transform.rotation = Quaternion.Euler(0, targetAngle,0);
                if (timePercentage == 1)
                {
                    rotating = false;
                    cardRotated.Invoke();
                }
            }

        }
    }


}
