using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;

    public PlayerController player;
    public Transform checkpoint;

    void Start()
    {
        scoreText.text = "score: 0";
        lifeText.text = "life :" + player.Life;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SavePosition()
    {
        PlayerPrefs.SetFloat("positionX", checkpoint.position.x);
        PlayerPrefs.SetFloat("positionY", checkpoint.position.y);
        PlayerPrefs.SetFloat("positionZ", checkpoint.position.z);
    }
}
