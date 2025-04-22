/*
   Create a C# program that processes inputs of candidates along with the 
   voters who voted for them. At the end, generate a summary of the most 
   voted candidates, ranked by the number of unique voters who voted for
   each candidate. Display the results in descending order of vote count,
   and for candidates with the same vote count, sort them alphabetically.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections;

public class ElectionApp
{
  public static void Main(string[] args)
  {
    Election election = new Election();
    election.CastVote("Alice", 1);
    election.CastVote("Bob", 1);
    election.CastVote("Charlie", 1);
    election.CastVote("Hannah", 1);
    election.CastVote("Jack", 1);
    election.PrintVotingSummary();

    election.CastVote("Alice", 1);
    election.CastVote("Bob", 1);
    election.CastVote("Charlie", 1);
    election.CastVote("David", 1);
    election.CastVote("Eve", 1);
    election.CastVote("Eve", 2);
    election.CastVote("Hannah", 2);
    election.CastVote("Isaac", 1);
    election.CastVote("Jack", 1);
    election.PrintVotingSummary();

    election.CastVote("Alice", 2);
    election.CastVote("Alice", 2);
    election.CastVote("Bob", 1);
    election.CastVote("Bob", 2);
    election.CastVote("Bob", 3);
    election.CastVote("Charlie", 1);
    election.CastVote("David", 2);
    election.CastVote("Isaac", 2);
    election.CastVote("Jack", 3);
    election.PrintVotingSummary();

    election.CastVote("Alice", 3);
    election.CastVote("Alice", 4);
    election.CastVote("Alice", 4);
    election.CastVote("Bob", 2);
    election.CastVote("Bob", 3);
    election.CastVote("Eve", 1);
    election.CastVote("Eve", 2);
    election.CastVote("Eve", 2);
    election.CastVote("Eve", 3);
    election.CastVote("Frank", 1);
    election.CastVote("Jack", 4);
    election.PrintVotingSummary();

    election.CastVote("Frank", 1);
    election.CastVote("Frank", 2);
    election.CastVote("Frank", 3);
    election.PrintVotingSummary();

    election.CastVote("Grace", 1);
    election.CastVote("Grace", 2);
    election.CastVote("Hannah", 3);
    election.CastVote("Alice", 7);
    election.PrintVotingSummary();
  }
}

public class Election
{
  private Dictionary<string, HashSet<int>> votes;

  public Election()
  {
    votes = new Dictionary<string, HashSet<int>>();
  }
  public void CastVote(string candidate, int voterId)
  {
    if (!votes.ContainsKey(candidate))
    {
      votes[candidate] = new HashSet<int>();
    }
    votes[candidate].Add(voterId);
  }

  public void PrintVotingSummary()
  {
    Console.WriteLine("Voting summary");
    var summary = new SortedDictionary<int, List<string>>();
    foreach (var candidate in votes.Keys)
    {
      int voteCount = votes[candidate].Count;
      if (!summary.ContainsKey(voteCount))
      {
        summary.Add(voteCount, new List<string>());
      }
      summary[voteCount].Add(candidate);
    }

    foreach (var voteCount in summary.Keys.Reverse())
    {
      Console.Write($"{voteCount}: ");
      summary[voteCount].Sort();
      foreach (var candidate in summary[voteCount])
      {
        Console.Write($"[{candidate}], ");
      }
      Console.WriteLine();
    }
  }
}