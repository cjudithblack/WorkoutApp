namespace WorkoutApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExerciseDescriptions",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Equipment = c.String(),
                        VideoLink = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.ExerciseLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExecutionDate = c.DateTime(nullable: false),
                        Exercise_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercises", t => t.Exercise_Id)
                .Index(t => t.Exercise_Id);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomOfSets = c.Int(nullable: false),
                        Repititions = c.Int(nullable: false),
                        Comments = c.String(),
                        description_Name = c.String(maxLength: 128),
                        WorkoutPart_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExerciseDescriptions", t => t.description_Name)
                .ForeignKey("dbo.WorkoutParts", t => t.WorkoutPart_Name)
                .Index(t => t.description_Name)
                .Index(t => t.WorkoutPart_Name);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        Password = c.String(),
                        InProgress_Name = c.String(maxLength: 128),
                        LastCompletedWorkout_Name = c.String(maxLength: 128),
                        NextWorkout_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.WorkoutPlans", t => t.InProgress_Name)
                .ForeignKey("dbo.WorkoutPlans", t => t.LastCompletedWorkout_Name)
                .ForeignKey("dbo.WorkoutPlans", t => t.NextWorkout_Name)
                .Index(t => t.InProgress_Name)
                .Index(t => t.LastCompletedWorkout_Name)
                .Index(t => t.NextWorkout_Name);
            
            CreateTable(
                "dbo.WorkoutPlans",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        User_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Users", t => t.User_Email)
                .Index(t => t.User_Email);
            
            CreateTable(
                "dbo.WorkoutPartLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExecutionDate = c.DateTime(nullable: false),
                        workoutPart_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkoutParts", t => t.workoutPart_Name)
                .Index(t => t.workoutPart_Name);
            
            CreateTable(
                "dbo.WorkoutParts",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkoutPartLogs", "workoutPart_Name", "dbo.WorkoutParts");
            DropForeignKey("dbo.Exercises", "WorkoutPart_Name", "dbo.WorkoutParts");
            DropForeignKey("dbo.WorkoutPlans", "User_Email", "dbo.Users");
            DropForeignKey("dbo.Users", "NextWorkout_Name", "dbo.WorkoutPlans");
            DropForeignKey("dbo.Users", "LastCompletedWorkout_Name", "dbo.WorkoutPlans");
            DropForeignKey("dbo.Users", "InProgress_Name", "dbo.WorkoutPlans");
            DropForeignKey("dbo.ExerciseLogs", "Exercise_Id", "dbo.Exercises");
            DropForeignKey("dbo.Exercises", "description_Name", "dbo.ExerciseDescriptions");
            DropIndex("dbo.WorkoutPartLogs", new[] { "workoutPart_Name" });
            DropIndex("dbo.WorkoutPlans", new[] { "User_Email" });
            DropIndex("dbo.Users", new[] { "NextWorkout_Name" });
            DropIndex("dbo.Users", new[] { "LastCompletedWorkout_Name" });
            DropIndex("dbo.Users", new[] { "InProgress_Name" });
            DropIndex("dbo.Exercises", new[] { "WorkoutPart_Name" });
            DropIndex("dbo.Exercises", new[] { "description_Name" });
            DropIndex("dbo.ExerciseLogs", new[] { "Exercise_Id" });
            DropTable("dbo.WorkoutParts");
            DropTable("dbo.WorkoutPartLogs");
            DropTable("dbo.WorkoutPlans");
            DropTable("dbo.Users");
            DropTable("dbo.Exercises");
            DropTable("dbo.ExerciseLogs");
            DropTable("dbo.ExerciseDescriptions");
        }
    }
}
