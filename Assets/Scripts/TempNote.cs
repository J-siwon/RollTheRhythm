using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempNote : MonoBehaviour
{
    float bpm;
    float spb; //1��Ʈ�� �ɸ��� �ð�
    float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        bpm = NoteManager.Instance.noteChart.bpm;
        spb = 60f / bpm;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeElapsed < spb)
        {
            timeElapsed += Time.deltaTime;
            float p = Mathf.Clamp01(timeElapsed / spb) * Mathf.PI;

            // ����� ���� �ӵ����� (0~1 ����)
            float speedScale = Mathf.Sin(p);

            transform.Translate(new Vector3(-1f * speedScale * Time.deltaTime * Mathf.PI/ spb / 2, 0f, 0f));

        }
        else
        {
            // 90���� �����ϸ� ���� ���������� �Ѿ�ٰų�,
            // timeElapsed ����, startAngle/endAngle ���� ���...
            //transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
            timeElapsed = 0;


        }
    }
}
