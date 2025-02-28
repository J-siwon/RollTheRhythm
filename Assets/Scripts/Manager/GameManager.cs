using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float tempo = 100f; //BPM으로 1분당 박자 수 

    public GameObject wheel;

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
        if (Input.anyKeyDown) //키 입력시 
        {
            GetTimeDifference(); //원래 판정과의 거리 차이 비교
        }
    }

    float GetTimeDifference()
    {
        return 0f;
    }

    public float GetTempo()
    {
        return tempo;
    }

}
