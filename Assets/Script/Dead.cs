using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dead : MonoBehaviour
{
    public bool isDie = false;
    public TMP_Text liveText;
    public GameObject retryButton;

    private void Start()
    {
        retryButton.SetActive(false);
    }

    private void Update()
    {
        if (isDie)
        {
            ShowRetryButton();
        }
    }

    void ShowRetryButton()
    {
        retryButton.SetActive(true);
    }

    public void RetryButtonClicked()
    {
        Debug.Log("Retry button clicked!");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        isDie = false;
    }
}
