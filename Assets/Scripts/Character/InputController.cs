using UnityEngine;

[RequireComponent(typeof(JetpackContoller))]
public class InputController : MonoBehaviour
{
    private JetpackContoller jetpack;
    private bool isMobile => GameManager.Instance.isMobileDevice;

    private void Awake()
    {
        jetpack = gameObject.GetComponent<JetpackContoller>();
    }

    private void Update()
    {
        if(!GameManager.Instance.isGameActive) return;

        if(Input.touchCount > 0 && isMobile)
        {
            CatchUserMobileInput();
            return;
        }

        if(!isMobile)
        {
            CatchUserEditorInput();
        }
    }

    #region Windows Input
    private void CatchUserEditorInput()
    {
        if(Input.GetMouseButton(0))
        {
            jetpack.FlyTheJetpack();
        }
        else
        {
            jetpack.StopFlyTheJetpack();
        }
    }
    #endregion

    #region MOBILE Input
    private void CatchUserMobileInput()
    {
        Touch[] touches = Input.touches;
        bool result = false;
        foreach(Touch touch in touches)
        {
            if(touch.phase != TouchPhase.Ended)
            {
                result = true;
                break;
            }
        }

        if(result)
        {
            jetpack.FlyTheJetpack();
        }
        else
        {
            jetpack.StopFlyTheJetpack();
        }
    }
    #endregion
}
