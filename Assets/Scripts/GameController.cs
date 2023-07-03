using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public AudioSource gameOverAudioSource;
    public float RebelScore = 0;
    public float RebelScoreMax = 10;
    public bool isGameStarted = false;
    public CanvasGroup startCanvasGroup;
    public CanvasGroup BlackCanvasGroup;
    public GameObject mainCamera;
    public Transform mainCameraTarget;

    public CameraController cameraController;
    public DialogueController dialogueController;

    public GameObject floatingCaption;

    public bool isDialogueEnded = false;

    private bool isAnyKeyDowned = false;

    // Start is called before the first frame update
    void Start()
    {
        // lerp alpha to 1 of BlackCanvasGroup
        StartCoroutine(FadeOut(BlackCanvasGroup, 6f));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && !isAnyKeyDowned){
            isAnyKeyDowned = true;
            // lerp alpha to 0 during 1 second
            StartCoroutine(FadeOut(startCanvasGroup, 1f));
            // move the main camera to the target position during 1 second
            StartCoroutine(MoveTo(mainCamera, mainCameraTarget.position, 1f));
        }
        if(RebelScore > RebelScoreMax && cameraController.inDialogue == false)
        {
            // CameraShake
            cameraController.ShakeCamera(5f, 0.1f);
            isDialogueEnded = true;
            if(dialogueController.DialogueUpdate(-1, 1)){
                // Fade in the black canvas group
                StartCoroutine(FadeIn(BlackCanvasGroup, 1f));
                StartCoroutine(FloatingText(floatingCaption, 25f));
                // play the game over sound
                if(!gameOverAudioSource.isPlaying) 
                {
                    gameOverAudioSource.Play();
                }
            }
            
        }
    }

    void GameOver()
    {
        BlackCanvasGroup.alpha = 1;
        if(dialogueController.DialogueUpdate(-1, 2)){
            // Reload the scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator FloatingText(GameObject text, float duration)
    {
        float counter = 0;
        while(counter < duration)
        {
            counter += Time.deltaTime;
            text.GetComponent<RectTransform>().localPosition = Vector3.Lerp(new Vector3(0, -3740, 0), new Vector3(0, 3670, 0), counter / duration);
            yield return null;
        }
        GameOver();
    }

    IEnumerator FadeIn(CanvasGroup cg, float duration)
    {
        float counter = 0;
        while(counter < duration)
        {
            counter += Time.deltaTime;
            cg.alpha = Mathf.Lerp(0, 1, counter / duration);
            yield return null;
        }
    }

    IEnumerator FadeOut(CanvasGroup cg, float duration)
    {
        float counter = 0;
        while(counter < duration)
        {
            counter += Time.deltaTime;
            cg.alpha = Mathf.Lerp(1, 0, counter / duration);
            yield return null;
        }
    }

    IEnumerator MoveTo(GameObject obj, Vector3 target, float duration)
    {
        float counter = 0;
        Vector3 startPos = obj.transform.position;
        while(counter < duration)
        {
            counter += Time.deltaTime;
            obj.transform.position = Vector3.Lerp(startPos, target, counter / duration);
            yield return null;
            isGameStarted = true;
        }
    }
}
