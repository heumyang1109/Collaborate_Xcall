using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("BGM Clips")]
    [SerializeField] private AudioClip titleBGM;
    [SerializeField] private AudioClip gameBGM;

    [Header("SFX Clips")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip checkpointSound;
    [SerializeField] private AudioClip gameOverSound;

    [Header("Volume Settings")]
    [SerializeField] private float bgmVolume = 0.5f;
    [SerializeField] private float sfxVolume = 0.7f;

    private void Awake()
    {
        // 싱글톤 패턴 구현
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeAudioSources();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeAudioSources()
    {
        // AudioSource가 할당되지 않은 경우 자동 생성
        if (bgmSource == null)
        {
            bgmSource = gameObject.AddComponent<AudioSource>();
        }
        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
        }

        // BGM 설정
        bgmSource.loop = true;
        bgmSource.volume = bgmVolume;

     
    }

    // BGM 재생
    public void PlayBGM(string sceneName)
    {
        AudioClip clipToPlay = null;

        switch (sceneName.ToLower())
        {
            case "title":
            case "titlescene":
                clipToPlay = titleBGM;
                break;
            case "game":
            case "gamescene":
            case "main":
                clipToPlay = gameBGM;
                break;
        }

        // 같은 BGM이 이미 재생 중이면 변경하지 않음
        if (clipToPlay != null && bgmSource.clip != clipToPlay)
        {
            bgmSource.clip = clipToPlay;
            bgmSource.Play();
        }
        else if (clipToPlay != null && !bgmSource.isPlaying)
        {
            bgmSource.Play();
        }
    }

    // BGM 재개
    public void ResumeBGM()
    {
        bgmSource.UnPause();
    }

    // 점프 사운드 재생
    public void PlayJumpSound()
    {
        if (jumpSound != null)
        {
            sfxSource.PlayOneShot(jumpSound);
        }
    }

    // 체크포인트(지점 통과) 사운드 재생
    public void PlayCheckpointSound()
    {
        if (checkpointSound != null)
        {
            sfxSource.PlayOneShot(checkpointSound);
        }
    }

    // 게임 오버 사운드 재생
    public void PlayGameOverSound()
    {
        if (gameOverSound != null)
        {
            sfxSource.PlayOneShot(gameOverSound);
        }
    }



    // BGM 볼륨 조절
    public void SetBGMVolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        bgmSource.volume = bgmVolume;
    }


}