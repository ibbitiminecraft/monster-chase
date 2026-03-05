using TMPro;
using UnityEngine;
using System;
public class lives_manager_script : MonoBehaviour
{
    public static int lives = 3;
    public TextMeshProUGUI life_text;
    public static event Action IfLives0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        life_text.text = $"lives: {lives}";
        player_script.onPlayerCollidesWithEnemy += Decreaselifes;
    }


    // Update is called once per frame
    void Update()
    {
        life_text.text = $"lives: {lives}";
    }
    void Decreaselifes()
    {
        lives--;
        if (lives <= 0)
        {
            IfLives0?.Invoke();
        }
    }
    void OnDestroy()
    {
        player_script.onPlayerCollidesWithEnemy -= Decreaselifes;
    }
    
}
