using UnityEngine;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private Brick brickPrefab;
    [SerializeField] private Transform bricksParent;

    private int row = 2;
    private int column = 4;

    private float brickWidth;
    private float brickHeight;

    private float spacingX = 0.1f;
    private float spacingY = 0.1f;


    private void Awake()
    {
        BoxCollider2D collider = brickPrefab.GetComponent<BoxCollider2D>();

        brickWidth = collider.size.x;
        brickHeight = collider.size.y;
    }

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                Vector2 position = GetBrickPosition(i, j);

                CreateBrick(position);
            }
        }
    }

    private void CreateBrick(Vector2 position)
    {
        Instantiate(brickPrefab, position, Quaternion.identity, bricksParent);
    }

    private Vector2 GetBrickPosition(int row, int column)
    {

        float x = (brickWidth + spacingX) * column;
        float y = (brickHeight + spacingY) * row;

        Vector2 position = new Vector2(x, y);

        Debug.Log("Brick Width: " + brickWidth);
        Debug.Log("Brick Height: " + brickHeight);
        Debug.Log("Row: " + row);
        Debug.Log("Column: " + column);
        Debug.Log("X: " + x);
        Debug.Log("Y: " + y);
        Debug.Log("Position: " + position);

        return position;
    }

}
