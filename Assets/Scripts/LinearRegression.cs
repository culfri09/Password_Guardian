using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinearRegression : MonoBehaviour
{
    // Feature weights for linear regression (you need to adjust these based on your training)
    private float lengthWeight = 0.1f;
    private float complexityWeight = 0.2f;
    private float patternWeight = 0.3f;

    // Bias term for linear regression
    private float biasTerm = 0.1f;

    // Evaluate password strength using linear regression
    public float EvaluatePasswordStrength(string password)
    {
        int length = password.Length;
        int complexity = CountComplexity(password);
        int pattern = HasPattern(password) ? 1 : 0;

        // Linear regression equation: strength = bias + length * lengthWeight + complexity * complexityWeight + pattern * patternWeight
        float strength = biasTerm + length * lengthWeight + complexity * complexityWeight + pattern * patternWeight;

        // Scale the result to be between 0 and 20
        float scaledStrength = Mathf.Clamp(strength * 20f, 0f, 20f);
        Debug.Log(scaledStrength);

        return scaledStrength;       
    }

    // Count password complexity (e.g., number of uppercase letters, digits, and special characters)
    private int CountComplexity(string password)
    {
        int complexity = 0;
        foreach (char c in password)
        {
            if (char.IsUpper(c) || char.IsDigit(c) || !char.IsLetterOrDigit(c))
            {
                complexity++;
            }
        }
        return complexity;
    }

    // Check if the password has a certain pattern (e.g., contains both letters and digits)
    private bool HasPattern(string password)
    {
        return password.Any(char.IsLetter) && password.Any(char.IsDigit);
    }

    
}
