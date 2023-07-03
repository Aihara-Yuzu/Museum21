using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public GameObject SpotLight;
    public float SpotLightZOffset;
    [Header("Dialogue")]
    public bool inDialogue = false;
    public int NowDialogueIndex;
    public int NowDialogueTime;
    public DialogueController dialogueController;

    [Header("Camera")]
    public Camera _camera;
    public float cameraSpeed = 5f;
    [SerializeField]
    private GameObject[] camTargetPosition;
    public float[] radius;

    public int[] ObjectRound; 
    private Vector3 camPosition;
    private bool readyToDialogue = false;
    private bool firstDialogue = false;
    private float _zero = 0.01f;

    // shake camera
    public void ShakeCamera(float duration, float magnitude){
        StartCoroutine(Shake(duration, magnitude));
    }

    IEnumerator Shake(float duration, float magnitude){
        Vector3 originalPosition = _camera.transform.localPosition;
        float elapsed = 0f;
        while(elapsed < duration){
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            _camera.transform.localPosition = new Vector3(x, y, originalPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        _camera.transform.localPosition = originalPosition;
    }

    private void Awake()
    {
        SpotLightZOffset = SpotLight.transform.position.z - _camera.transform.position.z;
    }
    private void Start()
    {
        camPosition = new Vector3();
    }
    private void Update()
    {
        if(firstDialogue){
            SpotLight.transform.position = _camera.gameObject.transform.position + new Vector3(0, 0, SpotLightZOffset);
        }
        if(inDialogue){
            if(Dialoging(NowDialogueIndex)){
                inDialogue = false;
                Debug.Log("Stop Dialogue");
            }
            return;
        }

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        camPosition.x=_camera.transform.position.x + inputX * cameraSpeed * Time.deltaTime;
        camPosition.y=_camera.transform.position.y + inputY * cameraSpeed * Time.deltaTime;
        camPosition.z = _camera.transform.position.z;

        if(camPosition.y > 2.5f)
            camPosition.y = 2.5f;
        if(camPosition.y < -2f)
            camPosition.y = -2f;
        if(camPosition.x > 4.6f)
            camPosition.x = 4.6f;
        if(camPosition.x < -3.3f)
            camPosition.x = -3.3f;

        _camera.transform.position = camPosition;

        _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, gameObject.transform.rotation, 0.1f);

        for(int i = 0; i < camTargetPosition.Length; i++)
        {
            if (Vector3.Distance(_camera.transform.position, camTargetPosition[i].gameObject.transform.position) < radius[i] && inputX <= _zero && inputY <= _zero)
            {
                // wait 2 seconds then ready to dialogue(freeze the camera position)
                if (readyToDialogue == false)
                {
                    readyToDialogue = true;
                    Debug.Log("Ready to dialogue...");
                    NowDialogueIndex = i;
                    NowDialogueTime = ObjectRound[i]+1;
                    StartCoroutine(WaitForDialogue(NowDialogueIndex));
                }
            }
        }

        if(readyToDialogue && (inputX > _zero || inputY > _zero)){
            StopAllCoroutines();
            readyToDialogue = false;
            inDialogue = false;
            Debug.Log("Stop Dialogue Cause Player Move.");
        }

    }

    IEnumerator WaitForDialogue(int index)
    {
        yield return new WaitForSeconds(1f);
        StartDialogue(index);
        if(!firstDialogue)
            firstDialogue = true;
    }

    void StartDialogue(int index){
        // start dialogue
        if(!inDialogue){
            inDialogue = true;
            Debug.Log("Start Dialogue");
            Debug.Log(new Vector2(index, ObjectRound[index]));
        }
    }

    bool Dialoging(int index){
        CameraShake();
        CameraRotate();
        if(dialogueController.DialogueUpdate(index, ObjectRound[index]+1))
        {
            Debug.Log("End Dialogue");
            ObjectRound[index] ++;
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < camTargetPosition.Length; i++)
        {
            Gizmos.DrawWireSphere(camTargetPosition[i].gameObject.transform.position, radius[i]);
        }
    }

    void CameraRotate(){
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        if (inputX > _zero)
        {
            _camera.transform.RotateAround(_camera.transform.position, Vector3.up, 0.5f);
        }
        else if (inputX < -_zero)
        {
            _camera.transform.RotateAround(_camera.transform.position, Vector3.up, -0.5f);
        }
        else if (inputY > _zero)
        {
            _camera.transform.RotateAround(_camera.transform.position, Vector3.right, -0.5f);
        }
        else if (inputY < -_zero)
        {
            _camera.transform.RotateAround(_camera.transform.position, Vector3.right, 0.5f);
        }
        else{
            // lerp to original position
            _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, gameObject.transform.rotation, 0.1f);
        }
    }
    
    bool waitSPressed = false;
    bool waitDPressed = false;
    void CameraShake()
    {
        // if player press w then press s during 0.2s
        if (Input.GetKeyDown(KeyCode.W))
        {
            waitSPressed = true;
            StartCoroutine(WaitSPressed());
        }
        if(waitSPressed){
            if (Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine(NodingUpandDown(0.2f, 0.1f));
            }
        }

        // if player press a then press d, the camera will shake left and right
        if (Input.GetKeyDown(KeyCode.A))
        {
            waitDPressed = true;
            StartCoroutine(WaitDPressed());
        }
        if(waitDPressed){
            if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(ShakingLeftandRight(0.2f, 0.1f));
            }
        }
    }

    IEnumerator WaitSPressed()
    {
        yield return new WaitForSeconds(0.2f);
        waitSPressed = false;
    }

    IEnumerator WaitDPressed()
    {
        yield return new WaitForSeconds(0.2f);
        waitDPressed = false;
    }

    IEnumerator NodingUpandDown(float duration, float magnitude)
    {
        // using Rotate to nodding
        dialogueController.NoddingPressed = true;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            _camera.transform.Rotate(1, 0, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
        elapsed = 0f;
        while (elapsed < duration)
        {
            _camera.transform.Rotate(-1, 0, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
        dialogueController.NoddingPressed = false;
    }

    IEnumerator ShakingLeftandRight(float duration, float magnitude)
    {
        // using Rotate to shaking
        dialogueController.ShakingHeadPressed = true;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            _camera.transform.Rotate(0, -1, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
        elapsed = 0f;
        while (elapsed < duration)
        {
            _camera.transform.Rotate(0, 2, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
        elapsed = 0f;
        while (elapsed < duration)
        {
            _camera.transform.Rotate(0, -1, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
        dialogueController.ShakingHeadPressed = false;
    }
}