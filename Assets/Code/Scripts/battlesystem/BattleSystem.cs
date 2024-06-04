using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    [SerializeField] GameObject Buttons;
    public BattleState state;
    public GameObject playerPrefab;
    public GameObject enemytutoPrefab;
    public GameObject enemyPrefab;
    private bool isTutorial;
    public bool isHealing = false;
    public bool isattacking = false;

    public static bool enemydefeated;

    public Transform playerbase;
    public Transform enemybase;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleUI playerUI;
    public BattleUI enemyUI;

    private LevelUIController _uiref;

    void Start()
    {
        state = BattleState.START;
        _uiref = GameObject.Find("Canvasfs").GetComponent<LevelUIController>();
        _uiref.FadeFromBlack();
        StartCoroutine(SetUpBattle());
        CombatOnTrigger.istutorial = isTutorial;
    }

    IEnumerator SetUpBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerbase);
        playerUnit = playerGO.GetComponent<Unit>();

        //GameObject enemyGO = Instantiate(enemyPrefab, enemybase);
        //enemyUnit = enemyGO.GetComponent<Unit>();

        if (CombatOnTrigger.istutorial == true)
        {
            GameObject enemyGO = Instantiate(enemytutoPrefab, enemybase);
            enemyUnit = enemyGO.GetComponent<Unit>();

        }
        else
        {
            GameObject enemyGO = Instantiate(enemyPrefab, enemybase);
            enemyUnit = enemyGO.GetComponent<Unit>();
        }


        Buttons.SetActive(false);


        dialogueText.text = "¡Alya y Ony se preparan para luchar contra " + enemyUnit.unitName + "!";

        playerUI.SetUI(playerUnit);
        enemyUI.SetUI(enemyUnit);

        yield return new WaitForSeconds(3f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyUI.SetHP(enemyUnit.currentHP);
        dialogueText.text = "¡Ony ataca!";
        isattacking = true;

        yield return new WaitForSeconds(2f);
        if (isDead)
        {
            isattacking = false;
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            isattacking = false;
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
    }

    void PlayerTurn()
    {
        Buttons.SetActive(true);
        dialogueText.text = "¿Qué harán?";
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
        playerUnit.Heal(7);
        playerUI.SetHP(playerUnit.currentHP);
        isHealing = true;

        dialogueText.text = "Estáis dando volteretas";

        yield return new WaitForSeconds(2f);
        isHealing = false;
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator ComeBack()
    {
        yield return new WaitForSeconds(2f);
        _uiref.FadeToBlack();
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Bosque2");
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
           if (CombatOnTrigger.istutorial == true)
            {
                CombatOnTrigger.istutorial = false;
            }

            dialogueText.text = "¡Lo han conseguido!";
            enemydefeated = true;
            StartCoroutine(ComeBack());
        }
        else if (state == BattleState.LOST)
        {
            
            dialogueText.text = "Han perdido";
            enemydefeated = false;
            StartCoroutine(ComeBack());
        }

    }
}
