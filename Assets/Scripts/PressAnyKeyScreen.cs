using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKeyScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            StartCoroutine(MovePressAnyKeyPanel(1f));
        }
    }

    IEnumerator MovePressAnyKeyPanel(float movetime)
    {
        float t = 0;
        Vector3 originpos = transform.position;
        Debug.Log(originpos);
        Vector3 destinpos = new Vector3(transform.position.x, 3000f, 0f);
        while (t < movetime) // 시간이 다 되면 탈출 후 비활성화
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(originpos, destinpos, t / movetime); // 패널을 위쪽으로 쓰무스하게 올라가기
            yield return null;
        }

        this.gameObject.SetActive(false);
        
    }
}
