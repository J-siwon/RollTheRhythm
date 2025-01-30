using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempNote : MonoBehaviour
{
    float bpm;
    float spb; //1비트에 걸리는 시간
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

            // 곡선에서 얻은 속도배율 (0~1 사이)
            float speedScale = Mathf.Sin(p);

            transform.Translate(new Vector3(-1f * speedScale * Time.deltaTime * Mathf.PI/ spb / 2, 0f, 0f));

        }
        else
        {
            // 90도에 도달하면 다음 꼭짓점으로 넘어간다거나,
            // timeElapsed 리셋, startAngle/endAngle 갱신 등등...
            //transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
            timeElapsed = 0;


        }
    }
}
