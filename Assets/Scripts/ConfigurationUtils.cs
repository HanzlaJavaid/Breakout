using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Properties

    public static ConfigurationData config;
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return config.PaddleMoveUnitsPerSecond; }
    }

    public static float ballImpulseForce
    {
        get { return config.BallImpulseForce; }
    }

    public static float DeathTimer
    {
        get { return config.DeathTimer; }
    }

    public static float minTimer
    {
        get { return config.MinTimer; }
    }

    public static float maxTimer
    {
        get { return config.MaxTimer; }
    }

    public static float StandardBlockScore
    {
        get { return config.StandardBlockScore; }
    }

    public static float BonusBlockScore
    {
        get { return config.BonusBlockScore; }
    }

    public static float PickupBlockScore
    {
        get { return config.PickupBlockScore; }
    }

    public static float StProb
    {
        get { return config.StProb; }
    }
    public static float BsProb
    {
        get { return config.BsProb; }
    }
    public static float SpProb
    {
        get { return config.SpProb; }
    }
    public static float FrProb
    {
        get { return config.FrProb; }
    }
    public static float BallsPerGame
    {
        get { return config.BallsPerGame; }
    }
    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        config = new ConfigurationData();
    }
}
