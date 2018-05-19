using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : ISkill {

    public Fishy fish;

    private bool isFishable;
    private bool fishing;
    private SkillManager manager;
    private Vector2 previousPosition;

    private float startTime;

    public void Awake()
    {
        isFishable = true;
        GameInputManager.ObserveMouseButton(0);
        GameInputManager.Register(OnInputEvent);
    }

    private void OnInputEvent(GameInputManager.EventData data)
    {
        if (fishing)
        {
            Debug.Log("Caught the fish!");
            Inventory.instance.Add(fish.itemId);
            AddXpToSkill(SkillType.Fishing, fish.xp);

        }
    }

    public override void Execute(SkillAction action, GameObject go)
    {
        StartCoroutine(Run(action, go));
    }

    public override void Init(Transform t)
    {
        manager.InterruptSkill += InterruptSkill;
        previousPosition = t.position;
    }

    public override bool Requirements(SkillManager manager, Transform t)
    {
        this.manager = manager;
        const float PositionDifference = 1.1f;
        bool flag = true;

        if ((Mathf.Abs(t.position.x - transform.position.x) >= PositionDifference) ||
            (Mathf.Abs(t.position.y - transform.position.y) >= PositionDifference))
        {
            flag = false;
        }

        return flag && isFishable;
    }

    private IEnumerator Run(SkillAction action, GameObject go)
    {
        while (true)
        {
            startTime = Time.time;
            isFishable = false;


            Debug.Log("Fishing has begun.");
            yield return new WaitForSeconds(3);

            int random = Random.Range(0, 3);
            while (random != 1)
            {
                Debug.Log("didnt find a fish...");
                yield return new WaitForSeconds(1);
                random = Random.Range(0, 3);
            }

            fishing = true;

            Debug.Log("Got a bite! Click your mouse!");
            //Inventory.instance.Add(ItemDatabase.instance.GetItemById(3000));
            //Debug.Log(Inventory.instance);

            yield return new WaitForSeconds(1);

            fishing = false;


            manager.InterruptSkill -= InterruptSkill;
            break;
        }

        isFishable = true;


    }
        // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
