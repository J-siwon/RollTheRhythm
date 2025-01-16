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

    //���� Ŭ�� ���� (�Ű����� : ���� �̸��� ����� Ŭ��)
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
        //2�� �� �뷡 ����
        StartCoroutine(StartBGMAndTimer());
    }
    private IEnumerator StartBGMAndTimer()
    {
        // 3�� ���
        yield return new WaitForSeconds(2f);

        // 3�� �ڿ� BGM ���
        bgmAudioSource.Play();

        // GameManager�� Ÿ�̸� ���� �޼��� ȣ��
        // �̱��� �������� ����
        GameManager.instance.StartTimer();
    }
}
