using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtons : MonoBehaviour
{
    public TutorialCanvas tutorialCanvas;

    public void Progress()
    {
        GameObject.FindWithTag("SFX").GetComponent<AudioSource>().PlayOneShot(GameObject.FindWithTag("SFX").GetComponent<SFXManager>().buttonPress);
        if (tutorialCanvas.index != tutorialCanvas.tutorialPages.Count - 1)
            tutorialCanvas.CyclePages(true);
        else
            tutorialCanvas.ClosePages();
    }

    public void Unprogress()
    {
        GameObject.FindWithTag("SFX").GetComponent<AudioSource>().PlayOneShot(GameObject.FindWithTag("SFX").GetComponent<SFXManager>().buttonPress);
        tutorialCanvas.CyclePages(false);
    }

}
