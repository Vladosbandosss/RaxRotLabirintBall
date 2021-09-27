using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    [SerializeField] Text myText;
    int countDoun = 100;
    bool isPlay = true;

    public void Start()
    {
        StartCoroutine(nameof(ShoutDoun));
    }

    IEnumerator ShoutDoun()
    {
        while (isPlay)
        {
            yield return new WaitForSeconds(1f);
            countDoun--;
            if (countDoun == 0)
            {
                isPlay = false;
                Debug.Log("проиграл");
                SceneManager.LoadScene("GamePlay");
            }
            myText.text = "Time left:" + countDoun;
        }
       
    }
}
