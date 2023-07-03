using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public CaptionController captionController;
    public string NowPlayingAudioName = "null";
    public bool[,] myaudiosPlayedArray = new bool[20, 100];

    //HashMap<string, AudioClip> audioClipsMap = new HashMap<string, AudioClip>();

    [Header("Audio Clips")]
    [Header("Introduction")]
    public AudioClip[] audioClipsIntroduction;
    [Header("Object1")]
    public AudioClip[] audioClipsObjects1;
    [Header("Object2")]
    public AudioClip[] audioClipsObjects2;
    [Header("Object3")]
    public AudioClip[] audioClipsObjects3;
    [Header("Object4")]
    public AudioClip[] audioClipsObjects4;
    [Header("Object5")]
    public AudioClip[] audioClipsObjects5;
    [Header("Object6")]
    public AudioClip[] audioClipsObjects6;
    [Header("Object7")]
    public AudioClip[] audioClipsObjects7;
    [Header("Object8")]
    public AudioClip[] audioClipsObjects8;
    [Header("Object9")]
    public AudioClip[] audioClipsObjects9;
    [Header("Object10")]
    public AudioClip[] audioClipsObjects10;
    [Header("Object11")]
    public AudioClip[] audioClipsObjects11;
    [Header("Rebel")]
    public AudioClip[] audioClipsRebel;
    [Header("Fiveround_1")]
    public AudioClip[] audioFiveround;

    public Dictionary<string, int> hashMapIntroduction = new Dictionary<string, int>();
    public Dictionary<string, int> hashMapObjects1 = new Dictionary<string, int>();
    public Dictionary<string, int> hashMapObjects2 = new Dictionary<string, int>();
    public Dictionary<string, int> hashMapObjects3 = new Dictionary<string, int>();
    public Dictionary<string, int> hashMapObjects4 = new Dictionary<string, int>();
    public Dictionary<string, int> hashMapObjects5 = new Dictionary<string, int>();
    public Dictionary<string, int> hashMapObjects6 = new Dictionary<string, int>();
    public Dictionary<string, int> hashMapObjects7 = new Dictionary<string, int>();
    public Dictionary<string, int> hashMapObjects8 = new Dictionary<string, int>();
    public Dictionary<string, int> hashMapObjects9 = new Dictionary<string, int>();
    public Dictionary<string, int> hashMapObjects10 = new Dictionary<string, int>();
    public Dictionary<string, int> hashMapObjects11 = new Dictionary<string, int>();
    public Dictionary<string, int> hashMapRebel = new Dictionary<string, int>();
    public Dictionary<string, int> hashMapFiveManager = new Dictionary<string, int>();

    void Awake(){
        for(int i = 0; i < 20; i ++){
            for(int j = 0; j < 100; j ++){
                myaudiosPlayedArray[i, j] = false;
            }
        }

        hashMapIntroduction.Add("Intrudction_1", 0);
        hashMapIntroduction.Add("Intrudction_2_1", 1);
        hashMapIntroduction.Add("Intrudction_2_2_1", 2);
        hashMapIntroduction.Add("Intrudction_2_2_2", 3);
        hashMapIntroduction.Add("Intrudction_3_no", 4);
        hashMapIntroduction.Add("Intrudction_3_yes", 5);

        hashMapObjects1.Add("Objects1_1", 0);
        hashMapObjects1.Add("Objects1_3", 1);
        hashMapObjects1.Add("Objects1_4", 2);
        hashMapObjects1.Add("Objects1_6", 3);
        hashMapObjects1.Add("Objects1_7", 4);
        hashMapObjects1.Add("Objects1_8", 5);
        hashMapObjects1.Add("Objects1_no", 6);
        hashMapObjects1.Add("Objects1_yes", 7);

        hashMapObjects2.Add("Objects2_1_1", 0);
        hashMapObjects2.Add("Objects2_1_2", 1);
        hashMapObjects2.Add("Objects2_2", 2);
        hashMapObjects2.Add("Objects2_4", 3);
        hashMapObjects2.Add("Objects2_6", 4);
        hashMapObjects2.Add("Objects2_1_seasound", 5);

        hashMapObjects3.Add("Objects3_1", 0);
        hashMapObjects3.Add("Objects3_2", 1);
        hashMapObjects3.Add("Objects3_4", 2);
        hashMapObjects3.Add("Objects3_yes", 3);
        hashMapObjects3.Add("Objects3_no", 4);

        hashMapObjects4.Add("Objects4_1", 0);
        hashMapObjects4.Add("Objects4_2", 1);
        hashMapObjects4.Add("Objects4_4", 2);
        hashMapObjects4.Add("Objects4_6", 3);
        hashMapObjects4.Add("Objects4_6_no", 4);
        hashMapObjects4.Add("Objects4_6_yes", 5);
        hashMapObjects4.Add("Objects4_7", 6);
        hashMapObjects4.Add("Objects4_7_no", 7);
        hashMapObjects4.Add("Objects4_8", 8);
        hashMapObjects4.Add("Objects4_skip_1", 9);
        hashMapObjects4.Add("Objects4_skip_2", 10);
        hashMapObjects4.Add("Objects4_skip_3", 11);
        hashMapObjects4.Add("Objects4_skip_4_01", 12);
        hashMapObjects4.Add("Objects4_skip_4_02", 13);

        hashMapObjects5.Add("Objects5_1", 0);
        hashMapObjects5.Add("Objects5_6", 1);
        hashMapObjects5.Add("Objects5_7", 2);
        hashMapObjects5.Add("Objects5_8", 3);
        hashMapObjects5.Add("Objects5_no", 4);
        hashMapObjects5.Add("Objects5_yes", 5);

        hashMapObjects6.Add("Objects6_1", 0);
        hashMapObjects6.Add("Objects6_2", 1);
        hashMapObjects6.Add("Objects6_4", 2);
        hashMapObjects6.Add("Objects6_6_1", 3);
        hashMapObjects6.Add("Objects6_6_2_01", 4);
        hashMapObjects6.Add("Objects6_6_2_02", 5);
        hashMapObjects6.Add("Objects6_6_3_01", 6);
        hashMapObjects6.Add("Objects6_6_3_02", 7);
        hashMapObjects6.Add("Objects6_no", 8);
        hashMapObjects6.Add("Objects6_yes", 9);

        hashMapObjects7.Add("Objects7_1", 0);
        hashMapObjects7.Add("Objects7_4", 1);
        hashMapObjects7.Add("Objects7_6_01", 2);
        hashMapObjects7.Add("Objects7_6_02", 3);
        hashMapObjects7.Add("Objects7_7", 4);
        hashMapObjects7.Add("Objects7_no", 5);
        hashMapObjects7.Add("Objects7_yes", 6);

        hashMapObjects8.Add("Objects8_1", 0);
        hashMapObjects8.Add("Objects8_2", 1);
        hashMapObjects8.Add("Objects8_4", 2);
        hashMapObjects8.Add("Objects8_no", 3);
        hashMapObjects8.Add("Objects8_yes", 4);

        hashMapObjects9.Add("Objects9_1", 0);
        hashMapObjects9.Add("Objects9_diamond_1", 1);
        hashMapObjects9.Add("Objects9_diamond_2", 2);
        hashMapObjects9.Add("Objects9_diamond_3", 3);
        hashMapObjects9.Add("Objects9_diamond_4", 4);
        hashMapObjects9.Add("Objects9_diamond_5", 5);
        hashMapObjects9.Add("Objects9_diamond_6", 6);
        hashMapObjects9.Add("Objects9_no", 7);
        hashMapObjects9.Add("Objects9_yes", 8);

        hashMapObjects10.Add("Objects10_1", 0);
        hashMapObjects10.Add("Objects10_2", 1);
        hashMapObjects10.Add("Objects10_3", 2);

        hashMapObjects11.Add("Objects11_1", 0);
        hashMapObjects11.Add("Objects11_3", 1);
        hashMapObjects11.Add("Objects11_10", 2);

        hashMapRebel.Add("Rebel50_1", 0);
        hashMapRebel.Add("Rebel50_2", 1);
        hashMapRebel.Add("Rebel50_2_no", 2);
        hashMapRebel.Add("Rebel50_2_yes", 3);
        hashMapRebel.Add("Rebel50_3_no", 4);
        hashMapRebel.Add("Rebel50_3_yes", 5);
        hashMapRebel.Add("Rebel50_4", 6);
        hashMapRebel.Add("Rebel80_1", 7);
        hashMapRebel.Add("Rebel80_2", 8);
        hashMapRebel.Add("Rebel80_3", 9);
        hashMapRebel.Add("Rebel100_1", 10);
        hashMapRebel.Add("Rebel100_2", 11);

        hashMapFiveManager.Add("fiveround_1", 0);
        hashMapFiveManager.Add("fiveround_2", 1);
        hashMapFiveManager.Add("fiveround_3", 2);
    }

    public bool isPlaying = false;

    public bool isAudioPlaying = false;
    private void Update() {
        if(audioSource.isPlaying)
            isAudioPlaying = true;
        else
            isAudioPlaying = false;

        // Debug.Log(hashMapObjects3["Objects3_1"]);
    }

    public void CheckInterrupt(){
        if(isPlaying && audioSource.isPlaying){
            Debug.Log("Interrupt.");
            NowPlayingAudioName = "null";
            audioSource.Stop();
            isPlaying = false;
            captionController.timer = 0;
        }

    }

    public bool PlayAudioClip(AudioClip audioClip, int audioType, int audioIndex)
    {
        audioSource.clip = audioClip;

        // 如果audioSource不在播放，并且状态是正在播放，那么说明音频已经播放完毕
        if(!audioSource.isPlaying && isPlaying){
            Debug.Log(audioClip.name + " is finished");
            NowPlayingAudioName = "null";
            isPlaying = false;
            return true;
        }

        // 如果状态是没有正在播放，并且当前音频没有被播放过，那么说明音频可以播放
        if(!isPlaying && !myaudiosPlayedArray[audioType, audioIndex]){
            Debug.Log(audioClip.name + " is ready to play");
            audioSource.Play();
            NowPlayingAudioName = audioClip.name;
            isPlaying = true;
        }

        if(!isAudioPlaying)
            isPlaying = false;

        // Debug.Log(audioClip.name + " is playing");
        return false;  
    }

    public bool AudioIntroductionPlayer(string audioName)
    {
        // Debug.Log("AudioIntroductionPlayer");
        if(myaudiosPlayedArray[0, hashMapIntroduction[audioName]]){
            return true;
        }
            
        if(PlayAudioClip(audioClipsIntroduction[hashMapIntroduction[audioName]], 0, hashMapIntroduction[audioName])){
            myaudiosPlayedArray[0, hashMapIntroduction[audioName]] = true;
            return true;
        }   
        return false;
    }

    public bool AudioObjects1Player(string audioName)
    {
        if(myaudiosPlayedArray[1, hashMapObjects1[audioName]])
            return true;
        

        if(PlayAudioClip(audioClipsObjects1[hashMapObjects1[audioName]], 1, hashMapObjects1[audioName])){
            myaudiosPlayedArray[1, hashMapObjects1[audioName]] = true;
            return true;
        }
            
        return false;
    }

    public bool AudioObjects2Player(string audioName)
    {
        if(myaudiosPlayedArray[2, hashMapObjects2[audioName]])
            return true;
        

        if(PlayAudioClip(audioClipsObjects2[hashMapObjects2[audioName]], 2, hashMapObjects2[audioName])){
            myaudiosPlayedArray[2, hashMapObjects2[audioName]] = true;
            return true;
        }
            
        return false;
    }

    public bool AudioObjects3Player(string audioName)
    {
        

        if(myaudiosPlayedArray[3, hashMapObjects3[audioName]])
            return true;
        
        if(PlayAudioClip(audioClipsObjects3[hashMapObjects3[audioName]], 3, hashMapObjects3[audioName])){
            myaudiosPlayedArray[3, hashMapObjects3[audioName]] = true;
            return true;
        }
            
        return false;
    }

    public bool AudioObjects4Player(string audioName)
    {
        if(myaudiosPlayedArray[4, hashMapObjects4[audioName]])
            return true;
        

        if(PlayAudioClip(audioClipsObjects4[hashMapObjects4[audioName]], 4, hashMapObjects4[audioName])){
            myaudiosPlayedArray[4, hashMapObjects4[audioName]] = true;
            return true;
        }
            
        return false;
    }

    public bool AudioObjects5Player(string audioName)
    {
        if(myaudiosPlayedArray[5, hashMapObjects5[audioName]])
            return true;
        

        if(PlayAudioClip(audioClipsObjects5[hashMapObjects5[audioName]], 5, hashMapObjects5[audioName])){
            myaudiosPlayedArray[5, hashMapObjects5[audioName]] = true;
            return true;
        }
            
        return false;
    }

    public bool AudioObjects6Player(string audioName)
    {
        if(myaudiosPlayedArray[6, hashMapObjects6[audioName]])
            return true;
        

        if(PlayAudioClip(audioClipsObjects6[hashMapObjects6[audioName]], 6, hashMapObjects6[audioName])){
            myaudiosPlayedArray[6, hashMapObjects6[audioName]] = true;
            return true;
        }
            
        return false;
    }

    public bool AudioObjects7Player(string audioName)
    {
        if(myaudiosPlayedArray[7, hashMapObjects7[audioName]])
            return true;
        

        if(PlayAudioClip(audioClipsObjects7[hashMapObjects7[audioName]], 7, hashMapObjects7[audioName])){
            myaudiosPlayedArray[7, hashMapObjects7[audioName]] = true;
            return true;
        }
            
        return false;
    }

    public bool AudioObjects8Player(string audioName)
    {
        if(myaudiosPlayedArray[8, hashMapObjects8[audioName]])
            return true;
        

        if(PlayAudioClip(audioClipsObjects8[hashMapObjects8[audioName]], 8, hashMapObjects8[audioName])){
            myaudiosPlayedArray[8, hashMapObjects8[audioName]] = true;
            return true;
        }
            
        return false;
    }

    public bool AudioObjects9Player(string audioName)
    {
        if(myaudiosPlayedArray[9, hashMapObjects9[audioName]])
            return true;
        

        if(PlayAudioClip(audioClipsObjects9[hashMapObjects9[audioName]], 9, hashMapObjects9[audioName])){
            myaudiosPlayedArray[9, hashMapObjects9[audioName]] = true;
            return true;
        }
            
        return false;
    }

    public bool AudioObjects10Player(string audioName)
    {
        if(myaudiosPlayedArray[10, hashMapObjects10[audioName]])
            return true;
        

        if(PlayAudioClip(audioClipsObjects10[hashMapObjects10[audioName]], 10, hashMapObjects10[audioName])){
            myaudiosPlayedArray[10, hashMapObjects10[audioName]] = true;
            return true;
        }
            
        return false;
    }

    public bool AudioObjects11Player(string audioName)
    {
        if(myaudiosPlayedArray[11, hashMapObjects11[audioName]])
            return true;
        

        if(PlayAudioClip(audioClipsObjects11[hashMapObjects11[audioName]], 11, hashMapObjects11[audioName])){
            myaudiosPlayedArray[11, hashMapObjects11[audioName]] = true;
            return true;
        }
            
        return false;
    }

    public bool AudioRebelPlayer(string audioName)
    {
        if(myaudiosPlayedArray[12, hashMapRebel[audioName]])
            return true;
        

        if(PlayAudioClip(audioClipsRebel[hashMapRebel[audioName]], 12, hashMapRebel[audioName])){
            myaudiosPlayedArray[12, hashMapRebel[audioName]] = true;
            return true;
        }
            
        return false;
    }

}
