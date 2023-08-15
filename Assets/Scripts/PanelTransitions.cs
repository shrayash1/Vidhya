using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PanelTransitions : MonoBehaviour
{
    private enum location { up,down,left,right};
    [SerializeField] location disableLocation;
    [SerializeField] CanvasGroup bgPanel;
    [SerializeField] RectTransform mainPanel;
    [SerializeField] Ease easeType;
    [SerializeField] Transform specificPos;
    private float mainPanelTransitionspeed = 2f;

    private void OnEnable()
    {
        if (specificPos == null)
        {
            openUI();
        }
        else
            openUI(specificPos);
    }
    private void openUI()
    {
        bgPanel.alpha = 0;
        bgPanel.DOFade(1, 0.5f).SetUpdate(true);
        switch (disableLocation)
        {
            case location.up:
                mainPanel.localPosition = new Vector2(0, Screen.height);
                mainPanel.DOAnchorPos(Vector2.zero, mainPanelTransitionspeed).SetUpdate(true).SetEase(easeType);
                break;
            case location.down:
                mainPanel.localPosition = new Vector2(0, -Screen.height);
                mainPanel.DOAnchorPos(Vector2.zero, mainPanelTransitionspeed).SetUpdate(true).SetEase(easeType);
                break;
            case location.left:
                mainPanel.localPosition = new Vector2(-Screen.width, 0);
                mainPanel.DOAnchorPos(Vector2.zero, mainPanelTransitionspeed).SetUpdate(true).SetEase(easeType);
                break;
            case location.right:
                mainPanel.localPosition = new Vector2(Screen.width, 0);
                mainPanel.DOAnchorPos(Vector2.zero, mainPanelTransitionspeed).SetUpdate(true).SetEase(easeType);
                break;
        }
    }
    private void openUI(Transform pos)
    {
        bgPanel.alpha = 0;
        bgPanel.DOFade(1, 0.5f).SetUpdate(true);
        switch (disableLocation)
        {
            case location.up:
                mainPanel.localPosition = new Vector2(0, Screen.height);
                mainPanel.DOAnchorPos(pos.position, mainPanelTransitionspeed).SetUpdate(true).SetEase(easeType);
                break;
            case location.down:
                mainPanel.localPosition = new Vector2(0, -Screen.height);
                mainPanel.DOAnchorPos(pos.position, mainPanelTransitionspeed).SetUpdate(true).SetEase(easeType);
                break;
            case location.left:
                mainPanel.localPosition = new Vector2(-Screen.width, 0);
                mainPanel.DOAnchorPos(pos.position, mainPanelTransitionspeed).SetUpdate(true).SetEase(easeType);
                break;
            case location.right:
                mainPanel.localPosition = new Vector2(Screen.width, 0);
                mainPanel.DOAnchorPos(pos.position, mainPanelTransitionspeed).SetUpdate(true).SetEase(easeType);
                break;
        }
    }
    public void closeUI()
    {
        switch (disableLocation)
        {
            case location.up:
                mainPanel.DOAnchorPos(new Vector2(0, Screen.height), mainPanelTransitionspeed).SetUpdate(true).SetEase(easeType);
                break;
            case location.down:
                mainPanel.DOAnchorPos(new Vector2(0, -Screen.height), mainPanelTransitionspeed).SetUpdate(true).SetEase(easeType);
                break;
            case location.left:
                mainPanel.DOAnchorPos(new Vector2(-Screen.width, 0), mainPanelTransitionspeed).SetUpdate(true).SetEase(easeType);
                break;
            case location.right:
                mainPanel.DOAnchorPos(new Vector2(Screen.width, 0), mainPanelTransitionspeed).SetUpdate(true).SetEase(easeType);
                break;
        }
        bgPanel.DOFade(0, 0.5f).SetUpdate(true).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
    
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        Time.timeScale = 0;
    //    }
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        closeUI();
    //    }
    //}
}
