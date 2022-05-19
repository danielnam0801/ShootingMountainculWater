using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    //public float enemyDuration2 = 5f;

    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private float enemyDuration;
    [SerializeField]
    private GameObject enemyHpSliderPrefab;
    [SerializeField]
    private Transform canvastransform;
    //[SerializeField]
    //private BGMController bgmController;
    [SerializeField]
    private GameObject textBossWarning;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private GameObject panelBossHP;
    [SerializeField]
    private GameObject enemyprefab;
    [SerializeField]
    private int maxEnemyCount;
    


    bool isMonster = false;

    public bool GetMonster() { return isMonster; }
   

    // Start is called before the first frame update
    private void Awake()
    {
        isMonster = false;
        boss.SetActive(false);
        textBossWarning.SetActive(false);
        panelBossHP.SetActive(false);
        StartCoroutine(SpawnEnemy());
        maxEnemyCount = 10;
        
    }
    private IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0;

        while (true)
        {
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            Vector3 position = new Vector3(positionX, stageData.LimitMax.y+1.0f, 0.0f);
            GameObject enemyclone = Instantiate(enemyprefab,position,Quaternion.identity);
            SpawnEnemyHpSlider(enemyclone);
            currentEnemyCount++;
            enemyDuration = Random.Range(3.5f, 5f);
            
            Debug.Log($"{currentEnemyCount} | {enemyDuration} | {maxEnemyCount}");
            yield return new WaitForSeconds(enemyDuration);

            if (currentEnemyCount == maxEnemyCount)
            {
                isMonster = true;
                Debug.Log("조건 충족");
                StartCoroutine("SpawnBoss");
                break;
            }
            Debug.Log("날아감");
        }
    }

    private void SpawnEnemyHpSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHpSliderPrefab);
        sliderClone.transform.SetParent(canvastransform);
        sliderClone.transform.localScale = Vector3.one;
        sliderClone.GetComponent<SliderPosition>().Setup(enemy.transform);
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHp>());
    }
    
    private IEnumerator SpawnBoss()
    {
        //bgmController.ChangeBGM(BGMType.Boss);
        textBossWarning.SetActive(true);
        //textBossWarning.GetComponent<TextMoving>().ChangeState(TextState.MoveToAppearPoint);
        yield return new WaitForSeconds(1.0f);
        textBossWarning.SetActive(false);
        panelBossHP.SetActive(true);
        boss.SetActive(true);
        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);
         
    }


    
}