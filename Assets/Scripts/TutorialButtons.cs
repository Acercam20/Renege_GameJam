using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtons : MonoBehaviour
{
    public TutorialCanvas tutorialCanvas;

    public void Progress()
    {
        if (tutorialCanvas.index != tutorialCanvas.tutorialPages.Count - 1)
            tutorialCanvas.CyclePages(true);
        else
            tutorialCanvas.ClosePages();
    }

    public void Unprogress()
    {
        tutorialCanvas.CyclePages(false);
    }

}
