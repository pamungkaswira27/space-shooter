using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float transitionDuration;

    const string MENU_SCENE = "Menu";
    const string GAME_SCENE = "Gameplay";
    const string CREDIT_SCENE = "Credits";

    IEnumerator FadeScene(string sceneName)
    {
        animator.SetTrigger("Fade");
        yield return new WaitForSeconds(transitionDuration);
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMenuScene()
    {
        StartCoroutine(FadeScene(MENU_SCENE));
    }

    public void LoadGameScene()
    {
        StartCoroutine(FadeScene(GAME_SCENE));
    }

    public void LoadCreditScene()
    {
        StartCoroutine(FadeScene(CREDIT_SCENE));
    }
}
