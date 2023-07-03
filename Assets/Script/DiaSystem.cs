using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiaSystem : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI textLabel;
    public Image faceImage;
    public Sprite Player;
    public Sprite NPC1;
    public Sprite NPC2;

    [Header("Text")]
    public TextAsset textFile;
    public int index;
    public bool textFinished;//�ж��ı��Ƿ����
    public float textSpeed = 0.2f;

    List<string> textList = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {
        GetTextFormFile(textFile);
        textFinished = true;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            if (!textFinished)
            {
                textLabel.text = textList[index];
                index++;
                textFinished = true;
            }
            else
            {
                StartCoroutine(SetTextUI());
            }


        }
    }
    private void OnEnable()
    {
        textLabel.text = textList[index];
        index++;
    }
    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
       
        var lineDate = file.text.Split(new string[]{"\n" },System.StringSplitOptions.None);

        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }
    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";


        switch (textList[index].Trim().ToString())

        {

            case "A":

                faceImage.sprite = Player;
                index++;
                break;

            case "B":

                faceImage.sprite = NPC1;
                index++;
                break;

        }
        for (int i = 0; i < textList[index].Length; i++)
        {

            textLabel.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }

        if (textFinished != true)
        {
            textFinished = true;
            index++;
        }
    }
}