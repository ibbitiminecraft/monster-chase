using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIscript : MonoBehaviour
{

    public TextMeshProUGUI score_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score_text.text = "score:" + score_sqript.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void replay_game()
    {
        lives_manager_script.lives = 3;
        score_sqript.score = 0;
        SceneManager.LoadScene("SampleScene");
    }
    
}
