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
        while (t < movetime) // �ð��� �� �Ǹ� Ż�� �� ��Ȱ��ȭ
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(originpos, destinpos, t / movetime); // �г��� �������� �������ϰ� �ö󰡱�
            yield return null;
        }

        this.gameObject.SetActive(false);
        
    }
}
