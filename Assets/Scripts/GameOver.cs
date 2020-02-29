using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text m_GameOverText;

    public void Execute()
    {
        StartCoroutine(waitAndDie());
    }

    private IEnumerator waitAndDie()
    {
        Text m_GameOverTextInstance = Text.Instantiate(m_GameOverText, new Vector3(230f, 400f, 0f), Quaternion.identity, GameObject.FindGameObjectWithTag("UI").transform);

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
