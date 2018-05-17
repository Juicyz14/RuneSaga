using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : ISkill {

    private bool isFishable;
    private SkillManager manager;
    private Vector2 previousPosition;

    private float startTime;


    public override void Execute(SkillAction action, GameObject go)
    {
        StartCoroutine(Run(action, go));
    }

    public override void Init(SkillManager manager, Transform t)
    {
        this.manager = manager;
        manager.InterruptSkill += InterruptSkill;
        previousPosition = t.position;
    }

    public override bool Requirements(Transform t)
    {
        const float PositionDifference = 1.1f;
        bool flag = true;

        if ((Mathf.Abs(t.position.x - transform.position.x) >= PositionDifference) ||
            (Mathf.Abs(t.position.y - transform.position.y) >= PositionDifference))
        {
            flag = false;
        }

        return flag;
    }

    private IEnumerator Run(SkillAction action, GameObject go)
    {
        startTime = Time.time;

        Debug.Log("Fishing has begun.");
        yield return new WaitForSeconds(3);

        Inventory.instance.Add(ItemDatabase.instance.getItemById(3000));
        Debug.Log(Inventory.instance);
        

        manager.InterruptSkill -= InterruptSkill;

    }
        // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
