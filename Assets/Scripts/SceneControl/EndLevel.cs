using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    public Text m_WinText;
    public string m_ChangeSceneTo;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.GetComponent<PlayerMovement>().DisableControls();
            StartCoroutine(waitAndWin());
        }
    }

    private IEnumerator waitAndWin()
    {
        Text m_WinTextInstance = Text.Instantiate(m_WinText, new Vector3(460f, 400f, 0f), Quaternion.identity, GameObject.FindGameObjectWithTag("UI").transform);

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(m_ChangeSceneTo);
    }
}
