namespace GeekPeeked.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<GeekPeekedDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GeekPeekedDbContext context)
        {
            var contests = new List<Contest>
            {
                new Contest {Id = 1, ContestType = ContestType.AcademyAwardsBallot, Title = "89th Annual Academy Awards Contest", Objective = "Pick the winners of all 24 Academy Awards Categories", Rules = "Pick one winner for each of the 24 Academy Awards Categories", Results = string.Empty, Standings = string.Empty, StartDateTime = new DateTime(2017, 02, 26, 7, 0, 0), EndDateTime = new DateTime(2017, 02, 27, 1, 0, 0), CreatedBy = "Configuration.Seed()"},
            };

            contests.ForEach(c => context.Contests.Add(c));
            context.SaveChanges();

            var academyAwardsCategories = new List<AcademyAwardsCategory>
            {
                new AcademyAwardsCategory { Id= 01, ContestId = 1, CategoryTitle = "Best Picture", Year = "2017", PointValue = 4, SortOrder = 1, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 02, ContestId = 1, CategoryTitle = "Best Directing", Year = "2017", PointValue = 4, SortOrder = 2, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 03, ContestId = 1, CategoryTitle = "Best Writing (Adapted Screenplay)", Year = "2017", PointValue = 3, SortOrder = 3, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 04, ContestId = 1, CategoryTitle = "Best Writing (Original Screenplay)", Year = "2017", PointValue = 3, SortOrder = 4, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 05, ContestId = 1, CategoryTitle = "Best Actor in a Leading Role", Year = "2017", PointValue = 4, SortOrder = 5, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 06, ContestId = 1, CategoryTitle = "Best Actress in a Leading Role", Year = "2017", PointValue = 4, SortOrder = 6, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 07, ContestId = 1, CategoryTitle = "Best Actor in a Supporting Role", Year = "2017", PointValue = 3, SortOrder = 7, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 08, ContestId = 1, CategoryTitle = "Best Actress in a Supporting Role", Year = "2017", PointValue = 3, SortOrder = 8, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 09, ContestId = 1, CategoryTitle = "Best Animated Feature Film", Year = "2017", PointValue = 3, SortOrder = 9, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 10, ContestId = 1, CategoryTitle = "Best Cinematography", Year = "2017", PointValue = 3, SortOrder = 10, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 11, ContestId = 1, CategoryTitle = "Best Costume Design", Year = "2017", PointValue = 2, SortOrder = 11, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 12, ContestId = 1, CategoryTitle = "Best Documentary (Feature)", Year = "2017", PointValue = 2, SortOrder = 12, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 13, ContestId = 1, CategoryTitle = "Best Documentary (Short Subject)", Year = "2017", PointValue = 2, SortOrder = 13, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 14, ContestId = 1, CategoryTitle = "Best Film Editing", Year = "2017", PointValue = 2, SortOrder = 14, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 15, ContestId = 1, CategoryTitle = "Best Foreign Language Film", Year = "2017", PointValue = 2, SortOrder = 15, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 16, ContestId = 1, CategoryTitle = "Best Makeup and Hairstyling", Year = "2017", PointValue = 2, SortOrder = 16, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 17, ContestId = 1, CategoryTitle = "Best Music (Original Score)", Year = "2017", PointValue = 2, SortOrder = 17, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 18, ContestId = 1, CategoryTitle = "Best Music (Original Song)", Year = "2017", PointValue = 2, SortOrder = 18, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 19, ContestId = 1, CategoryTitle = "Best Production Design", Year = "2017", PointValue = 2, SortOrder = 19, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 20, ContestId = 1, CategoryTitle = "Best Short Film (Animated)", Year = "2017", PointValue = 2, SortOrder = 20, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 21, ContestId = 1, CategoryTitle = "Best Short Film (Live Action)", Year = "2017", PointValue = 2, SortOrder = 21, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 22, ContestId = 1, CategoryTitle = "Best Sound Editing", Year = "2017", PointValue = 2, SortOrder = 22, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 23, ContestId = 1, CategoryTitle = "Best Sound Mixing", Year = "2017", PointValue = 2, SortOrder = 23, CreatedBy = "Configuration.Seed()" },
                new AcademyAwardsCategory { Id= 24, ContestId = 1, CategoryTitle = "Best Visual Effects", Year = "2017", PointValue = 2, SortOrder = 24, CreatedBy = "Configuration.Seed()" }
            };

            academyAwardsCategories.ForEach(c => context.AcademyAwardsCategories.Add(c));
            context.SaveChanges();

            var academyAwardsNominees = new List<AcademyAwardsNominee>
            {
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 01, NomineeText = "Arrival", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 01, NomineeText = "Fences", SortOrder = 1, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 01, NomineeText = "Hacksaw Ridge", SortOrder = 2, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 01, NomineeText = "Hell or High Water", SortOrder = 3, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 01, NomineeText = "Hidden Figures", SortOrder = 4, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 01, NomineeText = "La La Land", SortOrder = 5, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 01, NomineeText = "Lion", SortOrder = 6, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 01, NomineeText = "Manchest By the Sea", SortOrder = 7, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 01, NomineeText = "Moonlight", SortOrder = 8, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 02, NomineeText = "Denis Villeneuve (Arrival)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 02, NomineeText = "Mel Gibson (Hacksaw Ridge)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 02, NomineeText = "Damien Chazelle (La La Land)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 02, NomineeText = "Kenneth Lonergan (Manchester by the Sea)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 02, NomineeText = "Barry Jenkins (Moonlight)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 03, NomineeText = "Arrival", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 03, NomineeText = "Fences", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 03, NomineeText = "Hidden Figures", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 03, NomineeText = "Lion", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 03, NomineeText = "Moonlight", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 04, NomineeText = "Hell or High Water", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 04, NomineeText = "La La Land", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 04, NomineeText = "The Lobster", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 04, NomineeText = "Manchester by the Sea", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 04, NomineeText = "20th Century Women", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 05, NomineeText = "Casey Affleck (Manchester by the Sea)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 05, NomineeText = "Andrew Garfield (Hacksaw Ridge)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 05, NomineeText = "Ryan Gosling (La La Land)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 05, NomineeText = "Viggo Mortensen (Captain Fantastic)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 05, NomineeText = "Denzel Washington (Fences)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 06, NomineeText = "Isabelle Huppert (Elle)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 06, NomineeText = "Ruth Negga (Loving)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 06, NomineeText = "Natalie Portman (Jackie)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 06, NomineeText = "Emma Stone (La La Land)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 06, NomineeText = "Meryl Streep (Florence Foster Jenkins)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 07, NomineeText = "Mahershala Ali (Moonlight)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 07, NomineeText = "Jeff Bridges (Hell or High Water)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 07, NomineeText = "Lucas Hedges (Manchester by the Sea)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 07, NomineeText = "Dev Patel (Lion)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 07, NomineeText = "Michael Shannon (Nocturnal Animals)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 08, NomineeText = "Viola Davis (Fences)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 08, NomineeText = "Naomie Harris (Moonlight)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 08, NomineeText = "Nicole Kidman (Lion)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 08, NomineeText = "Octavia Spencer (Hidden Figures)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 08, NomineeText = "Michelle Williams (Manchester by the Sea)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 09, NomineeText = "Kudo and the Two Strings", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 09, NomineeText = "Moana", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 09, NomineeText = "My Life as a Zucchini", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 09, NomineeText = "The Red Turtle", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 09, NomineeText = "Zootopia", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 10, NomineeText = "Arrival", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 10, NomineeText = "La La Land", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 10, NomineeText = "Lion", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 10, NomineeText = "Moonlight", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 10, NomineeText = "Silence", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 11, NomineeText = "Allied", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 11, NomineeText = "Fantastic Beasts and Where to Find Them", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 11, NomineeText = "Florence Foster Jenkins", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 11, NomineeText = "Jackie", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 11, NomineeText = "La La Land", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 12, NomineeText = "Fire at Sea", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 12, NomineeText = "I Am Not Your Negro", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 12, NomineeText = "Life, Animated", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 12, NomineeText = "O.J.: Made in America", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 12, NomineeText = "13th", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 13, NomineeText = "Extremis", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 13, NomineeText = "4.1 Miles", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 13, NomineeText = "Joe's Violin", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 13, NomineeText = "Watani: My Homeland", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 13, NomineeText = "The White Helmets", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 14, NomineeText = "Arrival", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 14, NomineeText = "Hacksaw Ridge", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 14, NomineeText = "Hell or High Water", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 14, NomineeText = "La La Land", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 14, NomineeText = "Moonlight", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 15, NomineeText = "Land of Mine", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 15, NomineeText = "A Man Called Ove", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 15, NomineeText = "The Salesman", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 15, NomineeText = "Tanna", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 15, NomineeText = "Toni Erdmann", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 16, NomineeText = "A Man Called Ove", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 16, NomineeText = "Star Trek Beyond", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 16, NomineeText = "Suicide Squad", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 17, NomineeText = "Jackie", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 17, NomineeText = "La La Land", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 17, NomineeText = "Lion", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 17, NomineeText = "Moonlight", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 17, NomineeText = "Passengers", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 18, NomineeText = "\"Audition (The Fools Who Dream)\" (La La Land)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 18, NomineeText = "\"Can't Stop The Feeling\" (Trolls)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 18, NomineeText = "\"City Of Stars\" (La La Land)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 18, NomineeText = "\"The Empty Chair\" (Jim: The James Foley Story)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 18, NomineeText = "\"How Far I'll Go\" (Moana)", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 19, NomineeText = "Arrival", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 19, NomineeText = "Fantastic Beasts and Where to Find Them", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 19, NomineeText = "Hail, Caesar!", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 19, NomineeText = "La La Land", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 19, NomineeText = "Passengers", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 20, NomineeText = "Blind Vaysha", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 20, NomineeText = "Borrowed Time", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 20, NomineeText = "Pear Cider and Cigarettes", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 20, NomineeText = "Pearl", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 20, NomineeText = "Piper", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 21, NomineeText = "Ennemis Intérieurs", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 21, NomineeText = "La Femme et le TGV", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 21, NomineeText = "Silent Nights", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 21, NomineeText = "Sing", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 21, NomineeText = "Timecode", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 22, NomineeText = "Arrival", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 22, NomineeText = "Deepwater Horizon", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 22, NomineeText = "Hacksaw Ridge", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 22, NomineeText = "La La Land", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 22, NomineeText = "Sully", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 23, NomineeText = "Arrival", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 23, NomineeText = "Hacksaw Ridge", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 23, NomineeText = "La La Land", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 23, NomineeText = "Rogue One: A Star Wars Story", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 23, NomineeText = "13 Hours: The Secret Soldiers of Benghazi", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 24, NomineeText = "Deepwater Horizon", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 24, NomineeText = "Doctor Strange", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 24, NomineeText = "The Jungle Book", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 24, NomineeText = "Kubo and the Two Strings", SortOrder = 0, CreatedBy ="Configuration.Seed()" },
                new AcademyAwardsNominee { AcademyAwardsCategoryId = 24, NomineeText = "Rogue One: A Star Wars Story", SortOrder = 0, CreatedBy ="Configuration.Seed()" }
            };

            academyAwardsNominees.ForEach(n => context.AcademyAwardsNominees.Add(n));
            context.SaveChanges();
        }
    }
}
