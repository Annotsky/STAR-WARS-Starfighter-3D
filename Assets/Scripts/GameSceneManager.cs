using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private float timeToReload = 1;
    
    public void ReloadLevel()
    {
        StartCoroutine(ReloadLevelRoutine());
    }
    
    private IEnumerator ReloadLevelRoutine()
    {
        yield return new WaitForSeconds(timeToReload);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}