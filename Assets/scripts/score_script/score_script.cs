using TMPro;
using UnityEngine;

public class score_sqript : MonoBehaviour
{
    public TextMeshProUGUI score_text;

    public static int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score_text.text = $"score: {score}";
        bullet_script.onCollisionEnemy += AddDScore;
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = $"score: {score}";
    }
    void AddDScore()
    {
        score++;
    }
    void OnDestroy()
    {
        bullet_script.onCollisionEnemy -= AddDScore;
    }

}

