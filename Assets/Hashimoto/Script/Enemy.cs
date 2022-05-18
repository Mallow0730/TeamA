using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    //[Header("SwordBoxをアタッチ")] public GameObject swordBox;
    //[Header("FootBoxをアタッチ")] public GameObject footBox;
    //string tagname1 = "Sword";
    //string tagname2 = "Foot";
    [SerializeField] Scenemanager _sceneManager;
    public Transform[] _points;
    [SerializeField] int _destPoint;
    private NavMeshAgent _agent;

    Vector3 _playerPos;
    GameObject _player;
    float distance;
    [SerializeField] float _trackingRange = 3f;
    [SerializeField] float quitRange = 5f;
    [SerializeField] bool tracking = false;

    [Header("敵のHP")] public int enemyHP;
    [SerializeField] Weapon _weapon;
    int currentHP;

    public Slider slider;
    public Canvas canvas;


    void Start()
    {
        slider.value = 1;
        _agent = GetComponent<NavMeshAgent>();
        
        _agent.autoBraking = false;

        GotoNextPoint();

        _player = GameObject.Find("Player");

        //currentHP = BattleManager.battleInstance.enemyHP;
    }

    private void GotoNextPoint()
    {
        if (_points.Length == 0)
        {
            return;

            _agent.destination = _points[_destPoint].position;

            _destPoint = (_destPoint + 1) % _points.Length;
        }
    }

    private void Update()
    {
        if (enemyHP <= 0)
        {
            BattleManager.battleInstance.experienceScore
                += BattleManager.battleInstance.experience;
            BattleManager.battleInstance.coinScore
                += BattleManager.battleInstance.coin;
            //debug.log(battlemanager.battleinstance.experiencescore);
            //debug.log(battlemanager.battleinstance.coinscore);
            //destroy(this.gameobject);
            this.gameObject.SetActive(false);
        }
        canvas.transform.rotation = Camera.main.transform.rotation;

        _playerPos = _player.transform.position;
        distance = Vector3.Distance(this.transform.position, _playerPos);

        if (tracking)
        {
            if (distance > quitRange)
                tracking = false;
            _agent.destination = _playerPos;
            if (_player != null)
            {
                _sceneManager.FadeOut("GameOverScene");
                Debug.Log("GameOver");
            }
        }
        else
        {
            if (distance < _trackingRange)
                tracking = true;

            if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            enemyHP -= _weapon._attack = 20;
            Debug.Log(enemyHP);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
