using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;

    public static SoundManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            //SceneManager.
        }
        else
            Destroy(gameObject);
    }

    //사운드 클립 실행 (매개변수 : 사운드 이름과 오디오 클립)
    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject soundObject = new GameObject(sfxName + "Sound");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(audioSource, clip.length);
    }

    private void Start()
    {
        //2초 뒤 노래 시작
        StartCoroutine(StartBGMAndTimer());
    }
    private IEnumerator StartBGMAndTimer()
    {
        // 3초 대기
        yield return new WaitForSeconds(2f);

        // 3초 뒤에 BGM 재생
        bgmAudioSource.Play();

        // GameManager의 타이머 시작 메서드 호출
        // 싱글톤 패턴으로 접근
        GameManager.instance.StartTimer();
    }
}
