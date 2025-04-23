using Microsoft.Unity.VisualStudio.Editor;
using PoseGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public List<GameObject> poseSprites;
    public GameObject upSprite;
    public GameObject downSprite;
    public GameObject leftSprite;
    public GameObject rightSprite;
    public GameObject idleSprite;

    private void Start()
    {
        poseSprites = new List<GameObject> { upSprite, downSprite, leftSprite, rightSprite };
    }
    public void ShufflePose(float duration)
    {
        StartCoroutine(RandomizePose(duration, 0.3f));
    }

    private IEnumerator RandomizePose(float duration, float changeInterval)
    {
        float lap = 0f;
        while (lap < duration)
        {
            GameObject randomPose = poseSprites[Random.Range(0, poseSprites.Count)];
            SetAllPoses(false);
            randomPose.SetActive(true);
            yield return new WaitForSeconds(changeInterval);
            lap += changeInterval;
        }
            SetAllPoses(false);
            idleSprite.SetActive(true);
    }

    private void SetAllPoses(bool active)
    {
        foreach (GameObject pose in poseSprites)
        {
            pose.SetActive(active);
        }
        if (idleSprite != null)
        {
            idleSprite.SetActive(active);
        }
    }
}