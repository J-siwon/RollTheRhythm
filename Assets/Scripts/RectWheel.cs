using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RectWheel : MonoBehaviour
{

    public GameObject[] side = new GameObject[4]; // ����, ��, �Ʒ�, �������� ���� ����ϴ� ��
    private int currentindex = 0; 
    float tempo = 0;

    private void Start()
    {
        tempo = GameManager.instance.GetTempo();
    }

    private void FixedUpdate()
    {
        float rotationspeed = 60f / tempo * Time.deltaTime;
        this.transform.Rotate(0f, 0f, -90f * rotationspeed); //90���� 1/4���ڿ� �°� Time.delta Ÿ������ 
    }

    // Start is called before the first frame update
    void ActiveNextSide()
    {
        currentindex = NoteManager.Instance.GetNoteIndex();
        
    }

}
