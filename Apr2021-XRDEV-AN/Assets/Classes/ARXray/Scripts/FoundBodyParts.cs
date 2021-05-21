using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoundBodyParts : MonoBehaviour
{
    public Image brainImage;
    public Image leftLungImage;
    public Image rightLungImage;
    public Image heartImage;
    public Image stomachImage;
    public Image bladderImage;
    public Image leftKidneyImage;
    public Image rightKidneyImage;
    public Image gudetamaImage;
    public void OnBrainFound()
    {
        brainImage.color = new Color(1,1,1,1);
    }
    public void OnLeftLungFound()
    {
        leftLungImage.color = new Color(1, 1, 1, 1);
    }
    public void OnRightLungFound()
    {
        rightLungImage.color = new Color(1, 1, 1, 1);
    }
    public void OnHeartFound()
    {
        heartImage.color = new Color(1, 1, 1, 1);
    }
    public void OnStomachFound()
    {
        stomachImage.color = new Color(1, 1, 1, 1);
    }
    public void OnBladderFound()
    {
        bladderImage.color = new Color(1, 1, 1, 1);
    }
    public void OnLeftKid()
    {
        leftKidneyImage.color = new Color(1, 1, 1, 1);
    }
    public void OnRightKid()
    {
        rightKidneyImage.color = new Color(1, 1, 1, 1);
    }
    public void OnGudetama()
    {
        gudetamaImage.color = new Color(1, 1, 1, 1);
    }
}
