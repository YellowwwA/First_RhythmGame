using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{

    [SerializeField] GameObject goComboImage = null;
    [SerializeField] UnityEngine.UI.Text txtCombo = null;

    int currentCombo = 0;
    public int maxCombo = 0;

    Animator myAnim;
    string animComboUp = "ComboUp";

    void Start()
    {
        myAnim = GetComponent<Animator>();
        txtCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
    }
    
    public void IncreaseCombo(int p_num = 1)
    {
        currentCombo += p_num;
        txtCombo.text = string.Format("{0:#,##0}", currentCombo);

        if(maxCombo < currentCombo)
            maxCombo = currentCombo;

        if(currentCombo > 2)
        {
            txtCombo.gameObject.SetActive(true);
            goComboImage.SetActive(true);

            myAnim.SetTrigger(animComboUp); //애니메이션 실행 코드
        }
    }

    public int GetCurrentCombo()
    {
        return currentCombo;
    }


    public void ResetCombo()
    {
        currentCombo = 0;
        //maxCombo = 0;
        txtCombo.text = "0";
        txtCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
    }

    public int GetMaxCombo()
    {
        return maxCombo;
    }

}
