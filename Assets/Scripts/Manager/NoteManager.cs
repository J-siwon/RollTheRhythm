using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{

    [Header("Note Prefabs")]
    public GameObject NormalNotePrefab;
    public GameObject FastNotePrefab;
    public GameObject SlowNotePrefab;
    public GameObject TriangleNotePrefab;
    public GameObject SquareNotePrefab;
    public GameObject PentagonNotePrefab;
    public GameObject JumpNotePrefab;

    public enum NoteType
    {
        Normal, Fast, Slow, Triangle, Square, Pentagon, Jump
    }


    private GameObject NextNotePrefab;

    public NoteChart noteChart;         // 에디터에서 셋업할 노트 데이터

    public Note[] noteDatas;
    private int currentNoteIndex = 0;    // 현재 스폰해야 할 노트의 인덱스

    public static NoteManager Instance;  // 싱글톤
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

    private void Start()
    {
        GetNoteData("Note1_1.json");
        //임시로 노트를 생성
        for (int i = 0; i < noteDatas.Length; i++)
        {
            SpawnNotePrefab(noteDatas[i]);
        }
    }
    void Update()
    {
        float currentTime = Time.time; // 게임 시작 기준으로

    }

    public void NoteInit()
    {
        for (int i = 0; i < 5; i++)
        {
            noteDatas = new Note[i];
        }
    }

    public void SpawnNote(int index)
    {
        SpawnNotePrefab(noteDatas[index]);
    }

    private void SpawnNotePrefab(Note noteData)
    {
        //noteType에 따라 다음 노트의 프리팹을 설정
        SetNextNoteType(noteData);

        //추가 로직 예: 속도, 방향, 이펙트 초기화 등
        GameObject NoteObject = Instantiate(NextNotePrefab, noteData.spawnPos, Quaternion.identity);

        // var noteScript = noteObj.GetComponent<Note>();
        // noteScript.speed = noteData.speed;

        Debug.Log($"노트 스폰 at {noteData.spawnPos}");
    }

    public int GetNoteIndex() { return currentNoteIndex; }

    public void SetNextNoteType(Note noteData)
    {
        if (noteData.noteType == (int)NoteType.Normal)
            NextNotePrefab = NormalNotePrefab;
        else if (noteData.noteType == (int)NoteType.Fast)
            NextNotePrefab = FastNotePrefab;
        else if (noteData.noteType == (int)NoteType.Slow)
            NextNotePrefab = SlowNotePrefab;
        else if (noteData.noteType == (int)NoteType.Jump)
            NextNotePrefab = JumpNotePrefab;
        else if (noteData.noteType == (int)NoteType.Triangle)
            NextNotePrefab = TriangleNotePrefab;
        else if (noteData.noteType == (int)NoteType.Square)
            NextNotePrefab = SquareNotePrefab;
        else if (noteData.noteType == (int)NoteType.Pentagon)
            NextNotePrefab = PentagonNotePrefab;
    }

    public void GetNoteData(string fileName)
    {
        //json으로부터 noteChart 불러오기 
        noteChart = DataManager.instance.LoadChartFromJson(fileName);

        noteDatas = noteChart.notes;
    }
}
