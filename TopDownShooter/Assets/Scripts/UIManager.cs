using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] TMPro.TMP_Text lifeText;
    [SerializeField] TMPro.TMP_Text scoreText;
    [SerializeField] PlayerBehaviour player;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lifeText.text = "Life: " + player.life.ToString();
        scoreText.text = player.score.ToString();
    }

    public void UpdateStats()
    {
        lifeText.text = "Life: " + player.life.ToString();
        scoreText.text = player.score.ToString();
    }
}
