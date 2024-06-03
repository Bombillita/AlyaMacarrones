using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    [SerializeField] GameObject Buttons;
    public BattleState state;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerbase;
    public Transform enemybase;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleUI playerUI;
    public BattleUI enemyUI;
    
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerbase);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO =Instantiate(enemyPrefab, enemybase);
        enemyUnit = enemyGO.GetComponent<Unit>();

        Buttons.SetActive(false);


        dialogueText.text = "¡Alya y Ony se preparan para luchar contra " + enemyUnit.unitName + "! ¿Qué harán?";

        playerUI.SetUI(playerUnit);
        enemyUI.SetUI(enemyUnit);

        yield return new WaitForSeconds(5f);

        Debug.Log("hola");
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        //dmg enemigo
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyUI.SetHP(enemyUnit.currentHP);
        dialogueText.text = "bombazo";

        yield return new WaitForSeconds(2f);
        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
    }

    void PlayerTurn()
    {
        Buttons.SetActive(true);
        dialogueText.text = "";
    }
    
    IEnumerator EnemyTurn()
    {
        Buttons.SetActive(false);
        dialogueText.text = enemyUnit.unitName + "ataca";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerUI.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            Buttons.SetActive(true);
        }
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);

        playerUI.SetHP(playerUnit.currentHP);
        dialogueText.text = "Estáis dando volteretas";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());

    }

    void EndBattle()
    {
        Buttons.SetActive(false);
        if (state == BattleState.WON)
        {
            dialogueText.text = "¡Lo han conseguido!";

        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "Han perdido";
        }

    }
}
