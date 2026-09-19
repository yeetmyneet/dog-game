using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TennisBallDetection : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] bool isLastLevel = false;
    [SerializeField] float ballCount;
    [SerializeField] float fpsCount = 60;
    [SerializeField] TextMeshProUGUI myText;
    [SerializeField] TextMeshProUGUI fpsCounter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Tennis Ball")
        {
            ballCount += 1;
            fpsCount += 71;
            fpsCounter.text = "fps count: " + fpsCount;
            myText.text = "tennis balls: " + ballCount;
            Destroy(other.gameObject);
        }

        if (other.tag == "tennis balrp")
        {
            ballCount += 1;
            fpsCount -= 10;
            fpsCounter.text = "fps count: " + fpsCount;
            myText.text = "tennis balls: " + ballCount;
            Destroy(other.gameObject);
        }

        if (other.tag == "ten ball")
        {
            Time.timeScale = 0;
            ballCount += 1;
            fpsCount = -35;
            fpsCounter.text = "fps count: " + fpsCount;
            myText.text = "tennis balls: " + ballCount;
            Destroy(other.gameObject);
            StartCoroutine(LoadNextLevel1());
        }

        if (other.tag == "minus fps")
        {
            fpsCount -= 2;
            fpsCounter.text = "fps count: " + fpsCount;
            Destroy(other.gameObject);
        }

        if (other.tag == "low fps")
        {
            fpsCount -= 4;
            fpsCounter.text = "fps count: " + fpsCount;
            Destroy(other.gameObject);
        }

        if (other.tag == "positive fps")
        {
            fpsCount += 3;
            fpsCounter.text = "fps count: " + fpsCount;
            Destroy(other.gameObject);
        }

        if (other.tag == "great fps")
        {
            fpsCount += 7;
            fpsCounter.text = "fps count: " + fpsCount;
            Destroy(other.gameObject);
        }

        if (other.tag == "starter fps")
        {
            fpsCount += 60;
            fpsCounter.text = "fps count: " + fpsCount;
            Destroy(other.gameObject);
        }
    }

    IEnumerator LoadNextLevel1()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (isLastLevel == true)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
