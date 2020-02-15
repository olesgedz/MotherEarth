using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stages of hex progress
public enum ProgressState {
    Nothing,
    Bush,
    Forest,
    Animals,
    StableAnimals,
    Tribe,
    Village,
    City,
    MediumCity,
    MegaCity,
    Winner
};

// Dead or Alive hex state
public enum HexState
{
    Dead,
    Alive
};

//Data class
public class BasicHexEngine : MonoBehaviour, IHexEngine
{
    public class BasicHexModel
    {
        float temperatureBalance;
        float waterBalance;
        float progressPoints;

        float deltaTemperature;
        float deltaWater;
        float deltaProgress;

        ProgressState HexProgressState;

        private HexState state;

        public BasicHexModel()
        {
            temperatureBalance = 0;
            waterBalance = 0;
            deltaTemperature = 0;
            deltaWater = 0;
            deltaProgress = 0;
            progressPoints = 0;
            state = HexState.Dead;
            HexProgressState = ProgressState.Nothing;
        }

        // Getter to know hex state (Dead or Alive)
        public HexState GetState()
        {
            return state;
        }

        // Setter to make state implisitly (Dead or Alive)
        public void SetState(HexState newState)
        {
            state = newState;
        }

        public void MakeProgress(float progresRate)
        {
            progressPoints += progresRate;
        }
    }
    public BasicHexModel hexModel;

    public void Tick()
    {
        return;
    }

    // Make dead a hex block
    public void Die()
    {
        hexModel.SetState(HexState.Dead);
    }

    // Make alive a hex block
    public void Live()
    {
        hexModel.SetState(HexState.Alive);
    }

    // Is Hex is alive
    public HexState IsAlive()
    {
        return hexModel.GetState();
    }

    // Start is called before the first frame update
    void Start()
    {
        hexModel = new BasicHexModel();
    }
}
