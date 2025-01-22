using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;

    public float correction = 0.2f;

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

    public void StartBGMAndTimer()
    {
        StartCoroutine(BGMAndTimerCourutine());
    }
    private IEnumerator BGMAndTimerCourutine()
    {
        // 3�� ���
        yield return new WaitForSeconds(1f + correction);

        // 3�� �ڿ� BGM ���
        bgmAudioSource.Play();

        // GameManager�� Ÿ�̸� ���� �޼��� ȣ��
        // �̱��� �������� ����
        GameManager.instance.StartTimer();
    }
}
