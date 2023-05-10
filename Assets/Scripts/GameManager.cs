using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum State { Gaming, Clear, Dead, End };
    private State state = State.Gaming;
    static GameManager gameManager;
    public GameObject player, mummy;
    public GameObject[] weapons;
    public Text scoreText, timeText;
    private float score { get; set; }
    private float time { get; set; }

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mummy.GetComponent<AutoMovement>().speed = Menu.gameSpeed * -0.3f;
        score = time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.End)
            return;

        if (state != State.Gaming)
        {
            GetComponent<KeyInput>().enabled = false;
            AudioManager.StopBackgroundAudio();
            if (state == State.Clear)
                player.GetComponent<Animator>().SetBool("isClear", true);
            if (state == State.Dead)
                player.GetComponent<Animator>().SetBool("isDead", true);
            state = State.End;
        }

        time += Time.deltaTime;
        timeText.text = ((int)time).ToString() + "'s";
        scoreText.text = score.ToString();
    }

    public void PlayerAttack()
    {
        int rand = new System.Random().Next(0, 13);
        Vector3 pos = player.transform.position;
        pos = new Vector3(pos.x - 1, pos.y + 0.5f, pos.z);
        GameObject obj = Instantiate(weapons[rand], pos, Quaternion.identity);
        AudioManager.PlayAttackAudio();
        player.GetComponent<Animator>().SetBool("attack", true);
    }

    public static void GotoMenu()
    {
        gameManager.Invoke("LoadMenu", 5f);
    }

    private void LoadMenu()
    {
        Menu.gameSpeed = 1;
        SceneManager.LoadScene(0);
    }

    public static void AddScore(int score)
    {
        gameManager.score += score;
    }

    public static void SetState(State state)
    {
        gameManager.state = state;
    }
}
