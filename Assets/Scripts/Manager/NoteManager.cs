using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;  // 싱글톤(선택사항)

    [System.Serializable]
    public struct NoteData
    {
        public float time;         // 노트 등장(또는 판정) 절대 시간
        public Vector2 spawnPos;   // 노트 스폰 위치
        public GameObject notePrefab;
        // 필요하면 노트 타입, 속도, 이펙트 등 추가
    }

    public NoteData[] noteDatas;         // 에디터에서 셋업할 노트 데이터
    private int currentNoteIndex = 0;    // 현재 스폰해야 할 노트의 인덱스

    void Awake()
    {
        // 싱글톤 패턴
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject); // 씬 전환 시에도 유지하고 싶다면
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        float currentTime = Time.time; // 게임 시작 기준으로

        // 아직 스폰되지 않은 노트가 있고, 다음 노트의 시점이 됐다면
        if (currentNoteIndex < noteDatas.Length)
        {
            if (currentTime >= noteDatas[currentNoteIndex].time)
            {
                SpawnNote(noteDatas[currentNoteIndex]);
                currentNoteIndex++;
            }
        }
    }

    private void SpawnNote(NoteData noteData)
    {
        // 노트 프리팹을 해당 위치에 생성
        GameObject noteObj = Instantiate(noteData.notePrefab, noteData.spawnPos, Quaternion.identity);

        // 추가 로직 예: 속도, 방향, 이펙트 초기화 등
        // var noteScript = noteObj.GetComponent<Note>();
        // noteScript.speed = noteData.speed;

        Debug.Log($"노트 스폰 at {noteData.spawnPos}");
    }

    public void GetNoteIndex() { return currentNoteIndex; }
}
