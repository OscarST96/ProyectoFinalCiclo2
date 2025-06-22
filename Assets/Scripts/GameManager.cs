using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;

    public PlayerController player;

    void Start()
    {
        scoreText.text = "score: 500";
        lifeText.text = "life :" + player.life;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
