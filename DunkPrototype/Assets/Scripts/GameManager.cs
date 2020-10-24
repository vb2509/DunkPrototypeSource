using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int direction = 1;
    public static int score = 0;

    // Start is called before the first frame update
    public static void FlipDirection()
    {
        direction *= -1;
        print("flipped " + direction);
    }
}
