using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TMPro.TMP_InputField usernameText;

    public void PlayGame() {
        PersistanceManager.Instance.username = usernameText.text;
        Debug.Log(PersistanceManager.Instance.username);
        SceneManager.LoadScene(1);
    }
}
