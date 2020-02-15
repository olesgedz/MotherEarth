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
    [SerializeField] const float waterKoef = 0.5f;
    [SerializeField] const float temperatureKoef = 0.5f;

    //Inner data class
    public class BasicHexModel
    {
        public float temperatureBalance;
        public float waterBalance;
        public float progressPoints;
        public float health;

        public float deltaTemperature;
        public float deltaWater;

        private ProgressState hexProgressState;

        private HexState state;

        public BasicHexModel()
        {
            temperatureBalance = 0;
            waterBalance = 0;
            deltaTemperature = 0;
            deltaWater = 0;
            progressPoints = 0;
            state = HexState.Dead;
            hexProgressState = ProgressState.Nothing;
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
            ProgressState newHexProgressState;

            newHexProgressState = (ProgressState)((int)progressPoints);
            if (newHexProgressState < hexProgressState)
            {
                health += progresRate;
            }
            else
            {
                progressPoints += progresRate;
                hexProgressState = newHexProgressState;
            }
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
            hexProgressState = ProgressState.Nothing;
        }
    }
    public  BasicHexModel hexModel;
    int     neiboursCount;
    float   tickProgressDelta;
    float   neigborsEffects;
    [SerializeField] List<BasicHexEngine> hexNeibours = new List<BasicHexEngine>();

    // Start is called before the first frame update
    void Start() {
        hexModel = new BasicHexModel();
        getNeibours();
        neiboursCount = hexNeibours.Count;
    }

    private void getNeibours() {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 0.5f);
        foreach (var gobject in hitColliders)
        {
            Debug.Log(gobject.gameObject.name);

            BasicHexEngine temp;
            if (temp = gobject.GetComponent<BasicHexEngine>())
            {
                if (temp != this.gameObject)
                {
                    hexNeibours.Add(temp);
                }
            }
        }
    }

    // Process Hex on Frame
    public void Tick() {
        if (this.IsAlive())
        {
            tickProgressDelta = tickProgressDelta -
            (hexModel.GetWaterBalance() * waterKoef
            + hexModel.GetTemperatureBalance() * temperatureKoef)
            + 0.01f * Time.deltaTime;
            hexModel.MakeProgress(tickProgressDelta + neigborsEffects / neiboursCount);
            hexModel.waterBalance -= 0.1f * Time.deltaTime;
            hexModel.temperatureBalance -= 0.1f * Time.deltaTime;
            tickProgressDelta -= 0.1f * Time.deltaTime;
            hexModel.ResetEffects();
            if (hexModel.health <= 0)
            {
                this.Die();
            }
        }
        return;
    }

    //Effect neibours
    public void EffectNeibours() {
        if (this.IsAlive())
        {
            foreach (var neibour in hexNeibours)
            {
                neibour.ProgresEffectAddition(tickProgressDelta);
            }
        }
        return;
    }

    // Make dead a hex block
    public void Die() {
        hexModel.SetState(HexState.Dead);
        hexModel.ResetAll();
    }

    // Make alive a hex block
    public void Live() {
        hexModel.SetState(HexState.Alive);
    }

    // Is Hex is alive
    public bool IsAlive() {
        return hexModel.GetState() == HexState.Alive;
    }

    // Set Sun Effect
    public void SetSunEffect(float sunEffect) {
        hexModel.deltaTemperature = sunEffect;
    }

    // Set Water Effect
    public void SetWaterEffect(float waterEffect) {
        hexModel.deltaWater = waterEffect;
    }

    public void ProgresEffectAddition(float progresEffect) {
        neigborsEffects += progresEffect;
    }
}
