using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    private float maxVol = .4f;
    private float fadeSpeed = .4f;

    public AudioClip[] clips;

    public AudioSource[] audioSources;

    private int trackIndex = 0;

    public Image backgroundFade;

    private void Awake()
    {
        if (FindObjectsOfType<TransitionManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            audioSources = GetComponents<AudioSource>();
        }

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopAllCoroutines();
        StartCoroutine(FadeMusic(audioSources[trackIndex], audioSources[trackIndex = 1 - trackIndex], scene.buildIndex));
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(.2f);
        backgroundFade.CrossFadeAlpha(0, .6f, true);
        yield return new WaitForSeconds(.6f);
        backgroundFade.gameObject.SetActive(false);
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeAndLoad(sceneName));
    }

    private IEnumerator FadeAndLoad(string sceneName)
    {
        backgroundFade.gameObject.SetActive(true);
        backgroundFade.canvasRenderer.SetAlpha(0);
        backgroundFade.CrossFadeAlpha(1, .6f, true);
        yield return new WaitForSeconds(.6f);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeMusic(AudioSource fadeIn, AudioSource fadeOut, int buildIndex)
    {
        fadeIn.clip = clips[buildIndex];
        fadeIn.Play();

        float t = 0;
        while (t < 1)
        {
            fadeIn.volume = Mathf.SmoothStep(0, maxVol, t);
            fadeOut.volume = Mathf.SmoothStep(maxVol, 0, t);
            t += Time.deltaTime * fadeSpeed;
            yield return null;
        }
        fadeOut.Stop();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}