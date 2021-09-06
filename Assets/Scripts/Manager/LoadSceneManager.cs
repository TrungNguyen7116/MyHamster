using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager instance;

    public GameObject loadingPanel;

    public Image loadingBar;

    private float target;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        StartCoroutine(LoadData());
    }

    public async void LoadScene(string sceneName)
    {
        target = 0;
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        loadingPanel.SetActive(true);

        do
        {
            await Task.Delay(100);
            target = scene.progress;
        } while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
        loadingPanel.SetActive(false);
    }

    private void Update()
    {
        loadingBar.fillAmount = Mathf.MoveTowards(loadingBar.fillAmount, target, 3 * Time.deltaTime);
    }

    IEnumerator LoadData()
    {
        yield return new WaitForSeconds(1);
        LoadScene("HomeScene");
    }
}
