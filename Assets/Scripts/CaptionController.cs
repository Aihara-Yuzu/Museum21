using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CaptionController : MonoBehaviour
{
    public AudioManager audioManager;
    public TextMeshProUGUI textLabel;
    public TextAsset textFile;
    List<string> textList = new List<string>();
    public float textSpeed = 0.2f;
    public int index;
    public string nowPlayingAudioName;
    public string previousAudioName;

    public float timer = 0f;

    void Awake()
    {
        previousAudioName = "";
        GetTextFormFile(textFile);
        index = 1;
    }
    void Update()
    {
        nowPlayingAudioName = audioManager.NowPlayingAudioName;
        if(previousAudioName != nowPlayingAudioName){
            CheckForUpadate();
            previousAudioName = nowPlayingAudioName;
        }
        else{
            textLabel.text = textList[index];
            timer += Time.deltaTime;
            if(timer > textSpeed * textList[index].Length){
                if(!textList[index+1].Contains(":"))
                    index++;
                timer = 0f;
            }
        }

        if(nowPlayingAudioName == "null"){
            textLabel.text = "";
            timer = 0;
        }
            
    }

    void CheckForUpadate()
    {
        for(int i = 0; i < textList.Count; i++)
        {
            if(textList[i].Contains(nowPlayingAudioName + ':')){
                index = i+1;
            }
        }
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
}
