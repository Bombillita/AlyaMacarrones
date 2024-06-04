using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;
    private BattleSystem _bSref;
    private Animator _anim;

    private void Awake()
    {
        _bSref = GameObject.Find("BattleManager").GetComponent<BattleSystem>();
    }

    private void Start()
    {
        _anim = GameObject.Find("ImagenUI").GetComponent<Animator>();
    }

    public void SetUI(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }


    private void Update()
    {
        if (_bSref.isattacking == true)
        {
            _anim.SetBool("isattacking", true);
        }
        else
        {
            _anim.SetBool("isattacking", false);
        }

        if (_bSref.isHealing == true)
        {
            _anim.SetBool("ishurt", true);
        }
        else
        {
            _anim.SetBool("ishurt", false);
        }
    }
}
