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
        // �̱��� ���� ����
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
        // AudioSource�� �Ҵ���� ���� ��� �ڵ� ����
        if (bgmSource == null)
        {
            bgmSource = gameObject.AddComponent<AudioSource>();
        }
        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
        }

        // BGM ����
        bgmSource.loop = true;
        bgmSource.volume = bgmVolume;

     
    }

    // BGM ���
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

        // ���� BGM�� �̹� ��� ���̸� �������� ����
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

    // BGM �簳
    public void ResumeBGM()
    {
        bgmSource.UnPause();
    }

    // ���� ���� ���
    public void PlayJumpSound()
    {
        if (jumpSound != null)
        {
            sfxSource.PlayOneShot(jumpSound);
        }
    }

    // üũ����Ʈ(���� ���) ���� ���
    public void PlayCheckpointSound()
    {
        if (checkpointSound != null)
        {
            sfxSource.PlayOneShot(checkpointSound);
        }
    }

    // ���� ���� ���� ���
    public void PlayGameOverSound()
    {
        if (gameOverSound != null)
        {
            sfxSource.PlayOneShot(gameOverSound);
        }
    }



    // BGM ���� ����
    public void SetBGMVolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        bgmSource.volume = bgmVolume;
    }


}