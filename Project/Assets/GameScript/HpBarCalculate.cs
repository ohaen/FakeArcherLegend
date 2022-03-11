using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarCalculate : MonoBehaviour
{
    public Slider slider;
    public Text HPText;
    public GameObject calHPObject;
    private LivingEntity HPObject;
    // Start is called before the first frame update
    void Start()
    {
        HPObject = calHPObject.GetComponent<LivingEntity>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = HPObject.maxHP;
        slider.value = HPObject.currentHP;
        HPText.text = HPObject.currentHP.ToString("F0");
    }
}
