using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskListWork
{
    public void WorkTask(Task current_task, Character_Pawn character_pawn)
    {
        if (current_task == null)
            return;
        if (current_task == TaskCreateList.eat)
            EatTask(current_task, character_pawn);
        else if (current_task == TaskCreateList.sleep)
            SleepTask(current_task, character_pawn);
    }
    public void EatTask(Task current_task, Character_Pawn character_pawn)
    {
        
    }
    public void SleepTask(Task current_task, Character_Pawn character_pawn)
    {
        // проверяем находиться ли он в доме
        if (!character_pawn.stateCharacter.is_in_home)
        {
            character_pawn.transform.position = Vector2.MoveTowards(character_pawn.transform.position, character_pawn.home_obj.transform.position, character_pawn.speed * Time.deltaTime);
        }
        else if (character_pawn.stateCharacter.is_in_home && !character_pawn.stateCharacter.is_in_bed)
        {
            character_pawn.transform.position = Vector2.MoveTowards(character_pawn.transform.position, character_pawn.home_obj.GetComponent<HomeSettings>().bed.transform.position, character_pawn.speed * Time.deltaTime);
            if (Vector2.Distance(character_pawn.transform.position, character_pawn.home_obj.GetComponent<HomeSettings>().bed.transform.position) <= character_pawn.speed * Time.deltaTime)
            {
                character_pawn.stateCharacter.is_in_bed = true;
            }
        }
        else if (character_pawn.stateCharacter.is_in_home && character_pawn.stateCharacter.is_in_bed && !character_pawn.stateCharacter.is_sleeping)
        {
            character_pawn.stateCharacter.is_sleeping = true;
        }
        else if (character_pawn.stateCharacter.is_sleeping && character_pawn.sleep < 100)
        {
            character_pawn.sleep += Time.deltaTime;
        }
        else if (character_pawn.stateCharacter.is_sleeping && character_pawn.sleep >= 100)
        {
            character_pawn.sleep = 100;
            character_pawn.stateCharacter.is_sleeping = false;
            character_pawn.tasks.Remove(current_task);
        }
    }
}
