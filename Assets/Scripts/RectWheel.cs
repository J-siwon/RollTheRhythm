using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectWheel : MonoBehaviour
{

    public GameObject[] side = new GameObject[4]; // 왼쪽, 위, 아래, 오른쪽의 면을 담당하는 면
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
