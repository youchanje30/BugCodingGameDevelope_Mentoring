using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private Text scoreText;
    

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.GetScore().ToString("0000");
    }
}
