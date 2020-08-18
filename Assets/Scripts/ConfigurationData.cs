using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;
    static float deathTimer = 10;
    static float minTimer = 5f;
    static float maxTimer = 10f;
    static float standardBlockScore = 1f;
    static float bonusBlockScore = 5f;
    static float pickupBlockScore = 2f;
    static float standardProb = 0.5f;
    static float bonusProb = 0.2f;
    static float speedupProb = 0.15f;
    static float freezProb = 0.15f;
    static float ballsPerGame = 5f;
    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    public float DeathTimer
    {
        get { return deathTimer; }
    }

    public float MinTimer
    {
        get { return minTimer; }
    }
    public float MaxTimer
    {
        get { return maxTimer; }
    }

    public float StandardBlockScore
    {
        get { return standardBlockScore; }
    }
    public float BonusBlockScore
    {
        get { return bonusBlockScore; }
    }
    public float PickupBlockScore
    {
        get { return pickupBlockScore; }
    }
    public float StProb
    {
        get { return standardProb; }
    }
    public float BsProb
    {
        get { return bonusProb; }
    }
    public float SpProb
    {
        get { return speedupProb; }
    }
    public float FrProb
    {
        get { return freezProb; }
    }
    public float BallsPerGame
    {
        get { return ballsPerGame; }
    }
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            String names = input.ReadLine();
            String values = input.ReadLine();
            SetDetails(values);
        }
        catch(Exception e)
        {

        }
        finally
        {
            if(input != null)
            {
                input.Close();
            }
        }
    }
    static void SetDetails(string data)
    {
        String[] Val = data.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(Val[0]);
        ballImpulseForce = float.Parse(Val[1]);
        deathTimer = float.Parse(Val[2]);
        minTimer = float.Parse(Val[3]);
        maxTimer = float.Parse(Val[4]);
        bonusBlockScore = float.Parse(Val[6]);
        standardBlockScore = float.Parse(Val[5]);
        pickupBlockScore = float.Parse(Val[7]);
        standardProb = float.Parse(Val[8]);
        bonusProb = float.Parse(Val[9]);
        speedupProb = float.Parse(Val[10]);
        freezProb = float.Parse(Val[11]);
        ballsPerGame = float.Parse(Val[12]);
    }

    #endregion
}
