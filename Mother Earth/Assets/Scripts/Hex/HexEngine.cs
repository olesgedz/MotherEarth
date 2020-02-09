using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ProgressState { Nothing, Bush, Forest, Animals, StableAnimals, Tribe, Village, City, MediumCity, MegaCity, Winner};
public enum HexState { Dead, Alive}

interface IHexEngine
{
    void Tick();
    void Die();
    void Live();
    HexState IsAlive();
}

//Data class
public class BasicHexEngine : MonoBehaviour, IHexEngine
{
    public class BasicHexModel
    {
        int temperatureBalance;
        int waterBalance;
        int progressPoints;

        int deltaTemperature;
        int deltaWater;
        int deltaProgress;

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

        public HexState GetState()
        {
            return state;
        }

        public void SetState(HexState newState)
        {
            state = newState;
        }
    }
    public BasicHexModel hexModel;

    public void Tick()
    {
        return;
    }

    public void Die()
    {
        hexModel.SetState(HexState.Dead);
    }

    public void Live()
    {
        hexModel.SetState(HexState.Alive);
    }

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
