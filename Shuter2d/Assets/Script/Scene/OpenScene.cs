using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Открытие сцены
/// </summary>
public class OpenScene : MonoBehaviour
{
    public int NumberScene;

    /// <summary>
    /// Открывает сцену по ее номеру
    /// </summary>
    public void Open()
    {
        SceneManager.LoadScene(NumberScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
