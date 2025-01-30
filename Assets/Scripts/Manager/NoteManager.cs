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

    public NoteChart noteChart;         // �����Ϳ��� �¾��� ��Ʈ ������

    public Note[] noteDatas;
    private int currentNoteIndex = 0;    // ���� �����ؾ� �� ��Ʈ�� �ε���

    public static NoteManager Instance;  // �̱���
    void Awake()
    {
        // �̱��� ����
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� �����ϰ� �ʹٸ�
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GetNoteData("Note1_1.json");
        //�ӽ÷� ��Ʈ�� ����
        for (int i = 0; i < noteDatas.Length; i++)
        {
            SpawnNotePrefab(noteDatas[i]);
        }
    }
    void Update()
    {
        float currentTime = Time.time; // ���� ���� ��������

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
        //noteType�� ���� ���� ��Ʈ�� �������� ����
        SetNextNoteType(noteData);

        //�߰� ���� ��: �ӵ�, ����, ����Ʈ �ʱ�ȭ ��
        GameObject NoteObject = Instantiate(NextNotePrefab, noteData.spawnPos, Quaternion.identity);

        // var noteScript = noteObj.GetComponent<Note>();
        // noteScript.speed = noteData.speed;

        Debug.Log($"��Ʈ ���� at {noteData.spawnPos}");
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
        //json���κ��� noteChart �ҷ����� 
        noteChart = DataManager.instance.LoadChartFromJson(fileName);

        noteDatas = noteChart.notes;
    }
}
