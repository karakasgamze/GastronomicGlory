using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewPizzaRecipe", menuName = "Pizza Recipe")]
public class PizzaRecipe : ScriptableObject
{
    public string pizzaName;
    public bool tomatosouce, cheese, mushroom, olive;
    public List<string> ingredients;
}

