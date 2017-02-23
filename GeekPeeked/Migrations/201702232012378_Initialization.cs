namespace GeekPeeked.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademyAwardsBallotPick",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        VerificationCode = c.String(),
                        IsVerfied = c.Boolean(nullable: false),
                        ContestId = c.Int(nullable: false),
                        AcademyAwardsCategoryId = c.Int(nullable: false),
                        SelectedAcademyAwardsNomineeId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AcademyAwardsCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContestId = c.Int(nullable: false),
                        CategoryTitle = c.String(),
                        Year = c.String(),
                        PointValue = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contest", t => t.ContestId, cascadeDelete: true)
                .Index(t => t.ContestId);
            
            CreateTable(
                "dbo.AcademyAwardsNominee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AcademyAwardsCategoryId = c.Int(nullable: false),
                        NomineeText = c.String(),
                        IsWinner = c.Boolean(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademyAwardsCategory", t => t.AcademyAwardsCategoryId, cascadeDelete: true)
                .Index(t => t.AcademyAwardsCategoryId);
            
            CreateTable(
                "dbo.Contest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContestType = c.Int(nullable: false),
                        Title = c.String(),
                        Objective = c.String(),
                        Rules = c.String(),
                        Results = c.String(),
                        Standings = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AcademyAwardsCategory", "ContestId", "dbo.Contest");
            DropForeignKey("dbo.AcademyAwardsNominee", "AcademyAwardsCategoryId", "dbo.AcademyAwardsCategory");
            DropIndex("dbo.AcademyAwardsNominee", new[] { "AcademyAwardsCategoryId" });
            DropIndex("dbo.AcademyAwardsCategory", new[] { "ContestId" });
            DropTable("dbo.Contest");
            DropTable("dbo.AcademyAwardsNominee");
            DropTable("dbo.AcademyAwardsCategory");
            DropTable("dbo.AcademyAwardsBallotPick");
        }
    }
}
