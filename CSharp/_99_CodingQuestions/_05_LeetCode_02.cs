// https://leetcode.com/problems/add-two-numbers

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CodingQuestions;

public class ListNode
{
  public int val;
  public ListNode next;
  public ListNode(int val = 0, ListNode next = null)
  {
    this.val = val;
    this.next = next;
  }
}

public class LeetCode_02
{
  public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
  {
    ListNode head = null;
    ListNode tail = null;
    bool overflow = false;
    while (l1 != null || l2 != null)
    {
      int term = 0;
      if (l1 != null)
      {
        term = l1.val;
      }
      if (l2 != null)
      {
        term += l2.val;
      }
      if (overflow)
      {
        term++;
      }
      int digit = term % 10;
      overflow = term > 9;
      var newNode = new ListNode(digit);
      if (head == null)
      {
        head = newNode;
        tail = newNode;
      }
      else
      {
        tail.next = newNode;
        tail = newNode;
      }
      if (l1 != null)
      {
        l1 = l1.next;
      }
      if (l2 != null)
      {
        l2 = l2.next;
      }
    }
    if (overflow)
    {
      var newNode = new ListNode(1);
      tail.next = newNode;
    }
    return head;
  }
}