/*
 * 13. Read the duration of an experiment in seconds and 
       calculate the duration in Hours, Minutes and Seconds.
 */
using System;
class _006_BasicOperationsQuestions13
{
  public static void Main(string[] args)
  {
    /*
    Entrada: 86399; Saída: 23 horas, 59 minutos e 59 segundos
    Entrada: 3600; Saída: 1 hora, 0 minutos e 0 segundos
    Entrada: 12345; Saída: 3 horas, 25 minutos e 45 segundos
    Entrada: 50000; Saída: 13 horas, 53 minutos e 20 segundos
    Entrada: 86400; Saída: 24 horas, 0 minutos e 0 segundos
    // 72345 seconds is equal to 20 hours, 12 minutes and 25 seconds.
    Input: 72345 Output: 20 hours, 12 minutes, and 25 seconds
     */

    Console.Write("Time in seconds: ");
    int timeInSeconds = Convert.ToInt32(Console.ReadLine());
    int hours = timeInSeconds / 3600; // Getting hours, as we have 3600 seconds in 1 hour
    int timeInSecondsAux = timeInSeconds % 3600; // Saving the seconds that has left
    int minutes = timeInSecondsAux / 60; // Getting minutes, as we have 60 seconds in 1 minute
    int seconds = timeInSecondsAux % 60; // The rest represents the seconds

    Console.WriteLine($"In {timeInSeconds} has {hours} hours, {minutes} minutes and {seconds} seconds");
  }
}