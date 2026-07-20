using UnityEngine;

public class Brick : MonoBehaviour
{

    [SerializeField] private int hitPoints = 1;
    [SerializeField] private int score = 100;
    [SerializeField] private bool indestructible;

    public void TakeHit()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            DestroyBrick();
        }
    }

    private void DestroyBrick()
    {
        Destroy(gameObject);
    }
}
