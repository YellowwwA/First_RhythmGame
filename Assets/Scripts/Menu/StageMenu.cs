using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] //�ν����� â���� ���� �� �߰� �����ϰ� �ϱ� ���� �ڵ�
public class Song
{
    public string name;
    public string composer;
    public int bpm;
    public Sprite sprite; //�뷡 �̹��� �ٲٱ� �����ڵ�
}

public class StageMenu : MonoBehaviour
{
    [SerializeField] Song[] songList = null;
    [SerializeField] Text txtSongName = null;
    [SerializeField] Text txtSongComposer = null;
    [SerializeField] Image imgDisk = null;

    [SerializeField] Text txtSongScore = null;

    [SerializeField] GameObject TitleMenu = null;

    DatabaseManager theDatabase;

    int currentSong = 0;

    Result theResult;

    ComboManager theCombo;

    void Start()
    {
        theResult = FindObjectOfType<Result>();
        theCombo = FindObjectOfType<ComboManager>();
    }

    void OnEnable()
    {
        if(theDatabase == null)
            theDatabase = FindObjectOfType<DatabaseManager>();

        SettingSong();
    }

    public void BtnNext()
    {
        AudioManager.instance.PlaySFX("Touch");

        if(++currentSong > songList.Length - 1)
            currentSong = 0;
        SettingSong();
    }

    public void BtnPrior()
    {
        AudioManager.instance.PlaySFX("Touch");

        if(--currentSong < 0)
            currentSong = songList.Length - 1;
        SettingSong();
    }

    void SettingSong()
    {
        txtSongName.text = songList[currentSong].name;
        txtSongComposer.text = songList[currentSong].composer;
        txtSongScore.text = string.Format("{0:#,##0}", theDatabase.score[currentSong]);
        imgDisk.sprite = songList[currentSong].sprite;

        AudioManager.instance.PlayBGM("BGM" + currentSong);
    }

    public void BtnBack()
    {
        TitleMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void BtnPlay()
    {
        int t_bpm = songList[currentSong].bpm;
        theCombo.maxCombo = 0;
        GameManager.instance.GameStart(currentSong, t_bpm);
        this.gameObject.SetActive(false);

    }
    public void BtnReplay()
    {
        int t_bpm = songList[currentSong].bpm;
        theCombo.maxCombo = 0;
        theCombo.ResetCombo();
        GameManager.instance.GameStart(currentSong, t_bpm);
        theResult.gameObject.SetActive(false);
    }


}
