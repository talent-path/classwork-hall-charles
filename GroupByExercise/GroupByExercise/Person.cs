using System;
namespace GroupByExercise
{
    public class Person
    {
        public int Id { get; }
        public City HomeCity { get; }
        
        public Person( int id, City city )
        {
            Id = id;
            HomeCity = city;
        }
    }
}
