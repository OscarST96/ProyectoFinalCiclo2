using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelCredits;
    void Start()
    {
        panelCredits.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButtons(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    public void CredistButton()
    {
        panelMenu.SetActive(false);
        panelCredits.SetActive(true);
    }
    public void BackButtons()
    {
        panelCredits.SetActive(false);
        panelMenu.SetActive(true);
    }
}
