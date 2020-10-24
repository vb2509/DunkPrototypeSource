using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

[RequireComponent(typeof(BoxCollider2D))]
public class Basket : MonoBehaviour
{
    public Vector2 horizontal = new Vector2(-500, 500); //The lowest and highest coordinate values in the X axis value is picked based on direction
    public Vector2 vertical = new Vector2(-500, 500);   //The lowest and highest coordinate values in the Y axis value picked randomly between the 2 values
    [SerializeField]
    TextMeshProUGUI scoreBoard;                         //reference to the scorboard in the UI

    private void Start()
    {
        CheckRotation();
        UpdateScore();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            if (transform.position.y < collision.transform.position.y)
            {
                print("true");
                GameManager.FlipDirection();
                GameManager.score += 1;
                UpdateScore();
                StartCoroutine(WaitTime(0.5f));
            }
            else
            {
                print("false");
            }
        }
    }

    void CheckRotation()    //Checks for the direction of the basket based on the game manager values, flips the object on the y axis depending on direction and sets new position
    {
        if (GameManager.direction == -1)
        {
            transform.eulerAngles = new Vector2(0, 180);
            transform.position = new Vector2(horizontal.x,Random.Range(vertical.x, vertical.y));
        }
        else
        {
            transform.eulerAngles = Vector2.zero;
            transform.position = new Vector2(horizontal.y, Random.Range(vertical.x, vertical.y));
        }
    }
    void UpdateScore()  //Sets the score value to the text UI
    {
        StringBuilder builder = new StringBuilder();

        if (scoreBoard)
        {
            scoreBoard.text = builder.Append("Score " ).Append(GameManager.score.ToString()).ToString();
        }
    }
    IEnumerator WaitTime(float duration)    //The basket position is updated after a delay which happens here
    {
        yield return new WaitForSeconds(duration);
        CheckRotation();
    }
}
