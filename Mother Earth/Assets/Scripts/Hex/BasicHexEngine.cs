using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stages of hex progress
public enum ProgressState {
    Nothing = 0,
    Bush = 32,
    Forest = 128,
    Animals = 512,
    StableAnimals = 1024,
    Tribe = 2048,
    Village = 4096,
    City = 8192,
    MediumCity = 16384,
    MegaCitн = 32768,
    Winner = 65536
};

// Dead or Alive hex state
public enum HexState {
    Dead,
    Alive
};

public class BasicHexEngine : MonoBehaviour, IHexEngine {
    const float waterKoef = 0.5f;
    const float temperatureKoef = 0.5f;

    //Inner data class
    public class BasicHexModel
    {
        public float temperatureBalance;
        public float waterBalance;
        public float progressPoints;

        public float deltaTemperature;
        public float deltaWater;

        private ProgressState HexProgressState;

        private HexState state;

        public BasicHexModel()
        {
            temperatureBalance = 0;
            waterBalance = 0;
            deltaTemperature = 0;
            deltaWater = 0;
            progressPoints = 0;
            state = HexState.Dead;
            HexProgressState = ProgressState.Nothing;
        }

        // Getter to know hex state (Dead or Alive)
        public HexState GetState()
        {
            return state;
        }

        // Setter to change state (Dead or Alive)
        public void SetState(HexState newState)
        {
            state = newState;
        }
        // Add to progressPoints value
        public void MakeProgress(float progresRate)
        {
            progressPoints += progresRate;
        }

        public float GetWaterBalance()
        {
            waterBalance += waterBalance + deltaWater * Time.deltaTime;
            return System.Math.Abs(waterBalance);
        }

        public float GetTemperatureBalance()
        {
            temperatureBalance += temperatureBalance + deltaTemperature * Time.deltaTime;
            return System.Math.Abs(temperatureBalance);
        }

        public void ResetEffects()
        {
            deltaTemperature = 0;
            deltaWater = 0;
        }

        public void ResetAll()
        {
            temperatureBalance = 0;
            waterBalance = 0;
            deltaTemperature = 0;
            deltaWater = 0;
            progressPoints = 0;
            state = HexState.Dead;
            HexProgressState = ProgressState.Nothing;
        }
    }
    public  BasicHexModel hexModel;
    int     neiboursCount;
    float   tickProgressDelta;

    // Start is called before the first frame update
    void Start()
    {
        hexModel = new BasicHexModel();
    }

    // Process Hex on Frame
    public void Tick()
    {
        if (this.IsAlive())
        {
            tickProgressDelta = tickProgressDelta -
            (hexModel.GetWaterBalance() * waterKoef
            + hexModel.GetTemperatureBalance() * temperatureKoef)
            + 0.01f * Time.deltaTime;
            hexModel.MakeProgress(tickProgressDelta);
        }
        hexModel.waterBalance -= 0.1f * Time.deltaTime;
        hexModel.temperatureBalance -= 0.1f * Time.deltaTime;
        tickProgressDelta -= 0.1f * Time.deltaTime;
        hexModel.ResetEffects();
        return;
    }

    // Make dead a hex block
    public void Die()
    {
        hexModel.SetState(HexState.Dead);
        hexModel.ResetAll();
    }

    // Make alive a hex block
    public void Live()
    {
        hexModel.SetState(HexState.Alive);
    }

    // Is Hex is alive
    public bool IsAlive()
    {
        return hexModel.GetState() == HexState.Alive;
    }

    // Set Sun Effect
    public void SetSunEffect(float sunEffect)
    {
        hexModel.deltaTemperature = sunEffect;
    }

    // Set Water Effect
    public void SetWaterEffect(float waterEffect)
    {
        hexModel.deltaWater = waterEffect;
    }
}
