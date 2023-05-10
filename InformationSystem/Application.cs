﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    public class Application
    {
        private static int globalId = 0;
        public string Name { get => Name;  set => Name = value; }
        public string Information { get => Information; set => Information = value; }
        public Globals.ApplicationStatus status;
        private int id;
        public int UserId { get => UserId; private set => UserId = value; }
        private int grantId;
        public Application(string name, string information, int userId, int grantId)
        {
            Name = name;
            Information = information;
            status = Globals.ApplicationStatus.Waiting;
            UserId = userId;
            this.grantId = grantId;
            id = ++globalId;
        }

        private float _grade { get; set; }
        public List<int> grades  = new List<int>(); 
        public List<Expert> checkExpersGraded = new List<Expert>();
        public Dictionary<FundHolder, bool> checkApplying  = new Dictionary<FundHolder, bool>();
        public void ApplicationInformation() 
        {

            Console.WriteLine($"Информация о заявке ID: {id} Название: {Name} Информация: {Information} ID пользователя: {UserId} ID гранта: {grantId} Оценка: {_grade}");
        }
        public void SetAverageGrade()
        {
            float sumGrades = 0;
            for (int i = 0; i < grades.Count; i++)
            {
                sumGrades += grades[i];
            }
            _grade = sumGrades/grades.Count;
        }

    }
}
