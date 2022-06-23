using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] WordScriptableObject _wordScriptableObj;
    [SerializeField] Text _wordText;

    [SerializeField] List<string> _pastWords;

    [SerializeField] List<Transform> _playerPoints;
    [SerializeField] List<Transform> _aipoints;

    [SerializeField] List<GameObject> _stickmansForPlayer;
    [SerializeField] List<GameObject> _stickmansForRival;

    private int count = 0;
    private int aiCount = 0;
    private float _aiWaitCD = 0f;
    private float _aiWaitTime = 8f;

    private float _movementTime = 1f;

    [SerializeField] Transform _firstPosPlayer;
    [SerializeField] Transform _firstPosAI;

    [SerializeField] Transform _finishLine;
    void Start()
    {
        _wordScriptableObj.word = "";
        _wordScriptableObj.letterCount = 0;
    }

    void Update()
    {
        _wordText.text = _wordScriptableObj.word;
        if (Input.GetMouseButtonUp(0))
        {
            foreach (string item in _wordScriptableObj.meaningfulWords)
            {
                if (item.Equals(_wordScriptableObj.word.ToLower()))
                {
                    Debug.Log(_wordScriptableObj.letterCount);
                    _wordScriptableObj.word = "";
                    for (int i = 0; i < _wordScriptableObj.letterCount; i++)
                    {
                        if(count == 14)
                            MoveStickMan(_stickmansForPlayer[count], _finishLine, _movementTime);
                        else
                        {
                            MoveStickMan(_stickmansForPlayer[count], _playerPoints[count], _movementTime);
                            count++;
                        }
                        _movementTime += 0.1f;
                    }
                    break;
                }
            }
            _wordScriptableObj.word = "";
            _wordScriptableObj.letterCount = 0;
        }

        if(Time.time >= _aiWaitCD)
        {
            AIMovementStickMan(_stickmansForRival[aiCount], _aipoints[_aipoints.Count - aiCount -1],1f);
            _aiWaitCD = Time.time + _aiWaitTime;
            aiCount++;
        }

    }

    private void MoveStickMan(GameObject stickman, Transform movePos,float _movementTime)
    {
        stickman.transform.DOMove(_firstPosPlayer.position, 1f).SetEase(Ease.Linear).OnComplete(() => stickman.transform.DOMove(movePos.position, _movementTime).SetEase(Ease.Linear).OnComplete(() => stickman.transform.DORotate(new Vector3(90, 0f, 0f), 0.5f)).OnComplete(()=> RestartGame()));
    }

    private void AIMovementStickMan(GameObject stickman, Transform movePos,float _movementTime)
    {
        stickman.transform.DOMove(_firstPosAI.position, 1f).SetEase(Ease.Linear).OnComplete(() => stickman.transform.DOMove(movePos.position, 2f).SetEase(Ease.Linear).OnComplete(() => stickman.transform.DORotate(new Vector3(-90, 0f, 0f), 0.5f)));
    }

    private void RestartGame()
    {
        if(count >= 14)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
