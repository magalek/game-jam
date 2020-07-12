using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    private void Awake() {
        GetComponent<Button>().onClick.AddListener(LoadGameScene);
    }

    public void LoadGameScene() {
        SceneManager.LoadScene(4);
    }
}
