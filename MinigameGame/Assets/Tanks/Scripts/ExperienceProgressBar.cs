using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.MUIP;


public class ExperienceProgressBar : MonoBehaviour
{
    [SerializeField] private PlayerExperienceManager playerExperienceManager;
    [SerializeField] private ProgressBar progressBar;

    private void Start()
    {
        playerExperienceManager.OnExperienceGained += HandleOnExperienceGained;
    }

    private void HandleOnExperienceGained(double last, double next, double current)
    {
        float percentage = (float)((current - last) / (next - last)) * 100;

        Debug.Log($"{last}, {next}, {current} - {percentage}");

        if (percentage > 100)
            percentage -= 100;

        progressBar.ChangeValue(percentage);
    }
}
