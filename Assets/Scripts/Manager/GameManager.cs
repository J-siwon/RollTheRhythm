using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float tempo = 100f; //BPM���� 1�д� ���� �� 
    float targeTime = 60f / 100f * 3f;
    float inputTimer = 0f;
    float nextNoteTimer = 0f;
    float nextNoteBeat= 4f; //���� ��Ʈ���� ������ ����( 1/4���ڸ� 4�� 1/8���ڸ� 2��)
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
      1. Ÿ�̸� �ð� ����
      2. �Է¹ޱ�
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
            Debug.Log("��Ʈ �Ѿ");
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
     *�Է� �ޱ�
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
        Debug.Log("�뷡 �����մϴ�");
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
