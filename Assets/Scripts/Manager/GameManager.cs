using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float tempo = 100f; //BPM으로 1분당 박자 수 
    float targeTime = 60f / 100f * 3f;
    float inputTimer = 0f;
    float nextNoteTimer = 0f;
    float nextNoteBeat= 4f; //다음 노트까지 박자의 개수( 1/4박자면 4개 1/8박자면 2개)
    float timeDifference = 0f;
    bool isStart = false;

    int noteindex = 0;

    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);
    }

    /*Update 
      1. 타이머 시간 가기
      2. 입력받기
    */
    private void Update()
    {
        if (isStart)
        {
            inputTimer += Time.deltaTime;
            nextNoteTimer += Time.deltaTime;
        }

        if(nextNoteTimer >= targeTime)
        {
            Debug.Log("노트 넘어감");
            nextNoteTimer = 0f;
            GetNextTargetTime();
        }

        if (Input.anyKeyDown)
        {
            timeDifference = GetTimeDifference();
            Debug.Log(timeDifference);
            inputTimer = nextNoteTimer;
        }
    }

    /*
     *Update
     *입력 받기
     */
    private void FixedUpdate()
    {

    }

    float GetTimeDifference()
    {
        return targeTime - inputTimer;
    }

    public float GetTempo()
    {
        return tempo;
    }

    public void StartTimer()
    {
        Debug.Log("노래 시작합니다");
        inputTimer = 0f;
        nextNoteTimer = 0f;
        isStart = true;
    }

    void GetNextTargetTime()
    {
        noteindex++;
        //nextNoteBeat = note[noteindex];
        nextNoteBeat = 2f;
        targeTime = 60f / tempo * nextNoteBeat;
    }

}
