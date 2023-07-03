using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskList
{
    public static Task eat = new("Eat", TaskPriority.Medium);
    public static Task sleep = new("Sleep", TaskPriority.Medium);
    public static Task move = new("Move", TaskPriority.VeryHigh);
    public static Task idle = new("Idle", TaskPriority.Low);
    public static Task attack = new("Attack", TaskPriority.High);
}
