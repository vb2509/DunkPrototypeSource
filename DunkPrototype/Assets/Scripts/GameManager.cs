using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int direction = 1;
    public static int score = 0;

    public static void FlipDirection()  //Flips the global direction which affects the position of the basket on left and right and the movement direction of the ball
    {
        direction *= -1;
        print("flipped " + direction);
    }
}
