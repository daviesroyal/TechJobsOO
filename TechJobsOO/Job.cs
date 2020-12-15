using System;
using System.Reflection;
using System.Collections.Generic;
namespace TechJobsOO
{
    public class Job
    {
        public int Id;
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency): this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            string jobInfo = "\n";
            PropertyInfo[] properties = typeof(Job).GetProperties();
            string[] propertyTitles = { "ID", "Name", "Employer", "Location", "Position Type", "Core Competency" };
            int i = 0;
            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(this);
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    jobInfo += $"{propertyTitles[i]}: Data not available\n";
                } else
                {
                    jobInfo += $"{propertyTitles[i]}: {value}\n";
                }
                i++;
            }
            return jobInfo;
        }
    }
}
