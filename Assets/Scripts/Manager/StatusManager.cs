using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    [SerializeField] float blinkSpeed = 0.1f;
    [SerializeField] int blinkCount = 5;
    int currentBlinkCount = 0;
    bool isBlink = false;

    int maxHp = 3;
    int currentHp = 3;

    int maxShield = 3;
    int currentShield = 0;

    bool isDead = false;
    Result theResult;
    NoteManager theNote;
    [SerializeField] Image playerMesh = null;

    [SerializeField] Image[] hpImage = null;
    [SerializeField] Image[] shieldImage = null;

    [SerializeField] int shieldIncreaseCombo = 5;
    int currentShieldCombo = 0;
    [SerializeField] Image shieldGuage = null;

    void Start()
    {
        theResult = FindObjectOfType<Result>();
        theNote = FindObjectOfType<NoteManager>();
    }

    public void Initialized()
    {
        currentHp = maxHp;
        currentShield = 0;
        currentShieldCombo = 0;
        shieldGuage.fillAmount = 0;
        isDead = false;
        SettingHPImage();
        SettingShieldImage();
    }

    public void CheckShield()
    {
        currentShieldCombo++;

        if(currentShieldCombo >= shieldIncreaseCombo)
        {
            currentShieldCombo = 0;
            IncreaseShield();
        }

        shieldGuage.fillAmount = (float)currentShieldCombo / shieldIncreaseCombo;

    }

    public void ResetShieldCombo()
    {
        currentShieldCombo = 0;
        shieldGuage.fillAmount = (float)currentShieldCombo / shieldIncreaseCombo;
    }

    public void IncreaseShield()
    {
        currentShield++;

        if(currentShield >= maxShield)
            currentShield = maxShield;

        SettingShieldImage();
    }

    public void DecreaseShield(int p_num)
    {
        currentShield -= p_num;

        if(currentShield <= 0)
            currentShield = 0;

        SettingShieldImage();
    }

    public void IncreaseHP(int p_num)
    {
        currentHp += p_num;
        if(currentHp >= maxHp)
            currentHp = maxHp;

        SettingHPImage();
    }
    
    public void DecreaseHp(int p_num)
    {
        if(!isBlink)
        {
            if(currentShield > 0)
                DecreaseShield(p_num);
            else
            {
                currentHp -= p_num;
                if(currentHp <= 0)
                {
                    Debug.Log("����");
                    theNote.RemoveNote();
                    theResult.ShowResult();
            
                }
                else
                {
                    StartCoroutine(BlinkCo());
                }
                SettingHPImage();
            }

            
        }

    }

    void SettingHPImage()
    {
        for(int i = 0; i<hpImage.Length; i++)
        {
            if(i<currentHp)
                hpImage[i].gameObject.SetActive(true);
            else
                hpImage[i].gameObject.SetActive(false);
        }
    }

    void SettingShieldImage()
    {
        for(int i = 0; i<shieldImage.Length; i++)
        {
            if(i<currentShield)
                shieldImage[i].gameObject.SetActive(true);
            else
                shieldImage[i].gameObject.SetActive(false);
        }
    }

    public bool IsDead()
    {
        return isDead;
    }

    IEnumerator BlinkCo()
    {
        isBlink = true;

        while(currentBlinkCount <= blinkCount)
        {
            playerMesh.enabled = !playerMesh.enabled;
            yield return new WaitForSeconds(blinkSpeed);
            currentBlinkCount++;

        }

        playerMesh.enabled = false;
        currentBlinkCount = 0;
        isBlink = false; 
    }

}
