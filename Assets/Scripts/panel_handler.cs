using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class panel_handler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Transform warningPanel;
    [SerializeField]
    public Transform chooseColorPanel;
    [SerializeField]
    public Transform chooseLitAreaPanel;
    [SerializeField]
    public Transform pointToFloorPanel;
    [SerializeField]
    public Transform tapToPlaceObjPanel;
  
    private void Awake()
    {
        PauseGame();
        enablewarningPanel();

    }
    
    public void enablewarningPanel()
    {
        warningPanel.gameObject.SetActive(true);
        chooseColorPanel.gameObject.SetActive(false);
        chooseLitAreaPanel.gameObject.SetActive(false);
        pointToFloorPanel.gameObject.SetActive(false);
        tapToPlaceObjPanel.gameObject.SetActive(false);
    }
    public void enableColorPanel()
    {
        warningPanel.gameObject.SetActive(false);
        chooseColorPanel.gameObject.SetActive(true);
        chooseLitAreaPanel.gameObject.SetActive(false);
        pointToFloorPanel.gameObject.SetActive(false);
        tapToPlaceObjPanel.gameObject.SetActive(false);
    }
    public void enableLitAreaPanel()
    {
        warningPanel.gameObject.SetActive(false);
        chooseColorPanel.gameObject.SetActive(false);
        chooseLitAreaPanel.gameObject.SetActive(true);
        pointToFloorPanel.gameObject.SetActive(false);
        tapToPlaceObjPanel.gameObject.SetActive(false);
    }
    public void enablePointToFloorPanel()
    {
        warningPanel.gameObject.SetActive(false);
        chooseColorPanel.gameObject.SetActive(false);
        chooseLitAreaPanel.gameObject.SetActive(false);
        pointToFloorPanel.gameObject.SetActive(true);
        tapToPlaceObjPanel.gameObject.SetActive(false);
        _ = StartCoroutine(nameof(timer));

    }
    IEnumerator timer()
    {
        ResumeGame();
        
        yield return new WaitForSeconds(3f);
        skipAllPanel();
    }
    public void enableTapToPlaceObjPanel()
    {
        warningPanel.gameObject.SetActive(false);
        chooseColorPanel.gameObject.SetActive(false);
        chooseLitAreaPanel.gameObject.SetActive(false);
        pointToFloorPanel.gameObject.SetActive(false);
        tapToPlaceObjPanel.gameObject.SetActive(true);
    }
    public void skipAllPanel()
    {
        
        
        warningPanel.gameObject.SetActive(false);
        chooseColorPanel.gameObject.SetActive(false);
        chooseLitAreaPanel.gameObject.SetActive(false);
        pointToFloorPanel.gameObject.SetActive(false);
        tapToPlaceObjPanel.gameObject.SetActive(false);
        ResumeGame();
    }
    
    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
