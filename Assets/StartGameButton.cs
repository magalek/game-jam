using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    private void Start() {
        GetComponent<Button>().onClick.AddListener(LoadGameScene);
    }

    private void LoadGameScene() {
        SceneManager.LoadScene(1);
    }
}
