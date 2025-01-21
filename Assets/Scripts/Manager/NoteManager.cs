using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;  // �̱���(���û���)

    [System.Serializable]
    public struct NoteData
    {
        public float time;         // ��Ʈ ����(�Ǵ� ����) ���� �ð�
        public Vector2 spawnPos;   // ��Ʈ ���� ��ġ
        public GameObject notePrefab;
        // �ʿ��ϸ� ��Ʈ Ÿ��, �ӵ�, ����Ʈ �� �߰�
    }

    public NoteData[] noteDatas;         // �����Ϳ��� �¾��� ��Ʈ ������
    private int currentNoteIndex = 0;    // ���� �����ؾ� �� ��Ʈ�� �ε���

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

    void Update()
    {
        float currentTime = Time.time; // ���� ���� ��������

        // ���� �������� ���� ��Ʈ�� �ְ�, ���� ��Ʈ�� ������ �ƴٸ�
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
        // ��Ʈ �������� �ش� ��ġ�� ����
        GameObject noteObj = Instantiate(noteData.notePrefab, noteData.spawnPos, Quaternion.identity);

        // �߰� ���� ��: �ӵ�, ����, ����Ʈ �ʱ�ȭ ��
        // var noteScript = noteObj.GetComponent<Note>();
        // noteScript.speed = noteData.speed;

        Debug.Log($"��Ʈ ���� at {noteData.spawnPos}");
    }

    public void GetNoteIndex() { return currentNoteIndex; }
}
