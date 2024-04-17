using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public bool isInRange;
    public int heart = 1;
    public GameObject retryButton;

    public AudioSource music;


    private void Start()
    {
        Time.timeScale = 1;
        retryButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isInRange = true;
            heart--;
            if (heart == 0)
            {
                Time.timeScale = 0;
                Debug.Log("perdu");
                ShowRetryButton();
                music.Stop();
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isInRange = false;
        }   
    }

    void ShowRetryButton()
    {
        retryButton.SetActive(true); // Activer le bouton Retry
    }
}
