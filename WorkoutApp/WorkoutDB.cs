
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WorkoutApp
{
    public class WorkoutDB : DbContext
    {
        public WorkoutDB()
            : base("name=WorkoutDB")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutPart> WorkoutParts { get; set; }
        public DbSet<WorkoutPartLog> WorkoutPartLogs { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseDescription> ExerciseDescriptions { get; set; }
        public DbSet<ExerciseLog> ExerciseLogs { get; set; }

    }

    public class User
    {
        public User() { }
        public User(string name, string email)
        {
            UserName = name;
            Email = email;
        }

        public string UserName { get; set; }
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public WorkoutPlan InProgress { get; set; }
        public WorkoutPlan NextWorkout { get; set; }
        public WorkoutPlan LastCompletedWorkout { get; set; }
        public List<WorkoutPlan> WorkoutPlans { get; set; }
    }

    public class WorkoutPlan
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class Exercise
    {
        public int Id { get; set; }
        public ExerciseDescription description { get; set; }
        public int NomOfSets { get; set; }
        public int Repititions { get; set; }
        public string Comments { get; set; }
        public List<ExerciseLog> ExerciseHistory { get; set; }
    }

    public class ExerciseDescription
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Equipment { get; set; }
        public string VideoLink { get; set; }
    }

    public class ExerciseLog
    {
        [Key]
        public int Id { get; set; }
        public DateTime ExecutionDate { get; set; }
        public List<(int, int)> Info { get; set; } //Repititions, weight
    }

    public class WorkoutPartLog
    {
        [Key]
        public int Id { get; set; }
        public DateTime ExecutionDate { get; set; }
        public WorkoutPart workoutPart { get; set; }
    }

    public class WorkoutPart
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Exercise> Exercises { get; set; }

    }
}
