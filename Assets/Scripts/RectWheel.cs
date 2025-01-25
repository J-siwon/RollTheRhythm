using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RectWheel : MonoBehaviour
{

    public GameObject[] side = new GameObject[4]; // ����, ��, �Ʒ�, �������� ���� ����ϴ� ��
    private int currentindex = 0; 
    float tempo = 100f;

    [SerializeField]
    private AnimationCurve speedCurve; // 0~1에서 가운데(0.5)가 제일 낮도록

    [SerializeField]
    private float duration = 1.0f;     // 0도에서 90도까지 굴리는 데 걸릴 시간(1초 가정)

    private float timeElapsed = 0f;    // 이번 0°→90° 구간에서 흐른 시간

    float rotationspeed = 0f;

    bool isstarted = false;

    private void Start()
    {
        tempo = GameManager.instance.GetTempo();
        rotationspeed = 60f / tempo;
        SoundManager.instance.StartBGMAndTimer();
    }

    void Update()
    {
        if (timeElapsed < rotationspeed)
        {
            timeElapsed += Time.deltaTime;
            float p = Mathf.Clamp01(timeElapsed / rotationspeed) * Mathf.PI;

            // 곡선에서 얻은 속도배율 (0~1 사이)
            float speedScale = Mathf.Sin(p) ;

            //총합 90도가 되기 위한 계수 
            float factor = 45f;

            // 실제로 회전해야 할 (이번 프레임 각도 변화)
            float deltaAngle = factor * speedScale * Time.deltaTime * (Mathf.PI / rotationspeed);

            // pivot을 중심으로 deltaAngle 만큼 회전
            Vector3 pivot = new Vector3(0f, 0f, 0f);
            transform.RotateAround(pivot, Vector3.back, deltaAngle);
            transform.position = new Vector3(0f, Mathf.Sqrt(2f) * speedScale * 0.1f, 0f);
        }
        else
        {
            // 90도에 도달하면 다음 꼭짓점으로 넘어간다거나,
            // timeElapsed 리셋, startAngle/endAngle 갱신 등등...
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Round(transform.eulerAngles.z));
            if (!isstarted)
            {
                isstarted = true;
            }
            timeElapsed = 0;


        }
    }

    // Start is called before the first frame update
    void ActiveNextSide()
    {
        currentindex = NoteManager.Instance.GetNoteIndex();
        
    }

}
