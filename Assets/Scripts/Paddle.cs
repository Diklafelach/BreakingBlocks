using UnityEngine;

public class Paddle : MonoBehaviour
{

    //configuration parameters
    [SerializeField] float widthScreenInUnits=16f;
    [SerializeField] float minX = 0f, maxX = 16f;

    Ball ball;
    GameState gameState;
    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameState = FindObjectOfType<GameState>();
    }
    // Update is called once per frame
    void Update()
    {
        //used in some places to represent 2D positions 
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;

       
    }
    private float GetXPos()
    {
        if (gameState.IsAutoPlayEnabled())
            return ball.transform.position.x;
        else
            return Input.mousePosition.x / Screen.width * widthScreenInUnits;
    }
}
