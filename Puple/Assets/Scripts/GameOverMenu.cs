using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        gameObject.SetActive(false);
        GameManager.Instance.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
