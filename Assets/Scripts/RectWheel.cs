using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectWheel : MonoBehaviour
{

    public GameObject[] side = new GameObject[4]; // ����, ��, �Ʒ�, �������� ���� ����ϴ� ��
    private int currentindex = 0; 

    private void Update()
    {

    }

    // Start is called before the first frame update
    void ActiveNextSide()
    {
        currentindex = NoteManager.Instance.GetIndex();
    }

}
