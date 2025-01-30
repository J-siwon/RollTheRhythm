using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoteChart
{
    public Note[] notes;  // 이 곡에 등장하는 모든 노트
    public float bpm;
    public string songName;
    public float offset;          // 곡 시작 시점 오프셋 등
}
