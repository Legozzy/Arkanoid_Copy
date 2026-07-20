using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreTextMesh;
    [SerializeField] private TextMeshProUGUI topScoreTextMesh;


    private void Update()
    {
        UpdateStatsTextMesh();
    }

    private void UpdateStatsTextMesh()
    {
        scoreTextMesh.text = "Score: " + GameManager.Instance.GetScore().ToString();
    }

}
