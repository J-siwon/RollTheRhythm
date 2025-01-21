using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RectWheel : MonoBehaviour
{

    public GameObject[] side = new GameObject[4]; // 왼쪽, 위, 아래, 오른쪽의 면을 담당하는 면
    private int currentindex = 0; 
    float tempo = 0;

    private void Start()
    {
        tempo = GameManager.instance.GetTempo();
    }

    private void FixedUpdate()
    {
        float rotationspeed = 60f / tempo * Time.deltaTime;
        this.transform.Rotate(0f, 0f, -90f * rotationspeed); //90도를 1/4박자에 맞게 Time.delta 타임으로 
    }

    // Start is called before the first frame update
    void ActiveNextSide()
    {
        currentindex = NoteManager.Instance.GetNoteIndex();
        
    }

}
