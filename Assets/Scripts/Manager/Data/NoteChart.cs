using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoteChart
{
    public Note[] notes;  // �� � �����ϴ� ��� ��Ʈ
    public float bpm;
    public string songName;
    public float offset;          // �� ���� ���� ������ ��
}
