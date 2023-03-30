using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.name == "Ball")
        {
            string wallName = transform.name;
            GameManager gameManager = GameManager.instance;

            //memanggil method Score di GameManager.cs
            gameManager.Score(wallName);


            if (gameManager.PlayerScoreL != gameManager.WinScore && gameManager.PlayerScoreR != gameManager.WinScore)
            {
                //memanggil method RestartGame() di BallControl.cs
                hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
            }
            else
            {
                gameManager.BallControl.ResetBall();
            }

        }
    }
}