using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvas : MonoBehaviour
{
    public List<GameObject> tutorialPages;
    public int index = 0;

    private bool cursorUp = false;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void Update()
    {
        
    }

    public void CyclePages(bool progressDireciton)
    {
        if (progressDireciton)
        {
            if (index < tutorialPages.Count)
                index++;
        }
        else
        {
            if (index > 0)
                index--;
        }

        for (int i = 0; i < tutorialPages.Count; i++)
        {
            tutorialPages[i].SetActive(false);
        }
        tutorialPages[index].SetActive(true);
    }

    public void ClosePages()
    {
        for (int i = 0; i < tutorialPages.Count; i++)
        {
            tutorialPages[i].SetActive(false);
        }
        cursorUp = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameObject.SetActive(false);
    }
}
