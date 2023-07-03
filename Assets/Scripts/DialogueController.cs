using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [Header("General")]
    public GameController gameController;
    public int RebelScore = 0;
    public bool ShakingHeadPressed = false;
    public bool NoddingPressed = false;

    public AudioManager audioManager;
    private float timer = 0;
    private float myTime = 5f;

    // Introduction
    [Header("Introduction")]
    private bool Introduction_isWiped = false;
    private bool Introduction_isFinished = false;

    // Object1
    [Header("Object1")]
    public GameObject DiamondObj;
    private bool Object1_NoddingPressed = false;
    private bool Object1_ShakingHeadPressed = false;
    public bool readyToDisappear = false;

    // Object3
    [Header("Object3")]
    public GameObject Rock;

    private bool Object3_NoddingPressed = false;
    private bool Object3_ShakingHeadPressed = false;

    // Object4
    [Header("Object4")]
    public GameObject ChinaObj;
    public bool readyToTurnWhite = false;
    public Material ChinaWhiteMaterial;
    public bool readyToTurnColorful = false;
    public Material ChinaColorfulMaterial;
    public bool readyToUpSideDown = false;
    public bool readyToUpSideDownBack = false;

    private bool Object4_NoddingPressed = false;
    private bool Object4_ShakingHeadPressed = false;
    private float Object4_timer = 0;
    private float Object4_myTime = 5f;
    private bool Object4_ClickZero = true;
    private bool Object4_ClickOne = false;
    private bool Object4_ClickTwo = false;
    private bool Object4_ClickThree = false;

    // Object5
    [Header("Object5")]
    private bool Object5_NoddingPressed = false;
    private bool Object5_ShakingHeadPressed = false;

    // Object6
    [Header("Object6")]
    private bool Object6_NoddingPressed = false;
    private bool Object6_ShakingHeadPressed = false;  

    // Object7
    [Header("Object7")]
    public GameObject HeadForward;
    public GameObject HeadBackward;
    public bool readyToTurn = false;
    public bool readyToTurn2 = false;

    private bool Object7_NoddingPressed = false;
    private bool Object7_ShakingHeadPressed = false;

    // Object8
    [Header("Object8")]
    public bool statueReadyToDisappear = false;
    public GameObject StatueObj;

    private bool Object8_NoddingPressed = false;
    private bool Object8_ShakingHeadPressed = false;

    // Object9
    [Header("Object9")]
    private bool Object9_NoddingPressed = false;
    private bool Object9_ShakingHeadPressed = false;
    private float Object9_Timer = 0;
    private float Object9_myTime = 5;
    private int Object9_ClickTime = 0;
    private bool Object9_Can2 = false;

    // Object10
    [Header("Object10")]
    private bool Object10_ShakingHeadPressed = false;

    // Object11
    [Header("Object11")]
    private float Object11_Timer = 0;
    private float Object11_myTime = 10f;

    /// <summary>
    /// This is a dialogue controller
    /// </summary>
    /// <param name="index">The index of the dialogue</param>
    /// <param name="time">The time of the dialogue, start from 1</param>
    /// <returns>return true when you need to exit the dialogue</returns>
    public bool DialogueUpdate(int index, int time){
        gameController.RebelScore = RebelScore;
        // game over
        if(index == -1){
            switch(time){
                case 1:
                    if(Rebel_100_1()){
                        return true;
                    }
                    break;
                case 2:
                    if(Rebel_100_2()){
                        return true;
                    }
                    break;
                default:
                    Debug.Log("No such dialogue");
                    return true;
            }
        }

        // Introduction and Object4
        if(index == 3){
            if(readyToDisappear)
                DisappearDiamond();
            if(readyToTurn)
                TurnAround();
            if(readyToTurn2)
                TurnAround2();
            if(statueReadyToDisappear)
                StatueAppear();
            switch(time){
                case 1:
                    if(Introduction()){
                        return true;
                    }
                    break;
                case 2:
                    if(Object4_1()){
                        return true;
                    }
                    break;
                case 3:
                    if(Object4_2()){
                        return true;
                    }
                    break;
                case 4:
                    readyToTurnWhite = true;
                    return true;
                case 5:
                    if(readyToTurnWhite){
                        TurnWhite();
                    }
                    if(Object4_4()){
                        return true;
                    }
                    break;
                case 6:
                    readyToTurnColorful = true;
                    return true;
                case 7:
                    if(readyToTurnColorful)
                        TurnColorful();
                    if(Object4_6()){
                        readyToUpSideDown = true;
                        return true;
                    }
                    break;
                case 8:
                    if(readyToUpSideDown){
                        UpSideDown();
                    }
                    if(Object4_7()){
                        readyToUpSideDownBack = true;
                        return true;
                    }
                    break;
                case 9: 
                    if(readyToUpSideDownBack){
                        UpSideDownBack();
                    }
                    if(Object4_8()){
                        return true;
                    }
                    break;
                default:
                    Debug.Log("No such dialogue");
                    return true;
            }
        }

        // Object1
        if(index == 10){
            if(readyToDisappear)
                DisappearDiamond();
            if(readyToTurn)
                TurnAround();
            if(readyToTurn2)
                TurnAround2();
            if(statueReadyToDisappear)
                StatueAppear();
            if(readyToTurnWhite){
                TurnWhite();
            }
            if(readyToTurnColorful)
                TurnColorful();
            if(readyToUpSideDown){
                UpSideDown();
            }
            if(readyToUpSideDownBack){
                UpSideDownBack();
            }
            switch(time){
                case 1:
                    if(Object1_1()){
                        return true;
                    }
                    break;
                case 3:
                    if(Object1_3()){
                        return true;
                    }
                    break;
                case 4:
                    if(Object1_4()){
                        return true;
                    }
                    break;
                case 7:
                    if(Object1_7()){
                        return true;
                    }
                    break;
                case 8:
                    if(Object1_8()){
                        return true;
                    }
                    break;  
                default:
                    Debug.Log("No such dialogue");
                    return true;              
            }

        }

        // Object2
        if(index == 9){
            if(readyToTurn)
                TurnAround();
            if(readyToTurn2)
                TurnAround2();
            if(statueReadyToDisappear)
                StatueAppear();
            if(readyToTurnWhite){
                TurnWhite();
            }
            if(readyToTurnColorful)
                TurnColorful();
            if(readyToUpSideDown){
                UpSideDown();
            }
            if(readyToUpSideDownBack){
                UpSideDownBack();
            }
            switch(time){
                case 1:
                    if(Object2_1()){
                        return true;
                    }
                    break;
                case 2:
                    if(Object2_2()){
                        return true;
                    }
                    break;
                case 4:
                    if(Object2_4()){
                        return true;
                    }
                    break;
                case 5:
                    readyToDisappear = true;
                    return true;
                case 6:
                    if(readyToDisappear)
                        DisappearDiamond();
                    if(Object2_6()){
                        Object9_Can2 = true;
                        return true;
                    }
                    break;
                default:
                    Debug.Log("No such dialogue");
                    return true;
            }
        }

        // Object3
        if(index == 2){
            if(readyToDisappear)
                DisappearDiamond();
            if(readyToTurn)
                TurnAround();
            if(readyToTurn2)
                TurnAround2();
            if(statueReadyToDisappear)
                StatueAppear();
            if(readyToTurnWhite){
                TurnWhite();
            }
            if(readyToTurnColorful)
                TurnColorful();
            if(readyToUpSideDown){
                UpSideDown();
            }
            if(readyToUpSideDownBack){
                UpSideDownBack();
            }
            switch(time){
                case 1:
                    if(Object3_1()){
                        return true;
                    }
                    break;
                case 2:
                    if(Object3_2()){
                        return true;
                    }
                    break;
                case 3:
                    Rock.GetComponent<Animator>().SetBool("IsFloating", true);
                    if(Object3_3()){
                        return true;
                    }
                    break;
                case 4:
                    if(Object3_4()){
                        return true;
                    }
                    break;
                default:
                    Debug.Log("No such dialogue");
                    return true;
                
            }
        }

        // Object5
        if(index == 8){
            if(readyToDisappear)
                DisappearDiamond();
            if(readyToTurn)
                TurnAround();
            if(readyToTurn2)
                TurnAround2();
            if(statueReadyToDisappear)
                StatueAppear();
            if(readyToTurnWhite){
                TurnWhite();
            }
            if(readyToTurnColorful)
                TurnColorful();
            if(readyToUpSideDown){
                UpSideDown();
            }
            if(readyToUpSideDownBack){
                UpSideDownBack();
            }
            switch(time){
                case 1:
                    if(Object5_1()){
                        return true;
                    }
                    break;
                case 6:
                    if(Object5_6()){
                        return true;
                    }
                    break;
                case 7:
                    if(Object5_7()){
                        return true;
                    }
                    break;
                case 8:
                    if(Object5_8()){
                        return true;
                    }
                    break;
                default:
                    Debug.Log("No such dialogue");
                    return true;
            }
        }

        // Object6
        if(index == 1){
            if(readyToDisappear)
                DisappearDiamond();
            if(readyToTurn)
                TurnAround();
            if(readyToTurn2)
                TurnAround2();
            if(statueReadyToDisappear)
                StatueAppear();
            if(readyToTurnWhite){
                TurnWhite();
            }
            if(readyToTurnColorful)
                TurnColorful();
            if(readyToUpSideDown){
                UpSideDown();
            }
            if(readyToUpSideDownBack){
                UpSideDownBack();
            }
            switch(time){
                case 1:
                    if(Object6_1()){
                        return true;
                    }
                    break;
                case 2:
                    if(Object6_2()){
                        return true;
                    }
                    break;
                case 4:
                    if(Object6_4()){
                        return true;
                    }
                    break;
                case 6:
                    if(Object6_6()){
                        return true;
                    }
                    break;
                default:
                    Debug.Log("No such dialogue");
                    return true;
            }
        }

        // Object7
        if(index == 4){
            if(readyToDisappear)
                DisappearDiamond();
            if(statueReadyToDisappear)
                StatueAppear();
            if(readyToTurnWhite){
                TurnWhite();
            }
            if(readyToTurnColorful)
                TurnColorful();
            if(readyToUpSideDown){
                UpSideDown();
            }
            if(readyToUpSideDownBack){
                UpSideDownBack();
            }
            switch(time){
                case 1:
                    if(Object7_1()){
                        return true;
                    }
                    break;
                case 4:
                    if(Object7_4()){
                        return true;
                    }
                    break;
                case 5:
                    readyToTurn = true;
                    return true;
                case 6:
                    if(readyToTurn)
                        TurnAround();
                    if(Object7_6()){
                        readyToTurn2 = true;
                        return true;
                    }
                    break;
                case 7:
                    if(readyToTurn2)
                        TurnAround2();
                    if(Object7_7()){
                        return true;
                    }
                    break;
                default:
                    Debug.Log("No such dialogue");
                    return true;
            }
        }
        
        // Object8
        if(index == 7){
            if(readyToDisappear)
                DisappearDiamond();
            if(readyToTurn)
                TurnAround();
            if(readyToTurn2)
                TurnAround2();
            if(readyToTurnWhite){
                TurnWhite();
            }
            if(readyToTurnColorful)
                TurnColorful();
            if(readyToUpSideDown){
                UpSideDown();
            }
            if(readyToUpSideDownBack){
                UpSideDownBack();
            }
            switch(time){
                case 1:
                    if(Object8_1()){
                        return true;
                    }
                    break;
                case 2:
                    if(Object8_2()){
                        return true;
                    }
                    break;
                case 3:
                    statueReadyToDisappear = true;
                    return true;
                case 4:
                    if(statueReadyToDisappear)
                        StatueAppear();
                    if(Object8_4()){
                        return true;
                    }
                    break;
                default:
                    Debug.Log("No such dialogue");
                    return true;
            }
        }

        // Object9
        if(index == 0){
            if(readyToDisappear)
                DisappearDiamond();
            if(readyToTurn)
                TurnAround();
            if(readyToTurn2)
                TurnAround2();
            if(statueReadyToDisappear)
                StatueAppear();
            if(readyToTurnWhite){
                TurnWhite();
            }
            if(readyToTurnColorful)
                TurnColorful();
            if(readyToUpSideDown){
                UpSideDown();
            }
            if(readyToUpSideDownBack){
                UpSideDownBack();
            }
            switch(time){
                case 1:
                    if(Object9_1()){
                        return true;
                    }
                    break;
                case 2:
                    if(Object9_Can2){
                        if(Object9_2()){
                            return true;
                        }
                    }
                    break;
                default:
                    Debug.Log("No such dialogue");
                    return true;
            } 
        }

        // Object10
        if(index == 5){
            if(readyToDisappear)
                DisappearDiamond();
            if(readyToTurn)
                TurnAround();
            if(readyToTurn2)
                TurnAround2();
            if(statueReadyToDisappear)
                StatueAppear();
            if(readyToTurnWhite){
                TurnWhite();
            }
            if(readyToTurnColorful)
                TurnColorful();
            if(readyToUpSideDown){
                UpSideDown();
            }
            if(readyToUpSideDownBack){
                UpSideDownBack();
            }
            switch(time){
                case 1:
                    if(Object10_1()){
                        return true;
                    }
                    break; 
                case 2:
                    if(Object10_2()){
                        return true;
                    }
                    break; 
                case 3:
                    if(Object10_3()){
                        return true;
                    }
                    break;           
                case 4:
                    if(Object10_3()){
                        return true;
                    }
                    break;   
                case 5:
                    if(Object10_3()){
                        return true;
                    }
                    break;  
                case 6:
                    if(Object10_3()){
                        return true;
                    }
                    break;  
                case 7:
                    if(Object10_3()){
                        return true;
                    }
                    break;  
                case 8:
                    if(Object10_3()){
                        return true;
                    }
                    break;   
                default:
                    Debug.Log("No such dialogue");
                    return true;     
            }
        }

        // Object11
        if(index == 6){
            if(readyToDisappear)
                DisappearDiamond();
            if(readyToTurn)
                TurnAround();
            if(readyToTurn2)
                TurnAround2();
            if(statueReadyToDisappear)
                StatueAppear();
            if(readyToTurnWhite){
                TurnWhite();
            }
            if(readyToTurnColorful)
                TurnColorful();
            if(readyToUpSideDown){
                UpSideDown();
            }
            if(readyToUpSideDownBack){
                UpSideDownBack();
            }
            switch(time){
                case 1:
                    if(Object11_1()){
                        return true;
                    }
                    break;     

                case 3:
                    if(Object11_3()){
                        return true;
                    }   
                    break; 
                default:
                    Debug.Log("No such dialogue");
                    return true;
            }
        }

        // when you need to exit the dialogue, just return true
        if(Input.GetKeyDown(KeyCode.Space)){
            audioManager.CheckInterrupt();
            return true;
        }
        return false;
    }

    void UpSideDownBack(){
        ChinaObj.transform.localScale = new Vector3(1.27f, 1.9939f, 1.27f);
    }

    void UpSideDown(){
        ChinaObj.transform.localScale = new Vector3(1.27f, -1.9939f, 1.27f);
    }

    void TurnWhite(){
        ChinaObj.GetComponent<MeshRenderer>().material = ChinaWhiteMaterial;
    }

    void TurnColorful(){
        ChinaObj.GetComponent<MeshRenderer>().material = ChinaColorfulMaterial;
    }

    void StatueAppear(){
        StatueObj.SetActive(true);
        Debug.Log("StatueAppear");
    }

    void DisappearDiamond(){
        DiamondObj.SetActive(false);
        Debug.Log("DisappearDiamond");
    }

    void TurnAround(){
        HeadForward.SetActive(false);
        HeadBackward.SetActive(true);
        Debug.Log("TurnAround");
    }

    void TurnAround2(){
        HeadForward.SetActive(true);
        HeadBackward.SetActive(false);
        Debug.Log("TurnAround2");
    }

    bool Introduction(){
        if(audioManager.AudioIntroductionPlayer("Intrudction_1")){
            // player need to click space to play next audio, otherwise play another audio
            if(Input.GetMouseButtonDown(0)){
                Introduction_isWiped = true;
                audioManager.CheckInterrupt();
            }

            if(Introduction_isWiped){
                if(audioManager.AudioIntroductionPlayer("Intrudction_2_2_1")){
                    if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
                        if(audioManager.AudioIntroductionPlayer("Intrudction_2_2_2")){
                            if(NoddingPressed || Introduction_isFinished){
                                Introduction_isFinished = true;
                                audioManager.CheckInterrupt();
                                if(audioManager.AudioIntroductionPlayer("Intrudction_3_yes")){
                                    timer = 0;
                                    myTime = 5f;
                                    return true;
                                }
                            }
                            else if(ShakingHeadPressed){
                                audioManager.CheckInterrupt();
                                if(audioManager.AudioIntroductionPlayer("Intrudction_3_no")){
                                    audioManager.myaudiosPlayedArray[0, audioManager.hashMapIntroduction["Intrudction_3_no"]] = false;
                                    RebelScore ++;
                                    return false;
                                }
                            }
                        }
                    }     
                }
            }
            else{
                timer += Time.deltaTime;
                if(timer >= myTime && !Introduction_isWiped){
                    if(audioManager.AudioIntroductionPlayer("Intrudction_2_1")){
                        audioManager.myaudiosPlayedArray[0, audioManager.hashMapIntroduction["Intrudction_2_1"]] = false;
                        myTime += 5f;
                        RebelScore ++;
                    }
                }
            }
        }
        return false;
    }

    bool Object1_1(){
        if(audioManager.AudioObjects1Player("Objects1_1")){
            return true;
        }
        return false;
    }

    bool Object1_3(){
        if(audioManager.AudioObjects1Player("Objects1_3")){
            return true;
        }
        return false;
    }

    bool Object1_4(){
        if(audioManager.AudioObjects1Player("Objects1_4")){
            return true;
        }
        return false;
    }

    bool Object1_7(){
        if(audioManager.AudioObjects1Player("Objects1_7")){
            return true;
        }
        return false;
    }

    bool Object1_8(){
        if(audioManager.AudioObjects1Player("Objects1_8")){
            if(NoddingPressed || Object1_NoddingPressed){
                Object1_NoddingPressed = true;
                if(audioManager.AudioObjects1Player("Objects1_yes")){
                    return true;
                }
            }
            else if(ShakingHeadPressed || Object1_ShakingHeadPressed){
                Object1_ShakingHeadPressed = true;
                if(audioManager.AudioObjects1Player("Objects1_no")){
                    RebelScore ++;
                    return true;
                }
            }
        }
        return false;
    }

    bool Object2_1(){
        if(audioManager.AudioObjects2Player("Objects2_1_1")){
            if(audioManager.AudioObjects2Player("Objects2_1_seasound")){
                if(audioManager.AudioObjects2Player("Objects2_1_2")){
                    return true;
                }                
            }
        }
        return false;
    }

    bool Object2_2(){
        if(audioManager.AudioObjects2Player("Objects2_2")){
            return true;
        } 
        return false;      
    }

    bool Object2_4(){
        if(audioManager.AudioObjects2Player("Objects2_4")){
            return true;
        } 
        return false;      
    }

    bool Object2_6(){
        if(audioManager.AudioObjects2Player("Objects2_6")){
            return true;
        } 
        return false;      
    }
    
    bool Object3_1(){
        if(audioManager.AudioObjects3Player("Objects3_1")){
            return true;
        } 
        return false;      
    }

    bool Object3_2(){
        if(audioManager.AudioObjects3Player("Objects3_2")){
            audioManager.myaudiosPlayedArray[3, audioManager.hashMapObjects3["Objects3_2"]] = false;
            return true;
        } 
        return false;      
    }
    bool Object3_3(){
        if(audioManager.AudioObjects3Player("Objects3_2")){
            if(NoddingPressed || Object3_NoddingPressed){
                Object3_NoddingPressed = true;
                if(audioManager.AudioObjects3Player("Objects3_yes")){
                    Object3_NoddingPressed = false;
                    audioManager.myaudiosPlayedArray[3, audioManager.hashMapObjects3["Objects3_2"]] = false;
                    return true;
                }
            }
            else if(ShakingHeadPressed || Object3_ShakingHeadPressed){
                Object3_ShakingHeadPressed = true;
                if(audioManager.AudioObjects3Player("Objects3_no")){
                    Object3_ShakingHeadPressed = false; 
                    RebelScore ++;
                    audioManager.myaudiosPlayedArray[3, audioManager.hashMapObjects3["Objects3_2"]] = false;
                    return true;
                }
            }
        } 
        return false;      
    }

    bool Object3_4(){
        if(audioManager.AudioObjects3Player("Objects3_2")){
            if(NoddingPressed || Object3_NoddingPressed){
                Object3_NoddingPressed = true;
                if(audioManager.AudioObjects3Player("Objects3_yes")){
                    Object3_NoddingPressed = false;
                    return true;
                }
            }
            else if(ShakingHeadPressed || Object3_ShakingHeadPressed){
                Object3_ShakingHeadPressed = true;
                if(audioManager.AudioObjects3Player("Objects3_no")){
                    Object3_ShakingHeadPressed = false; 
                    RebelScore ++;
                    return true;
                }
            }
        } 
        return false;      
    }

    bool Object4_1(){
        if(audioManager.AudioObjects4Player("Objects4_1")){
            return true;
        } 
        return false;      
    }

    bool Object4_2(){
        if(audioManager.AudioObjects4Player("Objects4_2")){
            return true;
        } 
        return false;      
    }

    bool Object4_4(){
        if(audioManager.AudioObjects4Player("Objects4_4")){
            return true;
        } 
        return false;      
    }

    bool Object4_6(){
        if(audioManager.AudioObjects4Player("Objects4_6")){
            if(NoddingPressed || Object4_NoddingPressed){
                Object4_NoddingPressed = true;
                if(audioManager.AudioObjects4Player("Objects4_6_yes")){
                    Object4_NoddingPressed = false;
                    return true;
                }
            }
            else if(ShakingHeadPressed || Object4_ShakingHeadPressed){
                Object4_ShakingHeadPressed = true;
                if(audioManager.AudioObjects4Player("Objects4_6_no")){
                    Object4_ShakingHeadPressed = false; 
                    RebelScore ++;
                    return true;
                }
            }
        } 
        return false;      
    }

    bool Object4_7(){
        if(audioManager.AudioObjects4Player("Objects4_7")){
            Object4_timer += Time.deltaTime;
            if(Input.anyKeyDown){
                audioManager.CheckInterrupt();
                return true;
            }
            if(Object4_timer > Object4_myTime){
                if(audioManager.AudioObjects4Player("Objects4_7_no")){
                    audioManager.myaudiosPlayedArray[4, audioManager.hashMapObjects4["Objects4_7_no"]] = false;
                    Object4_myTime += 5f;
                    RebelScore ++;
                }
            }
        } 
        return false;      
    }

    bool Object4_8(){
        if(Object4_ClickZero && audioManager.AudioObjects4Player("Objects4_8")){
            return true;
        } 
        if(Input.GetMouseButtonDown(0)){
            audioManager.CheckInterrupt();
            if(Object4_ClickZero){
                audioManager.myaudiosPlayedArray[4, audioManager.hashMapObjects4["Objects4_8"]] = true;
                Object4_ClickZero = false;
                Object4_ClickOne = true;
                RebelScore ++;
            }
            else if(Object4_ClickOne){
                audioManager.myaudiosPlayedArray[4, audioManager.hashMapObjects4["Objects4_skip_1"]] = true;
                Object4_ClickOne = false;
                Object4_ClickTwo = true;
                RebelScore ++;
            }
            else if(Object4_ClickTwo){
                audioManager.myaudiosPlayedArray[4, audioManager.hashMapObjects4["Objects4_skip_2"]] = true;
                Object4_ClickTwo = false;
                Object4_ClickThree = true;
                RebelScore ++;
            }
        }
        if(Object4_ClickOne){
            if(audioManager.AudioObjects4Player("Objects4_skip_1")){
                return true;
            }
        }
        if(Object4_ClickTwo){
            if(audioManager.AudioObjects4Player("Objects4_skip_2")){
                return true;
            }
        }                                               
        if(Object4_ClickThree){
            if(audioManager.AudioObjects4Player("Objects4_skip_3")){
                if(audioManager.AudioObjects4Player("Objects4_skip_4_01")){
                    if(audioManager.AudioObjects4Player("Objects4_skip_4_02")){
                        return true;
                    }
                }
            }
        }
        return false;      
    }

    bool Object5_1(){
        if(audioManager.AudioObjects5Player("Objects5_1")){
            if(NoddingPressed || Object5_NoddingPressed){
                Object5_NoddingPressed = true;
                if(audioManager.AudioObjects5Player("Objects5_yes")){
                    Object5_NoddingPressed = false;
                    return true;
                }
            }
            else if(ShakingHeadPressed || Object5_ShakingHeadPressed){
                Object5_ShakingHeadPressed = true;
                if(audioManager.AudioObjects5Player("Objects5_no")){
                    Object5_ShakingHeadPressed = false; 
                    RebelScore ++;
                    return true;
                }
            }
        } 
        return false;      
    }
    
    bool Object5_6(){
        if(audioManager.AudioObjects5Player("Objects5_6")){
            if(NoddingPressed || Object5_NoddingPressed){
                Object5_NoddingPressed = true;
                if(audioManager.AudioObjects5Player("Objects5_yes")){
                    Object5_NoddingPressed = false;
                    return true;
                }
            }
            else if(ShakingHeadPressed || Object5_ShakingHeadPressed){
                Object5_ShakingHeadPressed = true;
                if(audioManager.AudioObjects5Player("Objects5_no")){
                    Object5_ShakingHeadPressed = false; 
                    RebelScore ++;
                    return true;
                }
            }
        } 
        return false;      
    }

    bool Object5_7(){
        if(audioManager.AudioObjects5Player("Objects5_7")){
            if(NoddingPressed || Object5_NoddingPressed){
                Object5_NoddingPressed = true;
                if(audioManager.AudioObjects5Player("Objects5_yes")){
                    Object5_NoddingPressed = false;
                    return true;
                }
            }
            else if(ShakingHeadPressed || Object5_ShakingHeadPressed){
                Object5_ShakingHeadPressed = true;
                if(audioManager.AudioObjects5Player("Objects5_no")){
                    Object5_ShakingHeadPressed = false; 
                    RebelScore ++;
                    return true;
                }
            }
        } 
        return false;      
    }

    bool Object5_8(){
        if(audioManager.AudioObjects5Player("Objects5_8")){
            if(NoddingPressed || Object5_NoddingPressed){
                Object5_NoddingPressed = true;
                if(audioManager.AudioObjects5Player("Objects5_yes")){
                    Object5_NoddingPressed = false;
                    return true;
                }
            }
            else if(ShakingHeadPressed || Object5_ShakingHeadPressed){
                Object5_ShakingHeadPressed = true;
                if(audioManager.AudioObjects5Player("Objects5_no")){
                    Object5_ShakingHeadPressed = false; 
                    RebelScore ++;
                    return true;
                }
            }
        } 
        return false;      
    }

    bool Object6_1(){
        if(audioManager.AudioObjects6Player("Objects6_1")){
            return true;
        } 
        return false;   
    }

    bool Object6_2(){
        if(audioManager.AudioObjects6Player("Objects6_2")){
            return true;
        } 
        return false;   
    }

    bool Object6_4(){
        if(audioManager.AudioObjects6Player("Objects6_4")){
            return true;
        } 
        return false;   
    }

    bool Object6_6(){
        if(audioManager.AudioObjects6Player("Objects6_6_1")){
        if(audioManager.AudioObjects6Player("Objects6_6_2_01")){
        if(audioManager.AudioObjects6Player("Objects6_6_2_02")){
        if(audioManager.AudioObjects6Player("Objects6_6_3_01")){
        if(audioManager.AudioObjects6Player("Objects6_6_3_02")){
            if(NoddingPressed || Object6_NoddingPressed){
                Object6_NoddingPressed = true;
                if(audioManager.AudioObjects6Player("Objects6_yes")){
                    Object6_NoddingPressed = false;
                    return true;
                }
            }
            else if(ShakingHeadPressed || Object6_ShakingHeadPressed){
                Object6_ShakingHeadPressed = true;
                if(audioManager.AudioObjects6Player("Objects6_no")){
                    Object6_ShakingHeadPressed = false; 
                    RebelScore ++;
                    return true;
                }
            }
        }
        }
        } 
        } 
        } 
        return false;   
    }

    bool Object7_1(){
        if(audioManager.AudioObjects7Player("Objects7_1")){
            return true;
        } 
        return false;   
    }

    bool Object7_4(){
        if(audioManager.AudioObjects7Player("Objects7_4")){
            return true;
        } 
        return false;   
    }

    bool Object7_6(){
        if(audioManager.AudioObjects7Player("Objects7_6_01")){
        if(audioManager.AudioObjects7Player("Objects7_6_02")){
            return true;
        } 
        } 
        return false;   
    }

    bool Object7_7(){
        if(audioManager.AudioObjects7Player("Objects7_7")){
            if(NoddingPressed || Object7_NoddingPressed){
                Object7_NoddingPressed = true;
                if(audioManager.AudioObjects7Player("Objects7_yes")){
                    Object7_NoddingPressed = false;
                    return true;
                }
            }
            else if(ShakingHeadPressed || Object7_ShakingHeadPressed){
                Object7_ShakingHeadPressed = true;
                if(audioManager.AudioObjects7Player("Objects7_no")){
                    Object7_ShakingHeadPressed = false; 
                    RebelScore ++;
                    return true;
                }
            }
        } 
        return false;   
    }

    bool Object8_1(){
        Debug.Log("Object8_1 Playing");
        if(audioManager.AudioObjects8Player("Objects8_1")){
            return true;
        } 
        return false;   
    }

    bool Object8_2(){
        if(audioManager.AudioObjects8Player("Objects8_2")){
            return true;
        } 
        return false;   
    }

    bool Object8_4(){
        if(audioManager.AudioObjects8Player("Objects8_4")){
            if(NoddingPressed || Object8_NoddingPressed){
                Object8_NoddingPressed = true;
                if(audioManager.AudioObjects8Player("Objects8_yes")){
                    Object8_NoddingPressed = false;
                    return true;
                }
            }
            else if(ShakingHeadPressed || Object8_ShakingHeadPressed){
                Object8_ShakingHeadPressed = true;
                if(audioManager.AudioObjects8Player("Objects8_no")){
                    Object8_ShakingHeadPressed = false; 
                    RebelScore ++;
                    return true;
                }
            }
        } 
        return false;   
    }

    bool Object9_1(){
        if(audioManager.AudioObjects9Player("Objects9_1")){
            return true;
        } 
        return false;   
    }

    bool Object9_2(){
        Object9_Timer += Time.deltaTime;
        
        if(Input.GetMouseButtonDown(0)){
            audioManager.CheckInterrupt();
            if(Object9_ClickTime == 0){
                Object9_ClickTime = 1;
                RebelScore ++;
            }

            else if(Object9_ClickTime == -1){
                Object9_ClickTime = 2;
                RebelScore ++;
            }
            
            else if(Object9_ClickTime == -2){
                Object9_ClickTime = 3;
                RebelScore ++;
            }
        }
        if(Object9_ClickTime == 1){
            Object9_Timer = 0;
            if(audioManager.AudioObjects9Player("Objects9_diamond_1")){
                Object9_ClickTime = -1;
            }
        }

        if(Object9_ClickTime == 2){
            Object9_Timer = 0;
            if(audioManager.AudioObjects9Player("Objects9_diamond_2")){
                Object9_ClickTime = -2;
            }          
        }

        if(Object9_ClickTime == 3){
            Object9_Timer = 0;
            if(audioManager.AudioObjects9Player("Objects9_diamond_3")){
                Object9_ClickTime = -3;
            }          
        }

        if(Object9_ClickTime == -3 || Object9_Timer > Object9_myTime){
            if(audioManager.AudioObjects9Player("Objects9_diamond_4")){
            if(audioManager.AudioObjects9Player("Objects9_diamond_5")){
            if(audioManager.AudioObjects9Player("Objects9_diamond_6")){
            if(NoddingPressed || Object9_NoddingPressed){
                Object9_NoddingPressed = true;
                if(audioManager.AudioObjects9Player("Objects9_yes")){
                    Object9_NoddingPressed = false;
                    return true;
                }
            }
            else if(ShakingHeadPressed || Object9_ShakingHeadPressed){
                Object9_ShakingHeadPressed = true;
                if(audioManager.AudioObjects9Player("Objects9_no")){
                    Object9_ShakingHeadPressed = false; 
                    RebelScore ++;
                    return true;
                }
            }
            } 
            } 
            } 
        }
        return false;
    }

    bool Object10_1(){
        if(audioManager.AudioObjects10Player("Objects10_1")){
            return true;
        } 
        return false;    
    }

    bool Object10_2(){
        if(audioManager.AudioObjects10Player("Objects10_2")){
            if(ShakingHeadPressed || Object10_ShakingHeadPressed){
                Object10_ShakingHeadPressed = true;
                if(audioManager.AudioObjects10Player("Objects10_3")){
                    Object10_ShakingHeadPressed = false; 
                    RebelScore ++;
                    return true;
                }
            }
        } 
        return false;  
    }

    bool Object10_3(){
        if(audioManager.AudioObjects10Player("Objects10_3")){
            return true;
        } 
        return false;  
    }

    bool Object11_1(){
        if(audioManager.AudioObjects11Player("Objects11_1")){
            return true;
        } 
        return false;  
    }

    bool Object11_3(){
        if(audioManager.AudioObjects11Player("Objects11_3")){
            if(Input.anyKeyDown){
                audioManager.CheckInterrupt();
                return true;
            }
            Object11_Timer += Time.deltaTime;
            if(Object11_Timer > Object11_myTime){
                if(audioManager.AudioObjects11Player("Objects11_10")){
                    Object11_Timer = 0;
                    audioManager.myaudiosPlayedArray[11, audioManager.hashMapObjects11["Objects11_10"]] = false;
                }
            }
        } 
        return false;  
    }

    bool Rebel_100_1(){
        if(audioManager.AudioRebelPlayer("Rebel100_1")){
            return true;
        } 
        return false;  
    }

    bool Rebel_100_2(){
        if(audioManager.AudioRebelPlayer("Rebel100_2")){
            return true;
        } 
        return false;  
    }
}
