﻿using System;

namespace SingletonPattern
{
    class SportsTeamLeader
    {
        static void Main()
        {
            Leader leader1 = Leader.GetCurrentLeader();
            Leader leader2 = Leader.GetCurrentLeader();
            Leader leader3 = Leader.GetCurrentLeader();
            if(leader1 == leader2 && leader2 == leader3){
                Console.WriteLine("Same Guy is Leader");
            }
            // Leader leader4 = new Leader();
            // Leader leader5 = new Leader.GetCurrentLeader();
            // TeamMember member1 = new TeamMember("Member1");
            // TeamMember member2 = new TeamMember("Member1");
            // if(member1 == member2){
            //     Console.WriteLine("Same Guy is Member");
            // }else{
            //     Console.WriteLine("These are different Guys");
            // }
            Console.ReadKey();
        }
    }

    // Singleton
    public sealed class Leader{
        private static readonly Leader chosenLeader = new Leader();
        private Leader(){}
        public static Leader GetCurrentLeader(){
            return chosenLeader;
        }
    }

    // Normal Class
    public class TeamMember{
        private string name;
        public TeamMember(string Name){
            this.name = Name;
        }
    }
}